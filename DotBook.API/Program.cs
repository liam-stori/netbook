using DotBook.Application.Commands.CreatePublication;
using DotBook.Core.Repositories;
using DotBook.Infrastructure.Persistance;
using DotBook.Infrastructure.Persistance.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//SqlServer
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DotBookDbContext>(
        options => options.UseSqlServer(connection));

//Repositories
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//MediatR
builder.Services.AddMediatR(typeof(CreatePublicationCommand));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
