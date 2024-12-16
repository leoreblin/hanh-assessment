using Domain.Entities;
using MediatR;
using Shared.Pagination;

namespace Application.Dogs.GetBreeds;

public readonly record struct GetBreedsQuery(
    GetBreedsQueryData QueryData) : IRequest<PagedList<Breed>>;
