using System.Text.Json.Serialization;
using Application;
using Application.Abstractions.Services;
using Infrastructure;
using Infrastructure.Converters;
using Infrastructure.Services;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Serilog;
using Web.Api;
using Web.Api.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new UlidJsonConverter());
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    });


builder.Host.UseSerilog((context, loggerConfig) => 
    loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));

builder.Services.AddHttpContextAccessor();

builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);

var configuration = builder.Configuration;
var mailSetting = configuration.GetSection("MailSetting").Get<MailSetting>();
builder.Services.AddSingleton(mailSetting);
builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });


        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme.",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                []
            }
        });

        // Add this to treat Ulid as string in Swagger
        options.MapType<Ulid>(() => new OpenApiSchema { Type = "string", Format = "ulid" });
    });

var app = builder.Build();
app.MapControllers();



// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     
// }
app.UseSwagger();
app.UseSwaggerUI();

app.ApplyMigrations();

await app.SeedDatabaseAsync();

app.UseHttpsRedirection();

app.UseCors();

app.UseRequestContextLogging();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
