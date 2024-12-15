using Application.Contracts.Services;
using Persistence.Extensions;
using Rest.DogApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddHttpClient<IDogApiService, DogApiService>(client =>
{
    client.BaseAddress = new Uri("https://dogapi.dog/api/v2/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
