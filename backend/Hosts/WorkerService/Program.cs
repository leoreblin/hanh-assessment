using Application.Contracts.Services;
using HangfireJobs.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Extensions;
using Rest.DogApi;
using WorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<DogBreedsWorker>();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddHttpClient<IDogApiService, DogApiService>(client =>
{
    client.BaseAddress = new Uri("https://dogapi.dog/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHangfireJobs(builder.Configuration);

var host = builder.Build();

using var scope = host.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
dbContext.Database.Migrate();

host.Run();
