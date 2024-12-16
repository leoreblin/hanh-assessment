namespace Application.Dogs.GetBreeds;

public record GetBreedsQueryData
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public string? Name { get; set; }

    public GetBreedsQueryData()
    {
        PageNumber = 1;
        PageSize = 10;
        Name = string.Empty;
    }
}
