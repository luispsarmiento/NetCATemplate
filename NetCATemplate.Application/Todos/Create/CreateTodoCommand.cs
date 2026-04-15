using NetCATemplate.Application.Abstractions.Messaging;
using NetCATemplate.Application.Todos.Get;
using NetCATemplate.Domain.Todos;

namespace NetCATemplate.Application.Todos.Create
{
    public sealed class CreateTodoCommand : ICommand<TodoResponse>
    {
        public required string Title { get; set; }
        public required Priority Priority { get; set; }
    }
}
