using NetCATemplate.Application.Abstractions.Messaging;
using NetCATemplate.Application.Todos.Get;
using NetCATemplate.SharedKernel;
using NetCATemplate.WebApi.Endpoints;
using NetCATemplate.WebApi.Extensions;
using NetCATemplate.WebApi.Infrastructure;

namespace NetCATemplate.WebApi.Endpoints.Todos;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("Todos/{id:guid}", async (
            Guid id,
            UpdateTodoItemRequest request,
            ICommandHandler<UpdateTodoCommand, TodoResponse> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateTodoCommand
            {
                Id = id,
                Title = request.Title,
                DueBy = request.DueBy,
                IsComplete = request.IsComplete,
                Priority = request.Priority
            };

            Result<TodoResponse> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Todos);
    }
}
