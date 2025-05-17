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

<<<<<<< HEAD
=======
// Registrar repositorios y servicios
>>>>>>> c47cd5a813f94b3f805de65f13a5bf8498ba08ed
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

<<<<<<< HEAD
=======
// Después de registrar los servicios, construimos la aplicación
>>>>>>> c47cd5a813f94b3f805de65f13a5bf8498ba08ed
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
