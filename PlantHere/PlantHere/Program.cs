using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using PlantHere.Application;
using PlantHere.Application.Settings;
using PlantHere.Application.Utilities;
using PlantHere.Infrastructure;
using PlantHere.Persistence;
using PlantHere.WebAPI.Middlewares;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Swagger
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

// MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Service Registration 

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddInfrastructureServices(builder.Configuration);

// Token
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
{
    var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();

    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audiences[0],
        IssuerSigningKey = SignUtility.GetSymmetricSecurityKey(tokenOptions.SecurityKey),

        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// Cors Policy
var settingsOptions = builder.Configuration.GetSection("Settings").Get<SettingsOption>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: settingsOptions.CorsPolicyName,
                      policy =>
                      {
                          policy.WithOrigins(settingsOptions.AllowedOrigins).AllowAnyHeader().AllowAnyMethod();
                      });
});

// App 
var app = builder.Build();

// Migration
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCustomException();

app.UseRouting();

app.UseCors(settingsOptions.CorsPolicyName);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();