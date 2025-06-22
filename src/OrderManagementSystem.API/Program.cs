using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Application.Commands;
using OrderManagementSystem.Domain.Repositories;
using OrderManagementSystem.Infrastructure.Data;
using OrderManagementSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddScoped<IDiscountRepository, DiscountRepository>()
    .AddScoped<IOrderAnalyticsRepository, OrderAnalyticsRepository>()
    .AddScoped<IOrderRepository, OrderRepository>()
    .AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
