using AutoMapper;
using Microsoft.EntityFrameworkCore;
using service.Data;
using service.Mapper;
using service.Repository;
using service.Repository.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// connection string ,config database Postgres
var connectionString = $"";
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

// add dependency injection
builder.Services.AddScoped<IProductRepo,ProductRepo>();

// add mapper config
IMapper mapper = MapperConfig.RegisterMap().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
