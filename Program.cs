using BookApi.Context;
using BookApi.Interface;
using BookApi.Interfaces;
using BookApi.Model;
using BookApi.Services;
using inventoryApiDotnet.Repository;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookservice,Bookservice>();
builder.Services.AddScoped<IMongoContext, MongoContext>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));

BsonSerializer.RegisterIdGenerator(typeof(string), new StringObjectIdGenerator());

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
