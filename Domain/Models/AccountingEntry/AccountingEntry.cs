using System;
using SharedKernel;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class AccountingEntry : Entity,ISoftDeletableEntity
    {
        public string EntryNumber { get; set; } = null!;
        public DateTime EntryDate { get; set; }
        public string AccountCode { get; set; }=null!;
        public string Description { get; set; } = null!;
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public Guid? ReferenceId { get; set; }
        public string ReferenceType { get; set; } = null!;
        public Guid? AccountingManagerId { get; set; }

        public virtual User? AccountingManager { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}