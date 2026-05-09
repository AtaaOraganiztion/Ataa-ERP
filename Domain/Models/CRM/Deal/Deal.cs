
using Domain.Entities;
using Domain.Enums.CRM;
using SharedKernel;
using SharedKernel.Common;
using System.Diagnostics;


namespace Domain.Models.CRM.Deal;

public class Deal : Entity, ISoftDeletableEntity
{
    public string Title { get; set; }
    public Ulid? CustomerId { get; set; }
    public decimal Value { get; set; }
    public DealStatus Status { get; set; }
    public DateTime? ClosedDate { get; set; }
    public string? Notes { get; set; }
    public Ulid LeadId { get; set; }
    public Ulid? AssignedToUserId { get; set; }

    public virtual Lead.Lead? Lead { get; set; }
    public virtual User? AssignedTo { get; set; }
    public virtual Customer.Customer? Customer { get; set; }    
    public virtual ICollection<Domain.Models.CRM.Activity.Activity> Activities { get; set; }
    public virtual ICollection<Domain.Models.CRM.GlobalActivity.GlobalActivity> GlobalActivities { get; set; }

    public Deal()
    {
        Activities = new HashSet<Domain.Models.CRM.Activity.Activity>();
    }

    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}
    