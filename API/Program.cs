using Core.Interfaces;
using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add Services to container

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SkinetContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

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