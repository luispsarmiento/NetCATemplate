using FluentValidation;
using NetCATemplate.Application.Todos.Create;
using NetCATemplate.Domain.Todos;

namespace UnitTestingPoC.Application.Orders.Create
{
    public sealed class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator()
        {
            RuleFor(command => command.Title)
                .NotEmpty().WithMessage(TodoItemErrors.InvalidTitle().Description);
        }
    }
}
