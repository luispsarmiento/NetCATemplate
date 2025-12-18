using NetCATemplate.SharedKernel;

namespace NetCATemplate.Domain.Todos;

public sealed record TodoItemCreatedDomainEvent(Guid TodoItemId) : IDomainEvent;
