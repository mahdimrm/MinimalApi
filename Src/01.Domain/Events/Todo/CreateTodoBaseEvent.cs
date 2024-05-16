using Entities;

namespace Events
{
    public class CreateTodoBaseEvent : BaseEvent
    {
        public CreateTodoBaseEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
