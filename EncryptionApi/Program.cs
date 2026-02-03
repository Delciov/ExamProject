using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Lägg till stöd för Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// VIKTIGT: Vi tog bort "if (IsDevelopment)" så Swagger visas även i AWS!
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = "swagger"; // Swagger ligger på /swagger
});

// Vi stänger av denna tillfälligt för att undvika problem med AWS-proxyn
// app.UseHttpsRedirection();

app.UseAuthorization();

// Mappa dina controllers
app.MapControllers();

// Lägg till en startsida så vi ser att servern lever direkt
app.MapGet("/", () => "Servern lever! Gå till /swagger eller /api/cipher/encrypt?text=hej");

app.Run();
