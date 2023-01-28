using CategoryService.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CatShoppingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnStr"));
});
builder.Services.AddControllers();
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

using (var scope = app.Services.CreateScope())
{
    // THis will read the DbContext class and its Conenction String with DbSet<Product>
    var shopContext = scope.ServiceProvider.GetRequiredService<CatShoppingDbContext>();
    // Run the Migration over the COnnectionString to create database
    shopContext.Database.EnsureCreated();

}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
