using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApiDemo.Data;
using WebApiDemo.Repository;
using WebApiDemo.Services;


var builder = WebApplication.CreateBuilder(args);

// for connection string

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value));

// inject the services in the program

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductService>();

// swagger configuration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiDemo", Version = "v1" });
});


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiDemo v1"));
app.UseAuthorization();
app.MapControllers();  
app.Run();
