using Domain.Models;
using SharedKernel.Common;
using System;


namespace Domain.Models.Finance.ProcureToPay
{
    public class ProcureToPay : BaseEntity
    {
        public decimal ProcureAmount { get; set; }
        public decimal UpdateBudget { get; set; }
        public Guid SectorId { get; set; }

        public virtual Sector.Sector? Sector { get; set; }
    }
}