using GreekSmash.Context;
using GreekSmash.Repositories;
using GreekSmash.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // Add header documentation in swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "GreekSmash API",
        Description = "This is the API for the popular game GreekSmash!\r\nDeveloped by Team Power Rangers",
        Contact = new OpenApiContact
        {
            Name = "The Official GreekSmash Website\r\n",
            Url = new Uri("https://www.greeksmash.com")
        },
    });
    // Feed generated xml api docs to swagger
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Configure our services
ConfigureServices(builder.Services);

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

void ConfigureServices(IServiceCollection services)
{
    // Trasient -> create new instance of DapperContext everytime.
    services.AddTransient<DapperContext>();
    // Configure Automapper
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    // Services
    services.AddScoped<IVillainService, VillainService>();
    services.AddScoped<IArenaService, ArenaService>();
    services.AddScoped<IHeroService, HeroService>();
    services.AddScoped<ILocationService, LocationService>();
    services.AddScoped<IConditionService, ConditionService>();
    // Repos
    services.AddScoped<IArenaRepository, ArenaRepository>();
    services.AddScoped<ILocationRepository, LocationRepository>();
    services.AddScoped<IConditionRepository, ConditionRepository>();
    services.AddScoped<IHeroRepository, HeroRepository>();
    services.AddScoped<IVillainRepository, VillainRepository>();
}