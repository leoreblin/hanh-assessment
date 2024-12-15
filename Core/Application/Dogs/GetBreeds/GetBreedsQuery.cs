using Domain.Entities;
using MediatR;

namespace Application.Dogs.GetBreeds;

public readonly record struct GetBreedsQuery : IRequest<IEnumerable<Breed>>;
