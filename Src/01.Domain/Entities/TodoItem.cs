namespace Entities
{
    public record TodoItem : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
