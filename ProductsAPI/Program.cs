using Application;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductsDbContext>(options =>
    options.UseSqlServer("Server=db;Database=ProductsDb;User=sa;Password=Testexec123;TrustServerCertificate=True"
));
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MainPolicy",
          builder =>
          {
              builder
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
              builder.SetIsOriginAllowed(x => true);
          });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MainPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
