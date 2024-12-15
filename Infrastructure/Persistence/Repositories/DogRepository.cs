using Domain.Entities;
using Domain.Repositories;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

internal sealed class DogRepository(AppDbContext context) : IDogRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Breed>> GetBreedsAsync()
     => await _context.Set<Breed>().ToListAsync();


    public async Task BulkInsertBreedsAsync(IEnumerable<Breed> breeds)
        => await _context.BulkInsertAsync(breeds);
}
