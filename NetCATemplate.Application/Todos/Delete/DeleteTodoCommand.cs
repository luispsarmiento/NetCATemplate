
using NetCATemplate.Application.Abstractions.Messaging;

public sealed class DeleteTodoCommand : ICommand<Guid>
{
    public Guid Id { get; set; }
}
