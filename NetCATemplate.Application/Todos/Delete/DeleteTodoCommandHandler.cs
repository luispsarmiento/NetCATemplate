using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NetCATemplate.Application.Abstractions.Data;
using NetCATemplate.Application.Abstractions.Messaging;
using NetCATemplate.Domain.Todos;
using NetCATemplate.SharedKernel;

public sealed class DeleteTodoCommandHandler(
    IApplicationDbContext dbContext, IValidator<DeleteTodoCommand> validator) : ICommandHandler<DeleteTodoCommand, Guid>
{
    public async Task<Result<Guid>> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errorValidation = validationResult.Errors.First();
            var error = new Error(errorValidation.PropertyName, errorValidation.ErrorMessage, ErrorType.Validation);
            return Result<Guid>.ValidationFailure(error);
        }

        TodoItem? existingTodo = await dbContext.TodoItems.FirstOrDefaultAsync(o => o.Id == command.Id, cancellationToken);

        if (existingTodo is null)
        {
            var error = new Error("TodoNotFound", $"Todo with id {command.Id} was not found.", ErrorType.NotFound);
            return Result<Guid>.ValidationFailure(error);
        }

        dbContext.TodoItems.Remove(existingTodo);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Guid.Empty;
    }
}
