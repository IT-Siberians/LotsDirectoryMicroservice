using LotDesignerMicroservice.Application.Services.Base;
using LotDesignerMicroservice.Application.Services.Implementations;
using LotDesignerMicroservice.Application.Services.Mapper;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Infrastructure.EfRepository;
using LotDesignerMicroservice.Infrastructure.EfRepository.Repositories;
using LotDesignerMicroservice.Presentation.WebApi.Mapper;
using Microsoft.EntityFrameworkCore;
using LotDesignerMicroservice.Presentation.WebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string for ApplicationDbContext is not configured.");
        }

        options.UseNpgsql(connectionString);
    });

builder.Services.AddScoped<ISellersService, SellersService>();
builder.Services.AddScoped<ISellersRepository, EfSellersRepository>();

builder.Services.AddScoped<IImagesService, ImagesService>();
builder.Services.AddScoped<IImagesRepository, EfImagesRepository>();

builder.Services.AddScoped<ILotsCardsService, LotsCardsService>();
builder.Services.AddScoped<ILotsCardsRepository, EfLotsCardsRepository>();

builder.Services.AddAutoMapper(typeof(PresentationMapperProfile), typeof(ApplicationMapperProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MigrateDatabase<ApplicationDbContext>();

app.MapControllers();

app.Run();