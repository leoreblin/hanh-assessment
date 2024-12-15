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
        bool hypoallergenic)
    {
        BreedName = breedName;
        BreedDescription = description;
        LifeRange = lifeRange;
        MaleWeightRange = maleWeight;
        FemaleWeightRange = femaleWeight;
        Hypoallergenic = hypoallergenic;
    }

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
