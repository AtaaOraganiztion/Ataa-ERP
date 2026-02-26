using System;

namespace SharedKernel.Common
{
    public abstract class BaseEntity
    {
        public Ulid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        protected BaseEntity()
        {
            Id = Ulid.NewUlid();
            CreatedDate = DateTime.UtcNow;
            IsDeleted = false;
        }
    }
}
