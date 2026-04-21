using NetCATemplate.Application.Abstractions.Messaging;
using NetCATemplate.Application.Todos.Get;
using NetCATemplate.Domain.Todos;
using System.Windows.Input;

public sealed class UpdateTodoCommand : ICommand<TodoResponse>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateOnly DueBy { get; set; }
    public bool IsComplete { get; set; }
    public Priority Priority { get; set; }
}
