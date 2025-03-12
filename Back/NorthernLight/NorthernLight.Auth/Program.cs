using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using NorthernLight.Auth.Application;
using NorthernLight.Auth.Application.Infrastructure.MiddleWares;
using NorthernLight.Auth.Application.Models.FluentValidation;
using NorthernLight.Auth.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsecrets.json", optional: true, reloadOnChange: true);


builder.Services.AddDbContext<AuthorizationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5, // Maximum number of retry attempts
                maxRetryDelay: TimeSpan.FromSeconds(30), // Maximum delay between retries
                errorNumbersToAdd: null); // Specific SQL error numbers to consider for retries
        }));

builder.Services.RegisterPersistanceServces();
builder.Services.RegisterApplicationServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Secret"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    })
    .AddGoogle(options =>
    {
        options.ClientId =
            "710907375843-q41h5mfelmpatta298demt2530i6th6n.apps.googleusercontent.com"; // Replace with your Google Client ID
        options.ClientSecret = "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"; // Replace with your Google Client Secret
    });


////builder.WithOrigins("https://localhost:8081")
////       .AllowAnyHeader()
////       .AllowAnyMethod()
////       .AllowCredentials();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder
                .AllowAnyOrigin() // Be cautious, combining AllowAnyOrigin() with AllowCredentials() is discouraged due to security risks.
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers()
    .AddFluentValidation(configurationExpression: fv =>
        fv.RegisterValidatorsFromAssemblyContaining<RegisterDtoValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "Authorization API",
            Description = "Centralized Authorization",
            Version = "v1"
        }
    );
    var basePath = PlatformServices.Default.Application.ApplicationBasePath;
    foreach (var name in Directory.GetFiles(basePath, "*.XML", SearchOption.AllDirectories))
    {
        options.IncludeXmlComments(name);
    }

    //Add authentication
    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT token for authorization using Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityDefinition("Bearer", securitySchema);
    options.AddSecurityRequirement
    (
        new OpenApiSecurityRequirement
        {
            {
                securitySchema,
                new[] { "Bearer" }
            }
        }
    );
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();