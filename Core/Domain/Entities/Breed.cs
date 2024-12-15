using Domain.Primitives;

namespace Domain.Entities;

public sealed class Breed(Guid id, string type, BreedAttributes attributes)
    : Entity(id)
{
    public string Type { get; } = type;

    public BreedAttributes Attributes { get; } = attributes;
}
