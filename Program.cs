using bookApi.Data;
using bookApi.Models;
using bookApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BookRepo>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<MongoDbContext>(builder.Configuration.GetSection("MongoDbContext"));
builder.Services.AddScoped<MongoContext>();
builder.Services.AddScoped<MongoBookRepo>();
builder.Services.AddDbContext<DataContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

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
