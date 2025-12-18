using NetCATemplate.SharedKernel;

namespace NetCATemplate.Domain.Todos;

public sealed record TodoItemCompletedDomainEvent(Guid TodoItemId) : IDomainEvent;
