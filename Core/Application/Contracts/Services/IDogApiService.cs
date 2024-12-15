using Domain.Entities;

namespace Application.Contracts.Services;

public interface IDogApiService
{
    Task<IEnumerable<Breed>> GetBreedsAsync(CancellationToken cancellationToken = default);
}
