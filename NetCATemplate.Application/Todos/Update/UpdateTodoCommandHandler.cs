using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NetCATemplate.Application.Abstractions.Data;
using NetCATemplate.Application.Abstractions.Messaging;
using NetCATemplate.Application.Todos.Get;
using NetCATemplate.Domain.Todos;
using NetCATemplate.SharedKernel;

public sealed class UpdateTodoCommandHandler(
    IApplicationDbContext dbContext, IValidator<UpdateTodoCommand> validator) : ICommandHandler<UpdateTodoCommand, TodoResponse>
{
    public async Task<Result<TodoResponse>> Handle(UpdateTodoCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            var error = validationResult.Errors.First();
            return Result.Failure<TodoResponse>(
                Error.Failure(error.PropertyName, error.ErrorMessage));
        }

        TodoItem? existingTodo = await dbContext.TodoItems.FirstOrDefaultAsync(t => t.Id == command.Id, cancellationToken);

        if (existingTodo is null)
        {
            var error = new Error("TodoNotFound", $"Todo with id {command.Id} was not found.", ErrorType.NotFound);
            return Result<TodoResponse>.ValidationFailure(error);
        }

        existingTodo.Description = command.Title;
        existingTodo.DueDate = command.DueBy.ToDateTime(new TimeOnly(0, 0));
        existingTodo.IsCompleted = command.IsComplete;
        existingTodo.Priority = command.Priority;

        dbContext.TodoItems.Update(existingTodo);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new TodoResponse
        {
            Id = existingTodo.Id,
            Title = existingTodo.Description,
            DueBy = existingTodo.DueDate.HasValue ? DateOnly.FromDateTime(existingTodo.DueDate.Value) : null,
            IsComplete = existingTodo.IsCompleted,
            Priority = existingTodo.Priority
        };
    }
}
