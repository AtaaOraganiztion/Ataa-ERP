using System;
using Domain.Entities;
using Domain.Enums;
using Domain.Models.Attendance.Enums;
using SharedKernel;
using SharedKernel.Common;

namespace Domain.Models.Adverisment
{
    public class Adverisment : Entity, ISoftDeletableEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public DateTime? StartDate {  get; set; }
        public DateTime? EndDate { get; set; }
        public Ulid? CreatedByUserId {  get; set; }
        public string? Url { get; set; } = string.Empty;

        public virtual User? User { get; set; }
        public ICollection<AdverismentFile>? Files { get; set; } = new List<AdverismentFile>();

        public class AdverismentFile : Entity
        {
            public Ulid AdverismentId { get; set; }
            public string? FileName { get; set; } = string.Empty;
            public string? StoragePath { get; set; } = string.Empty;
            public string? ContentType { get; set; } = string.Empty;
            public long? FileSizeInBytes { get; set; }
            public DateTime? UploadedAtUtc { get; set; }
            public Ulid? CreatedByUserId { get; set; }

            public virtual Adverisment? Adverisment { get; set; }
            public virtual User? User { get; set; }
        }

        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}
