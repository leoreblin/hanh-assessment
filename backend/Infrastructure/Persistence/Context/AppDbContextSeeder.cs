using Application.Abstractions.Context;
using Application.Contracts.Services;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class AppDbContextSeeder(
    AppDbContext context,
    IDogApiService dogApiService) : IDataSeeder
{
    private readonly AppDbContext _context = context;
    private readonly IDogApiService _dogApiService = dogApiService;

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        if (await _context.Breeds.AnyAsync(cancellationToken))
        {
            return;
        }

        const int maxBreedsToSeed = 10;
        int breedsAdded = 0;

        string initialPath = "api/v2/breeds";

        await foreach (var breed in _dogApiService.GetBreedsAsync(initialPath, cancellationToken))
        {
            if (breedsAdded >= maxBreedsToSeed)
            {
                break;
            }

            _context.Breeds.Add(breed);
            breedsAdded++;
        }

        if (breedsAdded > 0)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
