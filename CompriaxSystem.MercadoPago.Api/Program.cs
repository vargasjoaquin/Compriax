using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Application.Services;
using CompriaxSystem.Infrastructure.Persistence;
using CompriaxSystem.MercadoPago.Api.Configuration;
using CompriaxSystem.MercadoPago.Api.Interfaces;
using CompriaxSystem.MercadoPago.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MercadoPagoSettings>(builder.Configuration.GetSection("MercadoPago"));

builder.Services.AddHttpClient();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Server=.;Database=Compriax;Integrated Security=True;TrustServerCertificate=True";

    options.UseSqlServer(connectionString);
});


// Add services to the container.
builder.Services.AddScoped<IMercadoPagoService, MercadoPagoService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "CompriaxSystem Mercado Pago API",
        Version = "v1",
        Description = "Microservicio de integración de pagos QR y webhooks para Compriax POS"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompriaxSystem Mercado Pago API v1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
