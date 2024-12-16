using Application.Contracts.Services;
using Domain.Entities;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace Rest.DogApi;

public sealed class DogApiService(HttpClient httpClient) : IDogApiService
{
    private readonly HttpClient _httpClient = httpClient;

    public async IAsyncEnumerable<Breed> GetBreedsAsync(
        string path,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        string? nextPage = path;

        do
        {
            var response = await _httpClient.GetFromJsonAsync<DogApiResponse>(nextPage, cancellationToken);

            if (response?.Data is null)
            {
                yield break;
            }

            foreach (var data in response.Data)
            {
                Domain.Entities.BreedAttributes attributes = BreedAttributes.Create(
                    data.Attributes.Name, data.Attributes.Description, data.Attributes.LifeRange,
                    data.Attributes.MaleWeightRange, data.Attributes.FemaleWeightRange,
                    data.Attributes.Hypoallergenic);

                yield return new Breed(Guid.Parse(data.Id), data.Type, attributes);
            }
            nextPage = response.Links?.NextUrl;
        } while (!string.IsNullOrEmpty(nextPage));
    }
}
