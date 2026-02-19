using System;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class KPI : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public string MetricName { get; set; }
        public decimal TargetValue { get; set; }
        public decimal ActualValue { get; set; }
        public decimal AchievementPercentage { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Comments { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
