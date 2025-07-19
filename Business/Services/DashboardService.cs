using AD_CW_1.Business.Interface;
using AD_CW_1.Database;
using AD_CW_1.Models.Dashboard;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Services
{
    public class DashboardService : IDashboardService
    {
        public DashboardMetricsModel GetDashboardMetrics()
        {
            var metrics = new DashboardMetricsModel();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                int currentYear = DateTime.Now.Year;
                int lastYear = currentYear - 1;

                string customerQuery = @"
                    SELECT 
                        COUNT(*) as total_customers,
                        SUM(CASE WHEN YEAR(created_at) = @currentYear THEN 1 ELSE 0 END) as current_year_customers,
                        SUM(CASE WHEN YEAR(created_at) = @lastYear THEN 1 ELSE 0 END) as last_year_customers
                    FROM customers";

                MySqlCommand customerCmd = new MySqlCommand(customerQuery, connection);
                customerCmd.Parameters.AddWithValue("@currentYear", currentYear);
                customerCmd.Parameters.AddWithValue("@lastYear", lastYear);

                using (var reader = customerCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        metrics.TotalCustomers = SafeConvertToInt32(reader["total_customers"]);
                        int currentYearCustomers = SafeConvertToInt32(reader["current_year_customers"]);
                        int lastYearCustomers = SafeConvertToInt32(reader["last_year_customers"]);

                        if (lastYearCustomers > 0)
                        {
                            metrics.CustomerIncreasePercentage = (int)Math.Round(
                                ((double)(currentYearCustomers - lastYearCustomers) / lastYearCustomers) * 100);
                        }
                        else
                        {
                            metrics.CustomerIncreasePercentage = currentYearCustomers > 0 ? 100 : 0;
                        }
                    }
                }

                string unitsQuery = @"
                    SELECT 
                        COUNT(*) as total_units,
                        SUM(CASE WHEN YEAR(created_at) = @currentYear THEN 1 ELSE 0 END) as current_year_units,
                        SUM(CASE WHEN YEAR(created_at) = @lastYear THEN 1 ELSE 0 END) as last_year_units
                    FROM transport_units";

                MySqlCommand unitsCmd = new MySqlCommand(unitsQuery, connection);
                unitsCmd.Parameters.AddWithValue("@currentYear", currentYear);
                unitsCmd.Parameters.AddWithValue("@lastYear", lastYear);

                using (var reader = unitsCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        metrics.TotalTransportUnits = SafeConvertToInt32(reader["total_units"]);
                        int currentYearUnits = SafeConvertToInt32(reader["current_year_units"]);
                        int lastYearUnits = SafeConvertToInt32(reader["last_year_units"]);

                        if (lastYearUnits > 0)
                        {
                            metrics.TransportUnitsIncreasePercentage = (int)Math.Round(
                                ((double)(currentYearUnits - lastYearUnits) / lastYearUnits) * 100);
                        }
                        else
                        {
                            metrics.TransportUnitsIncreasePercentage = currentYearUnits > 0 ? 100 : 0;
                        }
                    }
                }

                string jobsQuery = @"
                    SELECT 
                        COUNT(*) as total_completed,
                        SUM(CASE WHEN YEAR(completion_date) = @currentYear THEN 1 ELSE 0 END) as current_year_completed,
                        SUM(CASE WHEN YEAR(completion_date) = @lastYear THEN 1 ELSE 0 END) as last_year_completed
                    FROM jobs 
                    WHERE status = 'Completed' AND completion_date IS NOT NULL";

                MySqlCommand jobsCmd = new MySqlCommand(jobsQuery, connection);
                jobsCmd.Parameters.AddWithValue("@currentYear", currentYear);
                jobsCmd.Parameters.AddWithValue("@lastYear", lastYear);

                using (var reader = jobsCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        metrics.TotalCompletedJobs = SafeConvertToInt32(reader["total_completed"]);
                        int currentYearJobs = SafeConvertToInt32(reader["current_year_completed"]);
                        int lastYearJobs = SafeConvertToInt32(reader["last_year_completed"]);

                        if (lastYearJobs > 0)
                        {
                            metrics.CompletedJobsIncreasePercentage = (int)Math.Round(
                                ((double)(currentYearJobs - lastYearJobs) / lastYearJobs) * 100);
                        }
                        else
                        {
                            metrics.CompletedJobsIncreasePercentage = currentYearJobs > 0 ? 100 : 0;
                        }
                    }
                }
            }

            return metrics;
        }

        public List<MonthlyJobsModel> GetMonthlyJobsData(int year)
        {
            var monthlyData = new List<MonthlyJobsModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT 
                        MONTH(completion_date) as month_num,
                        MONTHNAME(completion_date) as month_name,
                        COUNT(*) as completed_jobs,
                        (SELECT COUNT(*) FROM jobs j2 
                         WHERE YEAR(j2.request_date) = @year 
                         AND MONTH(j2.request_date) = MONTH(j.completion_date)) as total_jobs,
                        SUM(COALESCE(actual_cost, estimated_cost)) as revenue
                    FROM jobs j
                    WHERE YEAR(completion_date) = @year 
                    AND status = 'Completed'
                    AND completion_date IS NOT NULL
                    GROUP BY MONTH(completion_date), MONTHNAME(completion_date)
                    ORDER BY MONTH(completion_date)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@year", year);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        monthlyData.Add(new MonthlyJobsModel
                        {
                            Month = SafeConvertToString(reader["month_name"]),
                            Year = year,
                            CompletedJobs = SafeConvertToInt32(reader["completed_jobs"]),
                            TotalJobs = SafeConvertToInt32(reader["total_jobs"]),
                            Revenue = SafeConvertToDecimal(reader["revenue"])
                        });
                    }
                }
            }

            return monthlyData;
        }

        public List<MonthlyTransportUnitsModel> GetMonthlyTransportUnitsData(int year)
        {
            var monthlyData = new List<MonthlyTransportUnitsModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT 
                        m.month_num,
                        m.month_name,
                        COUNT(DISTINCT tu.id) as active_units,
                        (SELECT COUNT(*) FROM transport_units WHERE status = '1') as total_units,
                        CASE 
                            WHEN (SELECT COUNT(*) FROM transport_units WHERE status = '1') > 0 
                            THEN (COUNT(DISTINCT tu.id) * 100.0 / (SELECT COUNT(*) FROM transport_units WHERE status = '1'))
                            ELSE 0 
                        END as utilization
                    FROM (
                        SELECT 1 as month_num, 'Jan' as month_name
                        UNION SELECT 2, 'Feb' UNION SELECT 3, 'Mar' UNION SELECT 4, 'Apr'
                        UNION SELECT 5, 'May' UNION SELECT 6, 'Jun' UNION SELECT 7, 'Jul'
                        UNION SELECT 8, 'Aug' UNION SELECT 9, 'Sep' UNION SELECT 10, 'Oct'
                        UNION SELECT 11, 'Nov' UNION SELECT 12, 'Dec'
                    ) m
                    LEFT JOIN jobs j ON YEAR(j.request_date) = @year AND MONTH(j.request_date) = m.month_num
                    LEFT JOIN transport_units tu ON j.transport_unit_id = tu.id
                    GROUP BY m.month_num, m.month_name
                    ORDER BY m.month_num";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@year", year);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        monthlyData.Add(new MonthlyTransportUnitsModel
                        {
                            Month = SafeConvertToString(reader["month_name"]),
                            Year = year,
                            ActiveUnits = SafeConvertToInt32(reader["active_units"]),
                            TotalUnits = SafeConvertToInt32(reader["total_units"]),
                            Utilization = SafeConvertToDecimal(reader["utilization"])
                        });
                    }
                }
            }

            return monthlyData;
        }

        public List<SalesPersonPerformanceModel> GetSalesPersonPerformance()
        {
            var performanceData = new List<SalesPersonPerformanceModel>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT 
                        d.name as sales_person,
                        SUM(CASE WHEN YEAR(j.request_date) = YEAR(CURDATE()) THEN 1 ELSE 0 END) as jobs_this_year,
                        SUM(CASE WHEN YEAR(j.request_date) = YEAR(CURDATE()) - 1 THEN 1 ELSE 0 END) as jobs_last_year,
                        SUM(CASE WHEN YEAR(j.request_date) = YEAR(CURDATE()) THEN COALESCE(j.actual_cost, j.estimated_cost) ELSE 0 END) as revenue_this_year,
                        SUM(CASE WHEN YEAR(j.request_date) = YEAR(CURDATE()) - 1 THEN COALESCE(j.actual_cost, j.estimated_cost) ELSE 0 END) as revenue_last_year
                    FROM drivers d
                    LEFT JOIN transport_units tu ON d.id = tu.driver_id
                    LEFT JOIN jobs j ON tu.id = j.transport_unit_id
                    GROUP BY d.id, d.name
                    HAVING jobs_this_year > 0 OR jobs_last_year > 0
                    ORDER BY jobs_this_year DESC
                    LIMIT 10";

                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        performanceData.Add(new SalesPersonPerformanceModel
                        {
                            SalesPersonName = SafeConvertToString(reader["sales_person"]),
                            JobsThisYear = SafeConvertToInt32(reader["jobs_this_year"]),
                            JobsLastYear = SafeConvertToInt32(reader["jobs_last_year"]),
                            RevenueThisYear = SafeConvertToDecimal(reader["revenue_this_year"]),
                            RevenueLastYear = SafeConvertToDecimal(reader["revenue_last_year"])
                        });
                    }
                }
            }

            return performanceData;
        }


        private int SafeConvertToInt32(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;

            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }

        private decimal SafeConvertToDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0m;

            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0m;
            }
        }

        private string SafeConvertToString(object value)
        {
            if (value == null || value == DBNull.Value)
                return string.Empty;

            try
            {
                return value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        private double SafeConvertToDouble(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0.0;

            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0.0;
            }
        }
    }
}