var builder = WebApplication.CreateBuilder(args);

// Lägg till stöd för Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aktivera Swagger så du kan testa APIet enkelt
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mappa dina controllers så de hittas
app.MapControllers();

app.Run();