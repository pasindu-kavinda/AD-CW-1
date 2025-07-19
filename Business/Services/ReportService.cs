using AD_CW_1.Business.Interface;
using AD_CW_1.Database;
using AD_CW_1.Models.Reports;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace AD_CW_1.Business.Services
{
        public class ReportService : IReportService
        {
            public List<CustomerActivityReportModel> GetCustomerActivityReport(DateTime startDate, DateTime endDate, int? userId = null)
            {
                var reports = new List<CustomerActivityReportModel>();

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                    SELECT 
                        c.customer_number,
                        c.name as customer_name,
                        c.email,
                        c.phone,
                        COUNT(j.id) as total_jobs,
                        SUM(CASE WHEN j.status = 'Completed' THEN 1 ELSE 0 END) as completed_jobs,
                        SUM(CASE WHEN j.status IN ('Pending', 'Confirmed', 'In Progress') THEN 1 ELSE 0 END) as pending_jobs,
                        SUM(CASE WHEN j.status = 'Cancelled' THEN 1 ELSE 0 END) as cancelled_jobs,
                        COALESCE(SUM(CASE WHEN j.actual_cost IS NOT NULL THEN j.actual_cost ELSE j.estimated_cost END), 0) as total_revenue,
                        COALESCE(AVG(CASE WHEN j.actual_cost IS NOT NULL THEN j.actual_cost ELSE j.estimated_cost END), 0) as average_job_value,
                        MAX(j.request_date) as last_job_date
                    FROM customers c
                    LEFT JOIN jobs j ON c.id = j.customer_id 
                        AND j.request_date BETWEEN @startDate AND @endDate
                    WHERE (@userId IS NULL OR c.user_id = @userId)
                    GROUP BY c.id, c.customer_number, c.name, c.email, c.phone
                    ORDER BY total_revenue DESC";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);
                    command.Parameters.AddWithValue("@userId", userId);

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        reports.Add(new CustomerActivityReportModel
                        {
                            CustomerNumber = reader["customer_number"].ToString(),
                            CustomerName = reader["customer_name"].ToString(),
                            Email = reader["email"].ToString(),
                            Phone = reader["phone"].ToString(),
                            TotalJobs = Convert.ToInt32(reader["total_jobs"]),
                            CompletedJobs = Convert.ToInt32(reader["completed_jobs"]),
                            PendingJobs = Convert.ToInt32(reader["pending_jobs"]),
                            CancelledJobs = Convert.ToInt32(reader["cancelled_jobs"]),
                            TotalRevenue = Convert.ToDecimal(reader["total_revenue"]),
                            AverageJobValue = Convert.ToDecimal(reader["average_job_value"]),
                            LastJobDate = reader["last_job_date"] != DBNull.Value ? Convert.ToDateTime(reader["last_job_date"]) : DateTime.MinValue,
                            Status = Convert.ToInt32(reader["total_jobs"]) > 0 ? "Active" : "Inactive"
                        });
                    }
                }

                return reports;
            }

            public List<JobSummaryReportModel> GetJobSummaryReport(DateTime startDate, DateTime endDate, int? userId = null)
            {
                var reports = new List<JobSummaryReportModel>();

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                    SELECT 
                        j.job_number,
                        c.name as customer_name,
                        j.pickup_location,
                        j.delivery_location,
                        j.request_date,
                        j.scheduled_date,
                        j.completion_date,
                        j.status,
                        j.estimated_cost,
                        j.actual_cost,
                        tu.unit_number as transport_unit,
                        d.name as driver_name,
                        COALESCE(SUM(l.weight), 0) as total_weight,
                        COALESCE(SUM(l.volume), 0) as total_volume,
                        CASE 
                            WHEN j.completion_date IS NOT NULL AND j.request_date IS NOT NULL 
                            THEN DATEDIFF(j.completion_date, j.request_date)
                            ELSE 0 
                        END as days_to_complete
                    FROM jobs j
                    INNER JOIN customers c ON j.customer_id = c.id
                    LEFT JOIN transport_units tu ON j.transport_unit_id = tu.id
                    LEFT JOIN drivers d ON tu.driver_id = d.id
                    LEFT JOIN loads l ON j.id = l.job_id
                    WHERE j.request_date BETWEEN @startDate AND @endDate
                        AND (@userId IS NULL OR c.user_id = @userId)
                    GROUP BY j.id, j.job_number, c.name, j.pickup_location, j.delivery_location,
                             j.request_date, j.scheduled_date, j.completion_date, j.status,
                             j.estimated_cost, j.actual_cost, tu.unit_number, d.name
                    ORDER BY j.request_date DESC";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);
                    command.Parameters.AddWithValue("@userId", userId);

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                    reports.Add(new JobSummaryReportModel
                    {
                        JobNumber = reader["job_number"].ToString(),
                        CustomerName = reader["customer_name"].ToString(),
                        PickupLocation = reader["pickup_location"].ToString(),
                        DeliveryLocation = reader["delivery_location"].ToString(),
                        RequestDate = Convert.ToDateTime(reader["request_date"]),
                        ScheduledDate = reader["scheduled_date"] != DBNull.Value
                         ? (DateTime?)Convert.ToDateTime(reader["scheduled_date"])
                         : null,
                                            CompletionDate = reader["completion_date"] != DBNull.Value
                         ? (DateTime?)Convert.ToDateTime(reader["completion_date"])
                         : null,
                                            Status = reader["status"].ToString(),
                                            EstimatedCost = Convert.ToDecimal(reader["estimated_cost"]),
                                            ActualCost = reader["actual_cost"] != DBNull.Value
                         ? (decimal?)Convert.ToDecimal(reader["actual_cost"])
                         : null,
                                            TransportUnit = reader["transport_unit"] != DBNull.Value
                         ? reader["transport_unit"].ToString()
                         : "Not Assigned",
                                            DriverName = reader["driver_name"] != DBNull.Value
                         ? reader["driver_name"].ToString()
                         : "Not Assigned",
                        TotalWeight = Convert.ToDecimal(reader["total_weight"]),
                        TotalVolume = Convert.ToDecimal(reader["total_volume"]),
                        DaysToComplete = Convert.ToInt32(reader["days_to_complete"])
                    });

                }
            }

                return reports;
            }

            public List<TransportUnitUtilizationReportModel> GetTransportUnitUtilizationReport(DateTime startDate, DateTime endDate)
            {
                var reports = new List<TransportUnitUtilizationReportModel>();

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                    SELECT 
                        tu.unit_number,
                        t.truck_number,
                        t.model as truck_model,
                        d.name as driver_name,
                        a.name as assistant_name,
                        COUNT(j.id) as total_jobs,
                        SUM(CASE WHEN j.status = 'Completed' THEN 1 ELSE 0 END) as completed_jobs,
                        COALESCE(SUM(CASE WHEN j.actual_cost IS NOT NULL THEN j.actual_cost ELSE j.estimated_cost END), 0) as total_revenue,
                        COALESCE(SUM(l.weight), 0) as total_weight,
                        COALESCE(SUM(l.volume), 0) as total_volume,
                        DATEDIFF(@endDate, @startDate) as total_days,
                        tu.status
                    FROM transport_units tu
                    INNER JOIN trucks t ON tu.truck_id = t.id
                    INNER JOIN drivers d ON tu.driver_id = d.id
                    LEFT JOIN assistants a ON tu.assistant_id = a.id
                    LEFT JOIN jobs j ON tu.id = j.transport_unit_id 
                        AND j.request_date BETWEEN @startDate AND @endDate
                    LEFT JOIN loads l ON j.id = l.job_id
                    GROUP BY tu.id, tu.unit_number, t.truck_number, t.model, d.name, a.name, tu.status
                    ORDER BY total_revenue DESC";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int totalDays = Convert.ToInt32(reader["total_days"]);
                        int completedJobs = Convert.ToInt32(reader["completed_jobs"]);

                        reports.Add(new TransportUnitUtilizationReportModel
                        {
                            UnitNumber = reader["unit_number"].ToString(),
                            TruckNumber = reader["truck_number"].ToString(),
                            TruckModel = reader["truck_model"].ToString(),
                            DriverName = reader["driver_name"].ToString(),
                            AssistantName = reader["assistant_name"]?.ToString() ?? "Not Assigned",
                            TotalJobs = Convert.ToInt32(reader["total_jobs"]),
                            CompletedJobs = completedJobs,
                            TotalRevenue = Convert.ToDecimal(reader["total_revenue"]),
                            TotalWeight = Convert.ToDecimal(reader["total_weight"]),
                            TotalVolume = Convert.ToDecimal(reader["total_volume"]),
                            UtilizationDays = completedJobs, // Simplified - could be more complex
                            UtilizationPercentage = totalDays > 0 ? (decimal)completedJobs / totalDays * 100 : 0,
                            Status = reader["status"].ToString()
                        });
                    }
                }

                return reports;
            }

            public List<DriverPerformanceReportModel> GetDriverPerformanceReport(DateTime startDate, DateTime endDate)
            {
                var reports = new List<DriverPerformanceReportModel>();

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                    SELECT 
                        d.name as driver_name,
                        d.license_number,
                        d.phone,
                        COUNT(j.id) as total_jobs,
                        SUM(CASE WHEN j.status = 'Completed' THEN 1 ELSE 0 END) as completed_jobs,
                        SUM(CASE WHEN j.status = 'Completed' AND j.completion_date <= j.scheduled_date THEN 1 ELSE 0 END) as on_time_jobs,
                        COALESCE(SUM(CASE WHEN j.actual_cost IS NOT NULL THEN j.actual_cost ELSE j.estimated_cost END), 0) as total_revenue,
                        COUNT(DISTINCT DATE(j.request_date)) as active_days,
                        d.status as current_status
                    FROM drivers d
                    LEFT JOIN transport_units tu ON d.id = tu.driver_id
                    LEFT JOIN jobs j ON tu.id = j.transport_unit_id 
                        AND j.request_date BETWEEN @startDate AND @endDate
                    GROUP BY d.id, d.name, d.license_number, d.phone, d.status
                    ORDER BY total_revenue DESC";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int totalJobs = Convert.ToInt32(reader["total_jobs"]);
                        int completedJobs = Convert.ToInt32(reader["completed_jobs"]);
                        int onTimeJobs = Convert.ToInt32(reader["on_time_jobs"]);
                        decimal totalRevenue = Convert.ToDecimal(reader["total_revenue"]);

                        reports.Add(new DriverPerformanceReportModel
                        {
                            DriverName = reader["driver_name"].ToString(),
                            LicenseNumber = reader["license_number"].ToString(),
                            Phone = reader["phone"]?.ToString() ?? "",
                            TotalJobs = totalJobs,
                            CompletedJobs = completedJobs,
                            OnTimeJobs = onTimeJobs,
                            CompletionRate = totalJobs > 0 ? (decimal)completedJobs / totalJobs * 100 : 0,
                            OnTimeRate = completedJobs > 0 ? (decimal)onTimeJobs / completedJobs * 100 : 0,
                            TotalRevenue = totalRevenue,
                            AverageJobValue = totalJobs > 0 ? totalRevenue / totalJobs : 0,
                            ActiveDays = Convert.ToInt32(reader["active_days"]),
                            CurrentStatus = reader["current_status"].ToString()
                        });
                    }
                }

                return reports;
            }

            public List<RevenueAnalysisReportModel> GetRevenueAnalysisReport(DateTime startDate, DateTime endDate, string groupBy = "month")
            {
                var reports = new List<RevenueAnalysisReportModel>();

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                string dateGrouping;

                if (groupBy != null && groupBy.ToLower() == "day")
                    dateGrouping = "DATE(j.request_date)";
                else if (groupBy != null && groupBy.ToLower() == "week")
                    dateGrouping = "YEARWEEK(j.request_date)";
                else if (groupBy != null && groupBy.ToLower() == "month")
                    dateGrouping = "DATE_FORMAT(j.request_date, '%Y-%m')";
                else if (groupBy != null && groupBy.ToLower() == "year")
                    dateGrouping = "YEAR(j.request_date)";
                else
                    dateGrouping = "DATE_FORMAT(j.request_date, '%Y-%m')";


                string query = $@"
                    SELECT 
                        {dateGrouping} as period_group,
                        MIN(j.request_date) as period,
                        COUNT(j.id) as total_jobs,
                        SUM(j.estimated_cost) as estimated_revenue,
                        SUM(CASE WHEN j.actual_cost IS NOT NULL THEN j.actual_cost ELSE j.estimated_cost END) as actual_revenue,
                        (SUM(CASE WHEN j.actual_cost IS NOT NULL THEN j.actual_cost ELSE j.estimated_cost END) - SUM(j.estimated_cost)) as revenue_variance,
                        AVG(CASE WHEN j.actual_cost IS NOT NULL THEN j.actual_cost ELSE j.estimated_cost END) as average_job_value,
                        COUNT(DISTINCT CASE WHEN c.created_at BETWEEN @startDate AND @endDate THEN c.id END) as new_customers,
                        COUNT(DISTINCT CASE WHEN c.created_at < @startDate THEN c.id END) as repeat_customers
                    FROM jobs j
                    INNER JOIN customers c ON j.customer_id = c.id
                    WHERE j.request_date BETWEEN @startDate AND @endDate
                    GROUP BY {dateGrouping}
                    ORDER BY period";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        reports.Add(new RevenueAnalysisReportModel
                        {
                            Period = Convert.ToDateTime(reader["period"]),
                            TotalJobs = Convert.ToInt32(reader["total_jobs"]),
                            EstimatedRevenue = Convert.ToDecimal(reader["estimated_revenue"]),
                            ActualRevenue = Convert.ToDecimal(reader["actual_revenue"]),
                            RevenueVariance = Convert.ToDecimal(reader["revenue_variance"]),
                            AverageJobValue = Convert.ToDecimal(reader["average_job_value"]),
                            NewCustomers = Convert.ToInt32(reader["new_customers"]),
                            RepeatCustomers = Convert.ToInt32(reader["repeat_customers"]),
                            TopCustomer = "", // Would need separate query
                            TopCustomerRevenue = 0 // Would need separate query
                        });
                    }
                }

                return reports;
            }

            public bool ExportToPDF<T>(List<T> data, string reportTitle, string filePath)
            {
                try
                {
                    Document document = new Document(PageSize.A4, 10, 10, 10, 10);
                    PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                    document.Open();

                    // Add title
                    Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    Paragraph title = new Paragraph(reportTitle, titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 20;
                    document.Add(title);

                    // Add generation date
                    Font dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    Paragraph dateInfo = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", dateFont);
                    dateInfo.Alignment = Element.ALIGN_RIGHT;
                    dateInfo.SpacingAfter = 20;
                    document.Add(dateInfo);

                    if (data.Any())
                    {
                        // Get properties for table headers
                        PropertyInfo[] properties = typeof(T).GetProperties();

                        // Create table
                        PdfPTable table = new PdfPTable(properties.Length);
                        table.WidthPercentage = 100;

                        // Add headers
                        Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                        foreach (var prop in properties)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(prop.Name, headerFont));
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            table.AddCell(cell);
                        }

                        // Add data rows
                        Font dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 8);
                        foreach (var item in data)
                        {
                            foreach (var prop in properties)
                            {
                                var value = prop.GetValue(item)?.ToString() ?? "";
                                PdfPCell cell = new PdfPCell(new Phrase(value, dataFont));
                                table.AddCell(cell);
                            }
                        }

                        document.Add(table);
                    }
                    else
                    {
                        document.Add(new Paragraph("No data available for the selected criteria."));
                    }

                    document.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"PDF Export Error: {ex.Message}");
                    return false;
                }
            }

            public bool ExportToExcel<T>(List<T> data, string reportTitle, string filePath)
            {
                try
                {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(reportTitle);

                        worksheet.Cells[1, 1].Value = reportTitle;
                        worksheet.Cells[1, 1].Style.Font.Bold = true;
                        worksheet.Cells[1, 1].Style.Font.Size = 16;

                        worksheet.Cells[2, 1].Value = $"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

                        if (data.Any())
                        {
                            PropertyInfo[] properties = typeof(T).GetProperties();

                            for (int i = 0; i < properties.Length; i++)
                            {
                                worksheet.Cells[4, i + 1].Value = properties[i].Name;
                                worksheet.Cells[4, i + 1].Style.Font.Bold = true;
                                worksheet.Cells[4, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                worksheet.Cells[4, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                            }

                            for (int row = 0; row < data.Count; row++)
                            {
                                for (int col = 0; col < properties.Length; col++)
                                {
                                    var value = properties[col].GetValue(data[row]);
                                    worksheet.Cells[row + 5, col + 1].Value = value;
                                }
                            }

                            worksheet.Cells.AutoFitColumns();
                        }
                        else
                        {
                            worksheet.Cells[4, 1].Value = "No data available for the selected criteria.";
                        }

                        FileInfo file = new FileInfo(filePath);
                        package.SaveAs(file);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Excel Export Error: {ex.Message}");
                    return false;
                }
            }

            public bool ExportToExcelWithClosedXML<T>(List<T> data, string reportTitle, string filePath)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add(reportTitle);

                        worksheet.Cell(1, 1).Value = reportTitle;
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Font.FontSize = 16;

                        worksheet.Cell(2, 1).Value = $"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

                        if (data != null && data.Any())
                        {
                            PropertyInfo[] properties = typeof(T).GetProperties();

                            for (int i = 0; i < properties.Length; i++)
                            {
                                var cell = worksheet.Cell(4, i + 1);
                                cell.Value = properties[i].Name;
                                cell.Style.Font.Bold = true;
                                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                            }

                            for (int row = 0; row < data.Count; row++)
                            {
                                for (int col = 0; col < properties.Length; col++)
                                {
                                    var value = properties[col].GetValue(data[row]);
                                    var cell = worksheet.Cell(row + 5, col + 1);

                                    if (value != null)
                                    {
                                        cell.Value = value.ToString();

                                        string propName = properties[col].Name.ToLower();
                                        if (propName.Contains("revenue") || propName.Contains("cost") || propName.Contains("value"))
                                        {
                                            cell.Style.NumberFormat.Format = "$#,##0.00";
                                        }
                                        else if (propName.Contains("date"))
                                        {
                                            cell.Style.NumberFormat.Format = "yyyy-mm-dd";
                                        }
                                    }
                                }
                            }

                            worksheet.ColumnsUsed().AdjustToContents();

                            var dataRange = worksheet.Range(4, 1, data.Count + 4, properties.Length);
                            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        }
                        else
                        {
                            worksheet.Cell(4, 1).Value = "No data available for the selected criteria.";
                        }

                        workbook.SaveAs(filePath);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Excel Export Error: {ex.Message}");
                    return false;
                }
            }
    }
}
