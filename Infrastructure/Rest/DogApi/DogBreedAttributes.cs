using Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace Rest.DogApi;

public sealed record DogBreedAttributes(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("life")] ValueRange LifeRange,
    [property: JsonPropertyName("male_weight")] ValueRange MaleWeightRange,
    [property: JsonPropertyName("female_weight")] ValueRange FemaleWeightRange,
    [property: JsonPropertyName("hypoallergenic")] bool Hypoallergenic
);
