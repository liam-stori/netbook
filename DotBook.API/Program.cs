using DotBook.Application.Commands.CreatePublication;
using DotBook.Application.Filters;
using DotBook.Application.Validators;
using DotBook.Core.Mappings;
using DotBook.Core.Repositories;
using DotBook.Infrastructure.Persistance;
using DotBook.Infrastructure.Persistance.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

//SqlServer
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DotBookDbContext>(
        options => options.UseSqlServer(connection));

//Repositories
builder.Services.AddScoped<ICommentRepository, CommentsRepository>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers(
    options => options
    .Filters
    .Add(typeof(ValidationFilter)));

//AutoMapper
builder.Services.AddAutoMapper(typeof(CommentProfile));

//FluentValidation
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();
builder.Services
    .AddValidatorsFromAssemblyContaining<CreateCommentCommandValidator>();

//MediatR
builder.Services.AddMediatR(typeof(CreatePublicationCommand));

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

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
