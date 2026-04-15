using NetCATemplate.Domain.Todos;

namespace NetCATemplate.WebApi.Endpoints.Todos
{
    public sealed class CreateTodoItemRequest
    {
        public required string Title { get; set; }
        public required Priority Priority { get; set; }
    }
}
