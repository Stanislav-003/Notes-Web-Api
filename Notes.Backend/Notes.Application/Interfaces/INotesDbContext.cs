using Microsoft.EntityFrameworkCore;
using System;
using Notes.Domain;
using System.Threading.Tasks;
using System.Threading;

namespace Notes.Application.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
