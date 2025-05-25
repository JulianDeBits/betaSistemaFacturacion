<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>README - Sistema Facturación</title>
</head>
<body>

    <h1>🚀 Cómo Empezar</h1>

    <h2>🔧 Prerrequisitos</h2>
    <p>Antes de comenzar, asegúrate de tener lo siguiente instalado en tu máquina:</p>
    <ul>
        <li>.NET 8 SDK o superior</li>
        <li>SQL Server</li>
        <li>Visual Studio 2022 con soporte para ASP.NET y EF Core</li>
        <li>Git</li>
    </ul>

    <h2>🛠 Instalación</h2>
    <ol>
        <li>Clona el repositorio:<br>
            <code>git clone https://github.com/JuliandeBits/betaSistemaFacturacion.git</code>
        </li>
        <li>Restaura las dependencias del proyecto:<br>
            <code>dotnet restore</code>
        </li>
        <li>Aplica las migraciones y crea la base de datos:<br>
            <code>dotnet ef database update</code><br>
            Ejecuta también el script contenido en <strong>ScriptSistemaFacturacion</strong>.
        </li>
        <li>Ejecuta la aplicación:<br>
            <code>dotnet run</code>
        </li>
        <li>Accede desde tu navegador a:<br>
            <a href="https://localhost:5229">https://localhost:5229</a>
        </li>
    </ol>

    <h2>⚙️ Funcionalidades</h2>
    <ul>
        <li><strong>Usuarios:</strong> Registro y gestión de usuarios.</li>
        <li><strong>Presupuestos:</strong> Creación, edición y eliminación de presupuestos en determinado tiempo.</li>
        <li><strong>Gastos:</strong> Registro detallado de gastos asociados a presupuestos y categorías.</li>
        <li><strong>Categorías:</strong> Organización de los gastos por tipo (comida, transporte, ocio, etc.).</li>
        <li><strong>Monedas:</strong> Soporte para diferentes tipos de moneda (USD, EUR, MXN, etc.).</li>
    </ul>
    <p>Cada entidad cuenta con su propio conjunto de vistas Razor para las operaciones CRUD (Crear, Leer <em>(Index)</em>, Actualizar y Eliminar).</p>

    <h2>📁 Estructura del Proyecto</h2>

    <h3>SistemaFacturacion.APP - Capa de Interfaces</h3>
    <pre>
Controllers/
├── UsuariosController.cs
├── PresupuestosController.cs
├── GastosController.cs
├── CategoriasController.cs
└── MonedasController.cs

Models/
├── UsuarioViewModel.cs
├── PresupuestoViewModel.cs
├── GastoViewModel.cs
├── CategoriaViewModel.cs
└── MonedaViewModel.cs

Views/
├── Usuarios/
│   ├── Create.cshtml
│   ├── Edit.cshtml
│   ├── Delete.cshtml
│   ├── Index.cshtml
├── Presupuestos/
├── Gastos/
├── Categorias/
└── Monedas/

wwwroot/
├── Css/
├── Images/
└── lib/

Program.cs
Appsettings.json
    </pre>

    <h3>SistemaFacturacion.BLL - Capa de Negocio</h3>
    <pre>
Interfaces/
├── ICategoriaService.cs
├── IUsuarioService.cs
├── IMonedaService.cs
├── IGastoService.cs
└── IPresupuestoService.cs

Services/
├── CategoriaService.cs
├── UsuarioService.cs
├── MonedaService.cs
├── GastoService.cs
└── PresupuestoService.cs
    </pre>

    <h3>SistemaFacturacion.DAL - Capa de Datos</h3>
    <pre>
DataContext/
└── SistemaFacturacionContext.cs

Entities/
├── Categoria.cs
├── Usuario.cs
├── Gasto.cs
├── Presupuesto.cs
└── Moneda.cs

Repositories/
├── UsuarioRepository.cs
├── CategoriaRepository.cs
├── MonedaRepository.cs
├── GastoRepository.cs
├── PresupuestoRepository.cs
└── GenericRepository.cs
    </pre>

</body>
</html>
