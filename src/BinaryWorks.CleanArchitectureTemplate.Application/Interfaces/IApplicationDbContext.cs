using Microsoft.EntityFrameworkCore;
using BinaryWorks.CleanArchitectureTemplate.Domain.Entities;

namespace BinaryWorks.CleanArchitectureTemplate.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ApplicationUser> ApplicationUsers { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}