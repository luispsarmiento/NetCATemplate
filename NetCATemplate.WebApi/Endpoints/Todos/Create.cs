using NetCATemplate.Application.Abstractions.Messaging;
using NetCATemplate.Application.Todos.Create;
using NetCATemplate.Application.Todos.Get;
using NetCATemplate.SharedKernel;
using NetCATemplate.WebApi.Endpoints;
using NetCATemplate.WebApi.Endpoints.Todos;
using NetCATemplate.WebApi.Extensions;
using NetCATemplate.WebApi.Infrastructure;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("todos", async (
            CreateTodoItemRequest request,
            ICommandHandler<CreateTodoCommand, TodoResponse> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateTodoCommand
            {
                Title = request.Title,
                Priority = request.Priority,
            };

            Result<TodoResponse> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Todos);
    }
}
