using ApiProductosLabs.Data;
using ApiProductosLabs.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<RepositoryProductos>();
string connectionString = builder.Configuration.GetConnectionString("AzureSql");
builder.Services.AddDbContext<ProductosContext>
    (options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.UseSwagger();
app.UseSwaggerUI(
    options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Microsoft Labs v1");
        options.RoutePrefix = "";
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
