using Microsoft.EntityFrameworkCore;
using NetCATemplate.Domain.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCATemplate.Application.Abstractions.Data
{
    public interface IApplicationDbContext
    {
        DbSet<TodoItem> TodoItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
