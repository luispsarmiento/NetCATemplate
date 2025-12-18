using NetCATemplate.Application.Abstractions.Messaging;

namespace NetCATemplate.Application.Todos.Get;

public sealed record GetTodosQuery() : IQuery<List<TodoResponse>>;
