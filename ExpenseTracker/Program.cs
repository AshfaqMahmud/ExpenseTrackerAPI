using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable serving static files (this will serve files from wwwroot)
app.UseStaticFiles();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Expense Tracker API V1");
    options.RoutePrefix = "swagger";  // Swagger will be available at /swagger
});

// Serve the index.html page at the root URL
app.MapFallbackToFile("index.html");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
