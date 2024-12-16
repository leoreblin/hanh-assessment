using Application.Abstractions.Data;
using Persistence.Context;

namespace Persistence.Data;

/// <summary>
/// Represents the unit of work.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UnitOfWork"/> class.
/// </remarks>
/// <param name="context">The application database context.</param>
public sealed class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    /// <inheritdoc />
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
