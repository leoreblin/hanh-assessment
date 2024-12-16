using Domain.Primitives;

namespace Domain.Entities;

public sealed class Breed : Entity
{
    public string Type { get; private set; }

    public BreedAttributes Attributes { get; private set; }

    public Breed(Guid id, string type, BreedAttributes attributes)
        : base(id)
    {
        Type = type;
        Attributes = attributes;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Breed"/> class.
    /// </summary>
    /// <remarks>Used by EF Core.</remarks>
#pragma warning disable CS8618
    private Breed() { }
#pragma warning restore CS8618

    public void Update(Breed updatedBreed)
    {
        Type = updatedBreed.Type;
        Attributes = updatedBreed.Attributes;
    }
}
