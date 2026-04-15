using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NetCATemplate.Application.Abstractions.Data;
using NetCATemplate.Application.Abstractions.Messaging;
using NetCATemplate.Application.Todos.Create;
using NetCATemplate.Application.Todos.Get;
using NetCATemplate.Domain.Todos;
using NetCATemplate.SharedKernel;

namespace UnitTestingPoC.Application.Todos.Create;

public sealed class CreateTodoCommandHandler(
    IApplicationDbContext dbContext, IValidator<CreateTodoCommand> validator) : ICommandHandler<CreateTodoCommand, TodoResponse>
{
    public async Task<Result<TodoResponse>> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            var error = validationResult.Errors.First();
            return Result.Failure<TodoResponse>(
                Error.Failure(error.PropertyName, error.ErrorMessage));
        }

        var todo = new TodoItem
        {
            Id = Guid.NewGuid(),
            Description = command.Title,
            CreatedAt = DateTime.Now,
            Priority = command.Priority
        };

        TodoItem? existingTodo = await dbContext.TodoItems.FirstOrDefaultAsync(o => o.Description == command.Title, cancellationToken);
       
        if (existingTodo != null) {
            return Result.Failure<TodoResponse>(TodoItemErrors.AlreadyExists(existingTodo.Id));
        }

        todo.Raise(new TodoItemCreatedDomainEvent(todo.Id));

        dbContext.TodoItems.Add(todo);

        await dbContext.SaveChangesAsync(cancellationToken);

        var response = new TodoResponse
        {
            Id = todo.Id,
            Title = todo.Description,
            DueBy = todo.DueDate.HasValue ? DateOnly.FromDateTime(todo.DueDate.Value) : null,
            Priority = todo.Priority
        };

        return response;
    }
}
