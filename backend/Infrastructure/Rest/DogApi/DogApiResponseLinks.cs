using System.Text.Json.Serialization;

namespace Rest.DogApi;

public sealed record DogApiResponseLinks(
    [property: JsonPropertyName("self")] string SelfUrl,
    [property: JsonPropertyName("current")] string CurrentUrl,
    [property: JsonPropertyName("first")] string FirstUrl,
    [property: JsonPropertyName("prev")] string? PreviousUrl,
    [property: JsonPropertyName("next")] string? NextUrl,
    [property: JsonPropertyName("last")] string? LastUrl
);
