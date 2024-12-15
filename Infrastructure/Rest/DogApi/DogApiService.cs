using Application.Contracts.Services;
using Domain.Entities;
using System.Net.Http.Json;

namespace Rest.DogApi;

public sealed class DogApiService(HttpClient httpClient) : IDogApiService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IEnumerable<Breed>> GetBreedsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetFromJsonAsync<DogApiResponse>("breeds", cancellationToken);

        if (response?.Data is null)
        {
            return [];
        }

        return response.Data.Select(data =>
        {
            Domain.Entities.BreedAttributes attributes = BreedAttributes.Create(
                data.Attributes.Name, data.Attributes.Description, data.Attributes.LifeRange,
                data.Attributes.MaleWeightRange, data.Attributes.FemaleWeightRange,
                data.Attributes.Hypoallergenic);

            return new Breed(Guid.Parse(data.Id), data.Type, attributes);
        });
    }
}
