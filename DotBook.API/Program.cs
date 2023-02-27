using DotBook.Application.Commands.CreatePublication;
using DotBook.Core.Repositories;
using DotBook.Infrastructure.Persistance;
using DotBook.Infrastructure.Persistance.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//SqlServer
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DotBookDbContext>(
        options => options.UseSqlServer(connection));

//Repositories
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers()
    .AddJsonOptions(options => options
    .JsonSerializerOptions
    .ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MediatR
builder.Services.AddMediatR(typeof(CreatePublicationCommand));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
