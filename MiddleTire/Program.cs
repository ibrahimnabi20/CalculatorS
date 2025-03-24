using Microsoft.AspNetCore.Mvc;
using MiddleTire.Data;
using MiddleTire.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddScoped<CalculatorRepoMariaDb>();
builder.Services.AddDbContext<MariaDbContext>();

var app = builder.Build();
app.UseCors("AllowAll");

app.MapPost("/api/calculate", async ([FromBody] CalculatorOperation calcOperation, CalculatorRepoMariaDb repo) => await repo.Calculate(calcOperation));
app.MapGet("/api/history", async (CalculatorRepoMariaDb repo) => await repo.GetCalculatorOperations());

await app.RunAsync();