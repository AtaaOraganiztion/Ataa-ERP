using Domain.Entities;
using SharedKernel;

namespace Domain.Models.CRM.EmployeePerformanceReport;

public class EmployeePerformanceReport : Entity, ISoftDeletableEntity
{
    public List<string> Associations { get; set; } = new(); // الجمعية
    public string EmployeeName { get; set; } = string.Empty; // الموظف
    public string ReportDate { get; set; } = string.Empty; // اليوم والتاريخ
    
    // عدد المراسلات والرفع
    public Dictionary<string, int> CorrespondenceStats { get; set; } = new();
    
    public List<string> Projects { get; set; } = new(); // المشاريع
    public int FollowUpsCount { get; set; } // عدد المتابعات
    public int ResponsesCount { get; set; } // عدد الإستجابة (التفاعل)
    public List<string> KeyResults { get; set; } = new(); // أبرز النتائج

    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}
