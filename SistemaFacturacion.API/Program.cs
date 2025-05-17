using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.BLL.Interfaces;
using SistemaFacturacion.BLL.Services;
using SistemaFacturacion.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registrar los servicios antes de llamar a builder.Build()
builder.Services.AddControllersWithViews();

// Configuración de la base de datos
builder.Services.AddDbContext<DbSistemaFacturacionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));

// Registrar repositorios y servicios
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<GastoRepository>();
builder.Services.AddScoped<IGastoService, GastoService>();

builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<MonedaRepository>();
builder.Services.AddScoped<IMonedaService, MonedaService>();

builder.Services.AddScoped<PresupuestoRepository>();
builder.Services.AddScoped<IPresupuestoService, PresupuestoService>();

// Después de registrar los servicios, construimos la aplicación
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
