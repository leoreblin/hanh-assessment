using Application.Abstractions.Data;
using Application.Contracts.Services;
using Domain.Entities;
using Domain.Repositories;

namespace HangfireJobs.Jobs;

public class DogBreedsUpsertJob(
    IDogRepository dogRepository,
    IDogApiService dogApiService,
    IUnitOfWork unitOfWork)
{
    private readonly IDogRepository _dogRepository = dogRepository;
    private readonly IDogApiService _dogApiService = dogApiService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        string path = $"api/v2/breeds";
        await foreach (var breed in _dogApiService.GetBreedsAsync(path, cancellationToken))
        {
            Breed? existingBreed = await _dogRepository.GetBreedByIdAsync(breed.Id, cancellationToken);
            if (existingBreed is null)
            {
                _dogRepository.AddBreed(breed);
            }
            else
            {
                existingBreed.Update(breed);
                _dogRepository.UpdateBreed(existingBreed);
            }
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
