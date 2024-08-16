using Infra.Context;
using LivrosApi.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<App_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CnnDb")));
builder.Services.AddDependencyInjectionConfig();


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("PolicyCors", app =>
//    {
//        app.AllowAnyOrigin()
//        .AllowAnyMethod()
//        .AllowAnyHeader();

//    });

//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


//app.UseCors("PolicyCors");


//app.UseAuthorization();

//IConfiguration configuration = app.Configuration;

//IWebHostEnvironment environment = app.Environment;


app.MapControllers();

//app.UseCors(options =>
//{
//    options.WithOrigins("http://localhost:4200");
//    options.AllowAnyMethod();
//    options.AllowAnyHeader();
//    options.AllowAnyOrigin();
//});

app.Run();
