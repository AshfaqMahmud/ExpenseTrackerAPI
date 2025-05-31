
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        // this should be added before builder.Build()


        // Add services to the container.
        builder.Services.Configure<BookStoreDatabaseSettings>(
            builder.Configuration.GetSection("BookStoreDatabase"));
        builder.Services.AddSingleton<BooksService>();
        // mongoDB configuration

        builder.Services.Configure<ExpenseDatabaseSettings>(
            builder.Configuration.GetSection("ExpenseDatabase")
        );
        builder.Services.AddSingleton<ExpenseService>();

        builder.Services.AddControllers()
        .AddJsonOptions(
            options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

        // builder.Services.AddDbContext<ApplicationDBContext>(options =>
        //     options.UseSqlServer(
        //         builder.Configuration.GetConnectionString("DefaultConnection")
        //         )
        // );
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            //app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
            
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Expense Tracker API V1");
                    
                }       
            );
        }

        app.UseHttpsRedirection();


        app.MapControllers();

        app.Run();
    }
}