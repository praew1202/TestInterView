using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class CardScan
    {
        public CardScan()
        {
            WorkSchedules = new HashSet<WorkSchedule>();
        }

        public int CardScanId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime? Clock { get; set; }

        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}
