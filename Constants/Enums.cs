using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Constants
{
    /// <summary>
    /// Enum representing the status of a job.
    /// </summary>
    /// <remarks>
    /// This enum is used to track the different states a job can be in during its lifecycle.
    /// </remarks>
    [Flags]
    public enum JobStatus
    {
        Pending = 1,
        Confirmed = 2,
        Collected = 4,
        Completed = 8,
        Cancelled = 16,
        OnHold = 32
    }

    public enum ReportType
    {
        CustomerActivity,
        JobSummary,
        TransportUnitUtilization,
        DriverPerformance,
        RevenueAnalysis,
        LoadAnalysis,
        ProductMovement,
        JobStatusReport,
        CustomerJobHistory,
        FleetReport
    }
}
