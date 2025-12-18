using NetCATemplate.Application.Abstractions.Messaging;
using NetCATemplate.Application.Todos.Get;
using NetCATemplate.SharedKernel;
using NetCATemplate.WebApi.Extensions;
using NetCATemplate.WebApi.Infrastructure;

namespace NetCATemplate.WebApi.Endpoints.Todos;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("todos", async (
            IQueryHandler<GetTodosQuery, List<TodoResponse>> handler,
            CancellationToken cancellationToken) =>
        {
            var query = new GetTodosQuery();

            Result<List<TodoResponse>> result = await handler.Handle(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Todos);
    }
}
