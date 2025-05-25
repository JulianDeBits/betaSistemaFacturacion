# 🚀 Cómo Empezar

## 🔧 Prerrequisitos

Antes de comenzar, asegúrate de tener lo siguiente instalado en tu máquina:

- .NET 8 SDK o superior  
- SQL Server  
- Visual Studio 2022 con soporte para ASP.NET y EF Core  
- Git  

## 🛠 Instalación

1. Clona el repositorio:

   ```bash
   git clone https://github.com/JuliandeBits/betaSistemaFacturacion.git
Restaura las dependencias del proyecto:

bash
Copiar
Editar
dotnet restore
Aplica las migraciones y crea la base de datos:

bash
Copiar
Editar
dotnet ef database update
También debes ejecutar el script contenido en ScriptSistemaFacturacion.

Ejecuta la aplicación:

bash
Copiar
Editar
dotnet run
Abre en tu navegador:
https://localhost:5229

⚙️ Funcionalidades
Usuarios: Registro y gestión de usuarios.

Presupuestos: Creación, edición y eliminación de presupuestos en determinado tiempo.

Gastos: Registro detallado de gastos asociados a presupuestos y categorías.

Categorías: Organización de los gastos por tipo (comida, transporte, ocio, etc.).

Monedas: Soporte para diferentes tipos de moneda (USD, EUR, MXN, etc.).

Cada entidad cuenta con su propio conjunto de vistas Razor para las operaciones CRUD (Crear, Leer (Index), Actualizar y Eliminar).

# 📁 Estructura del Proyecto

```text
SistemaFacturacion.APP/ – Capa de Interfaces

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
│   └── Index.cshtml
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
```

```text
SistemaFacturacion.BLL/ – Capa de Negocio

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
```

```text
SistemaFacturacion.DAL/ – Capa de Datos

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
```

