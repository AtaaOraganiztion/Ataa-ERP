using Domain.Models;
using SharedKernel.Common;
using System;
using SharedKernel;

namespace Domain.Models.Finance.Order
{
    public class Order : Entity,ISoftDeletableEntity
    {
        public decimal Price { get; set; }
        public int SectorNumber { get; set; }
        public Ulid SectorId { get; set; }

        public virtual Sector.Sector? Sector { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}