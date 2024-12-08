using Infrastructure.Dal;
using Infrastructure.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddDbContext<DrugStoreDbContext>((serviceProvider, options) =>
{
    var dataBaseSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;

    options.UseNpgsql(dataBaseSettings.ConnectionString, npgsqlOptions =>
    {
        npgsqlOptions.CommandTimeout(dataBaseSettings.CommandTimeout);
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
