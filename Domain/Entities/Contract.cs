using System;
using Domain.Enums;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class Contract : BaseEntity
    {
        public string ContractNumber { get; set; }
        public string Name { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid SectorId { get; set; }
        public ContractType ContractType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal ContractValue { get; set; }
        public ContractStatus Status { get; set; }
        public string Terms { get; set; }
        public Guid? SignedBy { get; set; }
        public DateTime? SignedDate { get; set; }
        public string Notes { get; set; }

        public virtual Project Project { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual User Signer { get; set; }
    }
}
