using BusinessObject;
using DataAccessLayer.DTOs.request;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services;
using Services.Impl;
using Services.Implements;
using Services.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
<<<<<<< HEAD
builder.Services.AddScoped<IGammaService, GammaService>();
builder.Services.AddScoped<IPhoGammaService, PhoGammaService>();
builder.Services.AddScoped<IXrfService, XrfService>();
=======
builder.Services.AddScoped<F_QService>();
builder.Services.AddScoped<IDeviceServices, DeviceService>();
builder.Services.AddScoped<INotificationServices, NotificationService>();
>>>>>>> b25226b00660a65b8fb2abdf69b67025aef9677d

// 1. Bind JWT settings
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));

// 2. Add authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Key))
        };
    });

// 3. Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactNative", builder =>
    {
        builder
            .WithOrigins()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddSingleton<JwtTokenGenerator>();
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactNative");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();