using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Infrastructure.Utilities.Security.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Utilities.Security.Encyption;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.EntityFramework.Context;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:3000"));
});


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Erpa WebAPI",
        Version = "v1",
        Description = "Erpa .Net Core WebApi",
        Contact = new OpenApiContact
        {
            Name = "Halil Bülbül",
            Email = "halil.bulbul@outlook.com.tr"
        }
    }));


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepositoryEf>();

builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandRepository, BrandRepositoryEf>();

builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IModelRepository, ModelRepositoryEf>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepositoryEf>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepositoryEf>();

builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartRepository, CartRepositoryEf>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepositoryEf>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenHelper, JwtHelper>();


var app = builder.Build();

app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
