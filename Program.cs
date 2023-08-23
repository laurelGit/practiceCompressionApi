using Microsoft.EntityFrameworkCore;
using App.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// register the DBcontext here
// https://youtu.be/SlYf25tCCYY
builder.Services.AddDbContext<PersonContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("MyDbConnection"));
});
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
