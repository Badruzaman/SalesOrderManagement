using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Repositories;
using SalesOrderManagement.Api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SalesOrderDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SalesOrderDbConnection")));
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddScoped<IDimensionRepository, DimensionRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy=> policy.WithOrigins("https://localhost:7256", "http://localhost:7256").AllowAnyMethod().WithHeaders(HeaderNames.ContentType));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
