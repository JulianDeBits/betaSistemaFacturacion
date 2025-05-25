🚀 Cómo Empezar

🔧 Prerrequisitos
Antes de comenzar, asegúrate de tener lo siguiente instalado en tu máquina:

.NET 8 SDK o superior
SQL Server 
Visual Studio 2022 con soporte para ASP.NET y EF Core
Git

🛠 Instalación
Clona el repositorio:

git clone https://github.com/JuliandeBits/betaSistemaFacturacion.git

Restaura las dependencias del proyecto:
dotnet restore
Aplica las migraciones y crea la base de datos:

dotnet ef database update
ejecutar el script contenido en ScriptSistemaFacturacion

Ejecuta la aplicación:
dotnet run
Accede en tu navegador a: https://localhost:5229

⚙️ Funcionalidades
Usuarios: Registro y gestión de usuarios.
Presupuestos: Creación, edición y eliminación de presupuestos en determinado tiempo.
Gastos: Registro detallado de gastos asociados a presupuestos y categorías.
Categorías: Organización de los gastos por tipo (comida, transporte, ocio, etc.).
Monedas: Soporte para diferentes tipos de moneda (USD, EUR, MXN, etc.).

Cada entidad cuenta con su propio conjunto de vistas Razor para las operaciones CRUD (Crear, Leer (Index), Actualizar y Eliminar).

📁 Estructura del Proyecto

SistemaFacturacion.APP/ -> Capa de Interfaces
│
├── Controllers/               # Controladores MVC para cada entidad
│   ├── UsuariosController.cs
│   ├── PresupuestosController.cs
│   ├── GastosController.cs
│   ├── CategoriasController.cs
│   └── MonedasController.cs
│
├── Models/                    # Modelos de datos (Entidades EF)
│   ├── UsuarioViewModel.cs
│   ├── PresupuestoViewModel.cs
│   ├── GastoViewModel.cs
│   ├── CategoriaViewModel.cs
│   └── MonedaViewModel.cs
│
├── Views/                     # Vistas Razor por entidad
│   ├── Usuarios/
|                ├── Create.cshmtl
|                ├── Edit.cshtml
|                ├── Delete.cshtml
|                ├── Index.cshtml
│   ├── Presupuestos/
│   ├── Gastos/
│   ├── Categorias/
│   └── Monedas/
│
├── www.root/
|   ├── Css/
│   ├── Images/
│   ├── lib/
|
|
├── Program.cs
├── Appsettings.json
|
|
|
|
SistemaFacturacion.BLL/ -> Capa de Negocio
|
├── Interfaces/                                        Cada entidad tiene su respectiva interfaz
│   └── ICategoriaService.cs
|   └── IUsuarioService.cs
|   └── IMonedaService.cs
|   └── IGastoService.cs
|   └── IPresupuestoService.cs
│
├── Services/                                          Cada entidad tiene su respectivo Servicio
│   └── CategoriaService.cs
|   └── UsuarioService.cs
|   └── MonedaService.cs
|   └── GastoService.cs
|   └── PresupuestoService.cs
|
|
|
|
SistemaFacturacion.DAL/ -> Capa de Datos
|
|
├── DataContext/                                  
│   └── SistemaFacturacionContext.cs              Contexto de la Aplicicación
|
|
├── Entities/                                      Cada Entidad Declarada
│   └── Categoria.cs
|   └── Usuario.cs
|   └── Gasto.cs
|   └── Presupuesto.cs
|   └── Moneda.cs
│
├── Repositories/                                   Cada entidad tiene su respectivo Repositorio
│   └── UsuarioRepository.cs
|   └── CategoriaRepository.cs
|   └── MonedaRepository.cs
|   └── GastoRepository.cs
|   └── PresupuestoRepository.cs
|   └── GenericRepository.cs
