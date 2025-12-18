using NetCATemplate.SharedKernel;

namespace NetCATemplate.Domain.Todos;

public sealed record TodoItemDeletedDomainEvent(Guid TodoItemId) : IDomainEvent;
