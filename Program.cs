using AdventureWorksGraphQLAPI.Data;
using AdventureWorksGraphQLAPI.Models;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using HotChocolate.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//builder.Services.AddDbContext<AdventureWorks2022Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddPooledDbContextFactory<AdventureWorks2022Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));


builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .RegisterDbContextFactory<AdventureWorks2022Context>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");

app.Run();
