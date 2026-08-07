using miniproyecto.MiniProyecto;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniproyecto
{
    public class Producto
    {
        public int Id { get; set; } // Llave primaria autoincrementable para SQL
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        // Relación con Categoría (Foreign Key)
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        // Constructores
        public Producto() { }

        public Producto(string codigo, string nombre, double precio, Categoria categoria)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
        }

        public string ObtenerResumen()
        {
            return $"{Codigo} | {Nombre} | ${Precio} | Cat: {(Categoria != null ? Categoria.Nombre : "Sin Cat")}";
        }
    }
}
