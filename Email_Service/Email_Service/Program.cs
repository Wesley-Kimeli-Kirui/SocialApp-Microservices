using Email_Service.Data;
using Email_Service.Extensions;
using Email_Service.Messaging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// connect to database
builder.Services.AddDbContext<EmailDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

builder.Services.AddSingleton<IAzureMessageBusEndUser, AzureMessageBusEndUser>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// run any pending migrations
app.UseMigration();
app.useAzure();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
