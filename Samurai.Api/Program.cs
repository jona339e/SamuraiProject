using Microsoft.EntityFrameworkCore;
using Samurai.Api;
using Samurai.Repo.Data;
using Samurai.Repo.Interfaces;
using Samurai.Repo.Repositories;
using Samurai.Repo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddCors(options =>
{
    var allowedOrigins = "*";

    options.AddDefaultPolicy(policy =>
    {

        policy.WithOrigins(allowedOrigins)
              .WithHeaders("Content-Type", "Authorization", "Access-Control-Allow-Headers", "Access-Control-Allow-Origin")
              .WithMethods("GET", "POST", "PUT", "DELETE", "PATCH");
    });
});



builder.Services.AddScoped<ISamuraiRepository, SamuraiRepository>();
builder.Services.AddScoped<IKrigerRepository, KrigerRepository>();
builder.Services.AddScoped<ICoffeeRepository, CoffeeRepository>();
builder.Services.AddScoped<ITasteRepository, TasteRepository>();

builder.Services.AddScoped<IMappingService, MappingService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();





