# Sistema CRUD – Local de Electrodomésticos

Aplicación de escritorio desarrollada en C# con Windows Forms que permite gestionar el inventario de productos de un local de electrodomésticos. Implementa las cuatro operaciones básicas sobre una base de datos SQL Server usando ADO.NET directamente, sin ORM.

Práctica académica **TI-PA-APE-04** — Programación Avanzada, Universidad Técnica de Ambato.

---

## Tecnologías

| Componente | Detalle |
|---|---|
| Lenguaje | C# 12 |
| Framework | .NET 8.0 (Windows) |
| Interfaz | Windows Forms |
| Acceso a datos | ADO.NET (`Microsoft.Data.SqlClient`) |
| Base de datos | SQL Server (autenticación SQL: `sa`) |

---

## Modelo de datos

**Tabla: `Productos`**

| Campo | Tipo SQL | Descripción |
|---|---|---|
| `Id` | INT IDENTITY PK | Identificador autonumérico |
| `Codigo` | NVARCHAR(20) UNIQUE | Código del producto (ej. `REF-001`) |
| `Nombre` | NVARCHAR(150) | Nombre descriptivo del producto |
| `Categoria` | NVARCHAR(100) | Categoría (Refrigeradoras, Lavadoras, etc.) |
| `Marca` | NVARCHAR(100) | Marca comercial |
| `Precio` | DECIMAL(10,2) | Precio en USD, debe ser ≥ 0 |
| `Stock` | INT | Unidades disponibles, debe ser ≥ 0 |
| `Descripcion` | NVARCHAR(300) | Descripción opcional del producto |
| `FechaIngreso` | DATE | Fecha de ingreso al inventario |

---

## Estructura del proyecto

```
SistemaEstudiantes/
├── Scripts/
│   └── ElectrodomesticosDB.sql    # Script para crear la BD y cargar datos de ejemplo
├── Models/
│   └── Producto.cs                # Clase que representa un producto
├── Data/
│   └── DatabaseHelper.cs          # Cadena de conexión y creación automática de la BD
├── Repositories/
│   └── ProductoRepository.cs      # Operaciones CRUD con ADO.NET y transacciones
├── Forms/
│   ├── MainForm.cs                # Lógica de la interfaz de usuario
│   └── MainForm.Designer.cs       # Definición visual de los controles
├── Program.cs                     # Punto de entrada
└── SistemaEstudiantes.csproj
```

---

## Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (o superior)
- SQL Server con **autenticación de modo mixto** habilitada
- Usuario `sa` activo con contraseña `12345678`

### Habilitar modo mixto y activar `sa` (una sola vez)

Abre SQL Server Management Studio (SSMS), conecta con Windows Authentication y ejecuta:

```sql
-- Activar autenticación de modo mixto (requiere reiniciar el servicio SQL Server)
-- Esto se configura en: clic derecho en el servidor → Properties → Security
-- Marcar "SQL Server and Windows Authentication mode"

-- Activar y configurar el usuario sa
ALTER LOGIN sa ENABLE;
ALTER LOGIN sa WITH PASSWORD = '12345678';
```

Después reinicia el servicio SQL Server desde el Administrador de Servicios de Windows o con:

```powershell
Restart-Service -Name MSSQLSERVER      # instancia por defecto
# o
Restart-Service -Name 'MSSQL$SQLEXPRESS'  # si usas SQL Server Express
```

---

## Configuración de la conexión

El servidor está definido en [Data/DatabaseHelper.cs](Data/DatabaseHelper.cs):

```csharp
private const string Server   = "localhost";       // cámbialo a localhost\SQLEXPRESS si es necesario
private const string User     = "sa";
private const string Password = "12345678";
private const string DbName   = "ElectrodomesticosDB";
```

---

## Instalación y ejecución

**Opción A — Dejar que la aplicación cree la base de datos automáticamente:**

```powershell
cd "e:\Vario\Trabajo\SistemaEstudiantes"
dotnet run --ignore-failed-sources
```

Al iniciar, la aplicación crea la base de datos `ElectrodomesticosDB` y la tabla `Productos` si no existen. La tabla parte vacía; deberás ingresar los datos manualmente.

**Opción B — Ejecutar el script SQL primero (recomendado para tener datos de ejemplo):**

1. Abre SSMS y conecta con el usuario `sa`.
2. Abre el archivo `Scripts/ElectrodomesticosDB.sql`.
3. Ejecuta el script (F5). Crea la BD, la tabla y carga 12 productos de ejemplo.
4. Luego ejecuta la aplicación:

```powershell
dotnet run --ignore-failed-sources
```

> La opción `--ignore-failed-sources` es necesaria porque hay una fuente NuGet local configurada en el equipo que ya no existe. No afecta la compilación.

---

## Uso de la aplicación

### Registrar un nuevo producto
1. Presiona **Nuevo** para limpiar el formulario.
2. Completa los campos: Código, Nombre, Categoría, Marca, Precio y Stock.
3. Presiona **Guardar**. El producto aparece inmediatamente en la lista.

### Editar un producto existente
1. Haz clic sobre cualquier fila de la lista. Los datos se cargan en el formulario.
2. Modifica los campos que necesites.
3. Presiona **Actualizar**.

### Eliminar un producto
1. Haz clic sobre la fila del producto.
2. Presiona **Eliminar** y confirma en el cuadro de diálogo.

### Buscar
Escribe en el campo de búsqueda (acepta código, nombre, categoría o marca) y presiona **Buscar**. Para volver a ver todos los registros, presiona **Mostrar Todos**.

### Validaciones
- Código, Nombre, Categoría y Marca son obligatorios.
- El Precio debe ser un número decimal mayor o igual a 0 (usar `.` como separador decimal, ej: `199.99`).
- El Stock debe ser un número entero mayor o igual a 0.

---

## Arquitectura

El proyecto sigue una separación en tres capas:

- **Models** — define la entidad `Producto` como clase POCO.
- **Data / Repositories** — accede directamente a SQL Server mediante `SqlConnection`, `SqlCommand` y `SqlDataReader`. Cada operación de escritura (INSERT, UPDATE, DELETE) usa una transacción ADO.NET (`BeginTransaction / Commit / Rollback`).
- **Forms** — maneja la interfaz gráfica; llama al repositorio y refleja los resultados en el `DataGridView`.
