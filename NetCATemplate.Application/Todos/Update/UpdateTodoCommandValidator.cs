
using FluentValidation;

namespace NetCATemplate.Application.Todos.Update
{
    public sealed class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
    {
        public UpdateTodoCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(100)
                .WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.DueBy)
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage("Due date must be in the future.");

             RuleFor(x => x.Priority)
                .IsInEnum()
                .WithMessage("Priority must be a valid value.");
        }
    }
}
