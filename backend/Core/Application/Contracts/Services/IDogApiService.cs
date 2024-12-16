using Domain.Entities;

namespace Application.Contracts.Services;

public interface IDogApiService
{
    IAsyncEnumerable<Breed> GetBreedsAsync(string path, CancellationToken cancellationToken = default);
}
