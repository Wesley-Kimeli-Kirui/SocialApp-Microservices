using Microsoft.EntityFrameworkCore;
using Posts_Service.Data;
using Posts_Service.Extensions;
using Posts_Service.Services;
using Posts_Service.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// connect to database
builder.Services.AddDbContext<PostsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
// Auto Mapper Configurations
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// add services to the container for dependency injection
builder.Services.AddScoped<IPosts, PostService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMigration();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
