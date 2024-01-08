using Microsoft.EntityFrameworkCore;
using TeammateApi.Data;
using TeammateApi.Features.UserProfile;
using TeammateApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGeneration();
builder.Services.AddDbContext<TeammateContext>(options => options.UseSqlite("Data Source = ./Database/teammate.db"));

builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyHeader().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddTransient<IUserProfileService, UserProfileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseCors();
app.UseRouting();

app.UseSwaggerUIGeneration();

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
