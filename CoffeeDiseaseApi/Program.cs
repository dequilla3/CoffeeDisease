using Microsoft.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseUrls("http://*:8080");

app.Run();
