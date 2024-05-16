using Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public record BaseEntity : BaseEventCommands
    {
        protected BaseEntity()
        {
            InsertDateTime = DateTime.Now;
            IsActive = true;
        }

        public Guid Id { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public DateTime InsertDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteDateTime { get; set; }        
    }
}
