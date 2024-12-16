using Domain.Entities;
using Domain.Repositories;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Shared.Pagination;

namespace Persistence.Repositories;

internal sealed class DogRepository(AppDbContext context) : IDogRepository
{
    private readonly AppDbContext _context = context;

    public async Task<PagedList<Breed>> GetBreedsAsync(
        PaginateQuery paginate,
        Func<Breed, bool>? filter = null,
        CancellationToken cancellationToken = default)
            => await _context.Set<Breed>()
                .OrderBy(b => b.Attributes.BreedName)
                .ToPagedListAsync(paginate, filter, cancellationToken);

    public async Task<Breed?> GetBreedByIdAsync(Guid breedId, CancellationToken cancellationToken = default)
        => await _context.Set<Breed>().FirstOrDefaultAsync(
            b => b.Id == breedId,
            cancellationToken);

    public void AddBreed(Breed breed)
        => _context.Set<Breed>().Add(breed);

    public void UpdateBreed(Breed breed)
        => _context.Set<Breed>().Update(breed);

    public async Task BulkInsertBreedsAsync(IEnumerable<Breed> breeds)
        => await _context.BulkInsertAsync(breeds);
}
