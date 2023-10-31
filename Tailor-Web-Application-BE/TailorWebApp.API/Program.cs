using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TailorWebApp.Application.AutoMapper;
using TailorWebApp.Application.Settings;
using TailorWebApp.BE.ServiceExtensions;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Utils.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureControllersOptions();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddApiRepositories();
builder.Services.AddApiServices();
builder.Services.ConfigureIdentityOptions();
builder.Services.ConfigureSwaggerOptions();
builder.Services.ConfigureAuthenticationOptions(builder.Configuration);

//Azure storage settings
builder.Services.Configure<AzureStorageSettings>(builder.Configuration.GetSection("AzureStorageSettings"));
builder.Services.AddScoped<AzureStorageSettings>();

var corsSpecificOrigin = "AllowedOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsSpecificOrigin,
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dataContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsSpecificOrigin);
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();