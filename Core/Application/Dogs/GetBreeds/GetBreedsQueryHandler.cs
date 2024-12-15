using Application.Contracts.Services;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Dogs.GetBreeds;

internal sealed class GetBreedsQueryHandler(
    IDogRepository dogRepository,
    IDogApiService dogApiService) 
    : IRequestHandler<GetBreedsQuery, IEnumerable<Breed>>
{
    private readonly IDogRepository _dogRepository = dogRepository;
    private readonly IDogApiService _dogApiService = dogApiService;

    public async Task<IEnumerable<Breed>> Handle(GetBreedsQuery request, CancellationToken cancellationToken)
    {
        var breedsFromDb = await _dogRepository.GetBreedsAsync();

        if (breedsFromDb.Any())
        {
            return breedsFromDb;
        }

        var breedsFromApi = await _dogApiService.GetBreedsAsync(cancellationToken);

        if (breedsFromApi.Any())
        {
            return breedsFromApi;
        }

        return [];
    }
}
