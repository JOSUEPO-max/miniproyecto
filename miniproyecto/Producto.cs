using miniproyecto.MiniProyecto;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniproyecto
{
    public class Producto
    {
        // Atributos privados
        private string _codigo;
        private string _nombre;
        private double _precio;
        private Categoria _categoria;

        // Constructor vacío
        public Producto() { }

        // Constructor parametrizado
        public Producto(string codigo, string nombre, double precio, Categoria categoria)
        {
            _codigo = codigo;
            _nombre = nombre;
            _precio = precio;
            _categoria = categoria;
        }

        // Propiedades
        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        // Método auxiliar para dar formato de texto
        public string ObtenerResumen()
        {
            return $"{Codigo} | {Nombre} | ${Precio} | Cat: {Categoria.Nombre}";
        }
    }
}
