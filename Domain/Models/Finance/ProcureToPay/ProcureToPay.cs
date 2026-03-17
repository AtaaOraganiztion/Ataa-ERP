using Domain.Models;
using SharedKernel.Common;
using System;
using SharedKernel;


namespace Domain.Models.Finance.ProcureToPay
{
    public class ProcureToPay : Entity,ISoftDeletableEntity
    {
        public decimal ProcureAmount { get; set; }
        public decimal UpdateBudget { get; set; }
        public Ulid SectorId { get; set; }

        public virtual Sector.Sector? Sector { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}