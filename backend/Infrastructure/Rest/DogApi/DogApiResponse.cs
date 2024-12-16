using System.Text.Json.Serialization;

namespace Rest.DogApi;

public sealed record DogApiResponse(
    [property: JsonPropertyName("data")] List<DogApiBreed> Data,
    [property: JsonPropertyName("links")] DogApiResponseLinks Links
);
