using System.Text.Json.Serialization;

namespace Rest.DogApi;

public sealed record DogApiBreed(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("attributes")] DogBreedAttributes Attributes
);
