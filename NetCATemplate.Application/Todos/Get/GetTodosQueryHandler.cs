using Microsoft.EntityFrameworkCore;
using NetCATemplate.Application.Abstractions.Data;
using NetCATemplate.Application.Abstractions.Messaging;
using NetCATemplate.Application.Todos.Get;
using NetCATemplate.SharedKernel;

namespace NetCATemplate.Application.Todos.Get;

internal sealed class GetTodosQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTodosQuery, List<TodoResponse>>
{
    public async Task<Result<List<TodoResponse>>> Handle(GetTodosQuery query, CancellationToken cancellationToken)
    {
        var sampleTodos = await dbContext.TodoItems
            .Select(x => new TodoResponse
            {
                Id = x.Id,
                Title = x.Description,
                DueBy = x.DueDate.HasValue ? DateOnly.FromDateTime(x.DueDate.Value) : null,
                IsComplete = x.IsCompleted
            })
            .ToListAsync(cancellationToken);

        return sampleTodos;
    }
}
