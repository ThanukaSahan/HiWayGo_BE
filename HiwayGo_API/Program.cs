using System;
using System.IO;
using System.Reflection;
using HiwayGo_API.Entity;
using HiwayGo_API.Repository;
using HiwayGo_API.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger (Swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HiwayGo API",
        Version = "v1",
        Description = "API documentation for HiwayGo"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// register repositories
builder.Services.AddRepositories();

// register logic services
builder.Services.AddScoped<IBusDetailLogic, BusDetailLogic>();
builder.Services.AddScoped<IBusModelLogic, BusModelLogic>();
builder.Services.AddScoped<IBusBookingLogic, BusBookingLogic>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IUserRoleLogic, UserRoleLogic>();

// register Jwt service
builder.Services.AddSingleton<IJwtService, JwtService>();

// register AutoMapper (scan current assembly for profiles)
builder.Services.AddAutoMapper(cfg => {
    // any extra configuration here
}, AppDomain.CurrentDomain.GetAssemblies());

// Configure JWT authentication
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey ?? string.Empty));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = signingKey,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

app.MapGet("/", () => "PostgreSQL connected successfully!");

// -- Apply EF Core migrations / ensure DB exists at startup --
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>();
        // Use Migrate() to apply pending migrations (recommended)
        context.Database.Migrate();

        // If you prefer to create DB without migrations (NOT recommended for production), use:
        // context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        // Obtain logger and log the error so the app startup output shows the details.
        var logger = services.GetService<Microsoft.Extensions.Logging.ILoggerFactory>()?
            .CreateLogger("DatabaseMigration");
        logger?.LogError(ex, "An error occurred while migrating or creating the database.");
        Console.Error.WriteLine(ex);
        // Decide whether to rethrow or continue. Rethrowing will stop the app.
        // throw;
    }
}
// -- end DB bootstrap --

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HiwayGo API v1");
        c.RoutePrefix = "swagger";
    });

    app.MapOpenApi();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HiwayGo API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

// Add authentication middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
