using System;
using SharedKernel.Common;
using Domain.Models.Employee;
using SharedKernel;

namespace Domain.Models
{
    public class KPI : Entity,ISoftDeletableEntity
    {
        public Guid EmployeeId { get; set; }
        public string MetricName { get; set; } = null!;
        public decimal BonusAmount { get; set; }
        public decimal TargetValue { get; set; }
        public decimal ActualValue { get; set; }
        public decimal AchievementPercentage { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Comments { get; set; } = null!;

        public virtual Employee.Employee? Employee { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}