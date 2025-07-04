# 🚧 Correr proyecto en modo desarrollo
Para correr el proyecto es tan simple como hacer el comando base de dotnet

```bash
dotnet watch run
```


## 🔐 Conexión a la base de datos
Para poder ejecutar el proyecto y realizar la conexión a la base de datos debemos primero realizar la instalación de algunas librerías que se encuentran en [[📦Nuget]] tales como:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.4" />

	<!-- Estas son las dependencias para realizar la conexion con la BD -->
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.3" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.3" />
    <PackageReference Include="Npgsql" Version="9.0.3" />
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="9.0.3" />
  </ItemGroup>

</Project>
```

Despues de esto y de definir los modelos que van a seguir nuestras tablas en la base de datos, vamos a realizar la conexión creando un `AplicationDBContext` que sería la manera de conectar la base de datos al contexto de la aplicación.

```csharp
public class AplicationDBContext(DbContextOptions dbContextOptions) 
: DbContext(dbContextOptions)
{
  // Se agrega cada una de las tablas que el ORM va a mapear
  public DbSet<Book> Book { get; set; }
  public DbSet<Author> Author { get; set; }
  public DbSet<Genre> Genre { get; set; }
}
```

Luego de crear el contexto debemos aplicarlo a nivel global de la aplicación esto debe hacerse en el archivo de `program.cs` de la siguiente manera:

```csharp
builder.Services.AddDbContext<AplicationDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
```

# 🔥 appsettings

Y dentro de nuestro `appsettings.json` pondremos los datos para realizar la conexión a la base de datos por medio del string que se guardará en **DefaultConnection**:

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=<Nombre>;Username=postgres;Password=postgres"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 🚚 Migración
Despues de realizar todos los pasos anteriores debemos ejecutar una migración la cual nos permite transformar todos los `Models` en tablas de la base de datos, esto se realiza con el siguiente comando:

```bash
dotnet ef migrations add init
```

Y tras crear la migración inicial pasamos a actualizarla en la base de datos:

```bash
dotnet ef database update
```
