namespace Application.Abstractions.Context;

public interface IDataSeeder
{
    Task SeedAsync(CancellationToken cancellationToken = default);
}
