using Microsoft.EntityFrameworkCore;
using ACooperativa.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar el DbContext con SQL Server
builder.Services.AddDbContext<CooperativaContext>(options =>
    options.UseSqlServer(connectionString));

// Agregar servicios según lo que uses: Razor Pages o controladores
builder.Services.AddRazorPages(); // Para Razor Pages
builder.Services.AddControllers(); // Para controladores API

var app = builder.Build();

// Configuración del middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
builder.Services.AddDbContext<CooperativaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Configurar las rutas según los servicios que uses
app.MapRazorPages(); // Para Razor Pages
app.MapControllers(); // Para controladores API

app.Run();
