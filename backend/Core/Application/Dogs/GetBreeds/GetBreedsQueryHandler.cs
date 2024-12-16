using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Shared.Pagination;

namespace Application.Dogs.GetBreeds;

internal sealed class GetBreedsQueryHandler(IDogRepository dogRepository) 
    : IRequestHandler<GetBreedsQuery, PagedList<Breed>>
{
    private readonly IDogRepository _dogRepository = dogRepository;

    public async Task<PagedList<Breed>> Handle(GetBreedsQuery request, CancellationToken cancellationToken)
    {
        var paginateQuery = new PaginateQuery
        {
            Page = request.QueryData.PageNumber,
            Size = request.QueryData.PageSize
        };

        Func<Breed, bool>? filter = !string.IsNullOrWhiteSpace(request.QueryData.Name) ?
            b => b.Attributes.BreedName.Contains(request.QueryData.Name, StringComparison.CurrentCultureIgnoreCase)
              : null;

        return await _dogRepository.GetBreedsAsync(paginateQuery, filter, cancellationToken);
    }
}
