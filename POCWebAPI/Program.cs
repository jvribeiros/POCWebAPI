
using POCWebAPI.Service.HubConfig;
using POCWebAPI.Service.Services;
using POCWebAPI.Infrastructure.Repositories;
using POCWebAPI.Domain.Interfaces.Services;
using POCWebAPI.Domain.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<IUserService, UserService>();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.UseCors("CorsPolicy");

app.MapHub<NotificationHub>("/notification");

app.Run();
