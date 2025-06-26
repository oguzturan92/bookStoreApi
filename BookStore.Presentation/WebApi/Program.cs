using System.Text;
using Application.Interfaces;
using Application.Interfaces.IReadRepositories;
using Application.Interfaces.IWriteRepositories;
using Application.Mapping;
using Application.Services;
using BookStore.Infrastructure.Persistance.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistance.Identity;
using Persistance.Repositories;
using Persistance.Repositories.ReadRepositories;
using Persistance.Repositories.WriteRepositories;
using Persistance.Services;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddHttpClient();

    builder.Services.AddHttpContextAccessor();

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
    
    // DbContext
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Generic
    builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
    builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

    // Entity'e Özel
    builder.Services.AddScoped<IBookReadRepository, BookReadRepository>();
    builder.Services.AddScoped<IBookWriteRepository, BookWriteRepository>();
    builder.Services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
    builder.Services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<ITokenService, TokenService>();


    // Mapper
    builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);
    
    // Fluent
    builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    
    // MediatR
    builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

    // Identity
    builder.Services.AddIdentity<AppUser, AppRole>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
    
    // Token Girmek İçin Swagger'da Arayüz
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API", Version = "v1" });

        // 🔐 JWT Auth için Swagger yapılandırması
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGci...\"",
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

    app.UseMiddleware<ExceptionMiddleware>();

    app.UseAuthentication(); // Önce authentication
    app.UseAuthorization();  // Sonra authorization

    app.MapControllers(); // API isteklerinin doğru controller'a yönlendirilmesini sağlar

app.Run();