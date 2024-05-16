## Librerias a usar

Debido a un error que sale al usar librerias, veo que sean las mismas versiones al paquete de sap, en este caso Version="6.0.30"

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Relational
- Program Files\sap\hdbclient\dotnetcore\v6.0\Sap.Data.Hana.Net.v6.0.dll
- Program Files\sap\hdbclient\dotnetcore\v6.0\Sap.EntityFrameworkCore.Hana.v6.0.dll

## Conexion para uso del contexto

```c#
using Sap.EntityFrameworkCore.Hana;

var connectionString = "Server=host:443;UserName=username;Password=mysuperpassword";
builder.Services.AddDbContext<HanaDbContext>(options =>
    options.UseHana(connectionString));
```

## DBContext
```c#
using Microsoft.EntityFrameworkCore;
using Sap.EntityFrameworkCore.Hana;

namespace WebApplication2.Models
{
    public class HanaDbContext : DbContext
    {
        public HanaDbContext(DbContextOptions<HanaDbContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
```

## Blog con informacion
[Connect Using the Microsoft Entity Framework Core (EF Core)](https://developers.sap.com/tutorials/hana-clients-entity-framework.html)

## Documentacion oficial
[SAP HANA Client Interface Programming Reference](https://help.sap.com/docs/SAP_HANA_CLIENT/f1b440ded6144a54ada97ff95dac7adf/a20fc75d64f6443baa422e1f4a80085c.html)
