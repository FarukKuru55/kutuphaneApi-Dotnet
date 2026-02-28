using kutuphaneApi2.Data;
using kutuphaneApi2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. VERÝTABANI BAÐLANTISI
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 2. JSON DÖNGÜSÜ ENGELLEME VE CONTROLLER
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. SERVÝS KAYITLARI (Dependency Injection)
builder.Services.AddScoped<IUyeService, UyeService>();
builder.Services.AddScoped<IKitapService, KitapService>();
builder.Services.AddScoped<IYazarService, YazarService>();
builder.Services.AddScoped<IOduncIslemService, OduncIslemService>();
builder.Services.AddScoped<IIstatistikService, IstatistikService>();

// 4. CORS AYARI (React Entegrasyonu)
builder.Services.AddCors(options => {
    options.AddPolicy("AllowReactApp", policy =>
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// 5. MIDDLEWARE SIRALAMASI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseAuthorization(); // Bu satýrý eklemek iyidir [cite: 2025-12-06]
app.MapControllers();

app.Run();