using Microsoft.EntityFrameworkCore;
using miniproyecto.MiniProyecto;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniproyecto.dbcontext
{
    public class InventarioDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-SDJH29O\SQLEXPRESS;Database=INVENTARIO_DB;User Id=sa;Password=1234;TrustServerCertificate=True;");
            }
        }
    }
}