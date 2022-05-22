using AutoMapper;
using Mango.Services.ProductAPI.AutoMapperProfile;
using Mango.Services.ProductAPI.DBContext;
using Mango.Services.ProductAPI.Repository.Interfaces;
using Mango.Services.ProductAPI.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
// Add services to the container.


//AutoMapper Registration
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add DBLayer Services
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
