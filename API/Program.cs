using API.Extensions;
using API.Middleware;
using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add Services to container

builder.Services.AddControllers();
builder.Services.AddAppServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var skinetContext = services.GetRequiredService<SkinetContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await skinetContext.Database.MigrateAsync();
    await SkinetContextSeed.SeedAsync(skinetContext);
}
catch(Exception ex)
{
    logger.LogError(ex, "An error occured during Migration");
}

app.Run();