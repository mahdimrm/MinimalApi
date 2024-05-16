using Entities;

namespace Events.Todo
{
    public class DeleteTodoBaseEvent : BaseEvent
    {
        public DeleteTodoBaseEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
