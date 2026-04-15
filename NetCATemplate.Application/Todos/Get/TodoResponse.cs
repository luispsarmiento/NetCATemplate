using NetCATemplate.Domain.Todos;

namespace NetCATemplate.Application.Todos.Get;

public sealed class TodoResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; } 
    public DateOnly? DueBy { get; set; }
    public bool IsComplete {  get; set; }
    public Priority Priority { get; set; }
};
