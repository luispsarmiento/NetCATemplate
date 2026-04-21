using NetCATemplate.Domain.Todos;

namespace NetCATemplate.WebApi.Endpoints.Todos
{
    public class UpdateTodoItemRequest
    {
        public required string Title { get; set; }
        public DateOnly DueBy { get; set; }
        public bool IsComplete { get; set; }
        public required Priority Priority { get; set; }
    }
}
