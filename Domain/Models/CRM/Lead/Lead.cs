
using Domain.Entities;
using Domain.Enums.CRM;
using SharedKernel;
using SharedKernel.Common;
using System.Diagnostics;
using System.Xml;

namespace Domain.Models.CRM.Lead;

public class Lead : Entity, ISoftDeletableEntity
{
    public string Title { get; set; }
    public decimal? Value { get; set; }
    public LeadStatus Status { get; set; }
    public LeadStage Stage { get; set; }
    public DateTime? ExpectedCloseDate { get; set; }
    public string? Notes { get; set; }
    public string FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Company { get; set; }
    public string? Address { get; set; }
  
    public Ulid? CustomerId { get; set; }
    public Ulid? AssignedToUserId { get; set; }

    public virtual Customer.Customer? Customer { get; set; }
    public virtual User? AssignedTo { get; set; }
    public virtual ICollection<Domain.Models.CRM.Deal.Deal> Deals { get; set; }
    public virtual ICollection<Domain.Models.CRM.Activity.Activity> Activities { get; set; }

    public Lead()
    {
        Deals = new HashSet<Domain.Models.CRM.Deal.Deal>();
        Activities = new HashSet<Domain.Models.CRM.Activity.Activity>();
    }

    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}

