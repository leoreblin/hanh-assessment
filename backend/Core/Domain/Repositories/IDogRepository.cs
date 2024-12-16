using Domain.Entities;
using Shared.Pagination;

namespace Domain.Repositories;

public interface IDogRepository
{
    Task<PagedList<Breed>> GetBreedsAsync(
        PaginateQuery paginate,
        Func<Breed, bool>? filter = null,
        CancellationToken cancellationToken = default);

    Task<Breed?> GetBreedByIdAsync(Guid breedId, CancellationToken cancellationToken = default);

    void AddBreed(Breed breed);

    void UpdateBreed(Breed breed);

    Task BulkInsertBreedsAsync(IEnumerable<Breed> breeds);
}
