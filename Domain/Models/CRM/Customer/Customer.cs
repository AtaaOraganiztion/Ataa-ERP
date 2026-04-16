using Domain.Entities;
using Domain.Enums.CRM;
using Domain.Models.CRM.Lead;
using SharedKernel;
using SharedKernel.Common;
using System.Diagnostics;

namespace Domain.Models.CRM.Customer;

public class Customer : Entity, ISoftDeletableEntity
{
    public string FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Company { get; set; }
    public string? Address { get; set; }
    public CustomerStatus Status { get; set; }
    public string? Notes { get; set; }
    public Ulid? AssignedToUserId { get; set; }

    public virtual User? AssignedTo { get; set; }
    public virtual ICollection<Domain.Models.CRM.Lead.Lead> Leads { get; set; }
    public virtual ICollection<Domain.Models.CRM.Activity.Activity> Activities { get; set; }
    public virtual ICollection<Domain.Models.CRM.Deal.Deal>  Deals { get; set; }
    
    public Customer()
    {
        Leads = new HashSet<Domain.Models.CRM.Lead.Lead>();
        Activities = new HashSet<Domain.Models.CRM.Activity.Activity>();
    }

    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}
