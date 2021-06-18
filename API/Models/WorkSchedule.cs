using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class WorkSchedule
    {
        public int WorkSchedule1 { get; set; }
        public int? CardScanId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime? WorkDate { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual CardScan CardScan { get; set; }
    }
}
