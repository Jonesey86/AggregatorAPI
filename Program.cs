﻿using AggregatorAPI.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpClient<WeatherService>();
builder.Services.AddHttpClient<ICryptoService, CryptoService>();  
builder.Services.AddHttpClient<IForexService, ForexService>();
builder.Services.AddScoped<ICryptoService, CryptoService>();  

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseRouting();  
app.UseAuthorization();
app.MapControllers();  
app.Run();