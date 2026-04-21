using NetCATemplate.Application.Abstractions.Messaging;
using NetCATemplate.SharedKernel;
using NetCATemplate.WebApi.Endpoints;
using NetCATemplate.WebApi.Extensions;
using NetCATemplate.WebApi.Infrastructure;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("Todos/{id:guid}", async (
            Guid id,
            ICommandHandler<DeleteTodoCommand, Guid> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new DeleteTodoCommand { Id = id };

            Result<Guid> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Todos);
    }
}
