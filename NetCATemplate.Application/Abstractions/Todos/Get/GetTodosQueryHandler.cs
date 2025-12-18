using NetCATemplate.Application.Abstractions.Messaging;
using NetCATemplate.Application.Todos.Get;
using NetCATemplate.SharedKernel;

namespace NetCATemplate.Application.Todos.Get;

internal sealed class GetTodosQueryHandler()
    : IQueryHandler<GetTodosQuery, List<TodoResponse>>
{
    public async Task<Result<List<TodoResponse>>> Handle(GetTodosQuery query, CancellationToken cancellationToken)
    {
        var sampleTodos = new List<TodoResponse> {
            new TodoResponse
            {
                Id = 1, 
                Title = "Walk the dog"
            },
            new TodoResponse
            {
                Id = 2, 
                Title = "Do the dishes", 
                DueBy = DateOnly.FromDateTime(DateTime.Now)
            },
            new TodoResponse
            {
                Id = 3,
                Title = "Do the laundry", 
                DueBy = DateOnly.FromDateTime(DateTime.Now.AddDays(1))
            },
            new TodoResponse
            {
                Id = 4,
                Title = "Clean the bathroom"
            },
            new TodoResponse
            {
                Id = 5,
                Title = "Clean the car", 
                DueBy = DateOnly.FromDateTime(DateTime.Now.AddDays(2))
            }
        };
        await Task.CompletedTask;
        return sampleTodos;
    }
}
