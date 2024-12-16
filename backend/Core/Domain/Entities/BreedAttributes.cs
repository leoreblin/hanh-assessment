using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class BreedAttributes
{
    public string BreedName { get; }

    public string? BreedDescription { get; }

    public ValueRange LifeRange { get; }

    public ValueRange MaleWeightRange { get; }

    public ValueRange FemaleWeightRange { get; }

    public bool Hypoallergenic { get; }

    private BreedAttributes(
        string breedName,
        string description,
        ValueRange lifeRange,
        ValueRange maleWeight,
        ValueRange femaleWeight,
        bool hypoallergenic) : this()
    {
        BreedName = breedName;
        BreedDescription = description;
        LifeRange = lifeRange;
        MaleWeightRange = maleWeight;
        FemaleWeightRange = femaleWeight;
        Hypoallergenic = hypoallergenic;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BreedAttributes"/> class.
    /// </summary>
    /// <remarks>Used by EF Core.</remarks>
#pragma warning disable CS8618
    private BreedAttributes() { }
#pragma warning restore CS8618

    public static BreedAttributes Create(
        string breedName,
        string description,
        ValueRange lifeRange,
        ValueRange maleWeight,
        ValueRange femaleWeight,
        bool hypoallergenic)
    {
        if (string.IsNullOrWhiteSpace(breedName))
        {
            throw new ArgumentException("Breed name is required", nameof(breedName));
        }

        return new(breedName, description, lifeRange, maleWeight, femaleWeight, hypoallergenic);
    }
}
