using Domain.Entities;

namespace Domain.Repositories;

public interface IDogRepository
{
    Task<IEnumerable<Breed>> GetBreedsAsync();

    Task BulkInsertBreedsAsync(IEnumerable<Breed> breeds);
}
