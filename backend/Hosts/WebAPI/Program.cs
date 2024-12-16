using Application.Abstractions.Context;
using Application.Contracts.Services;
using Hangfire;
using HangfireJobs.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Extensions;
using Rest.DogApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddScoped<IDataSeeder, AppDbContextSeeder>();

builder.Services.AddHttpClient<IDogApiService, DogApiService>(client =>
{
    client.BaseAddress = new Uri("https://dogapi.dog/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

builder.Services.AddHangfireJobs(builder.Configuration);

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
dbContext.Database.Migrate();

app.UseHangfireDashboard();
app.MapGet("/", () => "Web API is running with Hangfire dashboard.");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var services = scope.ServiceProvider;
	try
	{
		var dataSeeder = services.GetRequiredService<IDataSeeder>();
		await dataSeeder.SeedAsync();
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "An error has occurred while seeding the database.");
		throw;
	}
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
