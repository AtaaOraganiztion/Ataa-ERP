using Domain.Models;
using SharedKernel.Common;
using System;

namespace Domain.Models.Finance.Order
{
    public class Order : BaseEntity
    {
        public decimal Price { get; set; }
        public int SectorNumber { get; set; }
        public Guid SectorId { get; set; }

        public virtual Sector.Sector? Sector { get; set; }
    }
}