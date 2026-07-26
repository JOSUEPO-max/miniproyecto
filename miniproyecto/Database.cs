using miniproyecto.MiniProyecto;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniproyecto
{
    public static class Database
    {
        // Ruta de la carpeta "Datos" en la ubicación del proyecto
        private static readonly string rutaCarpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos");
        private static readonly string rutaArchivoCategorias = Path.Combine(rutaCarpeta, "categorias.json");
        private static readonly string rutaArchivoProductos = Path.Combine(rutaCarpeta, "productos.json");

        // Listas globales que simulan la base de datos en memoria
        public static List<Categoria> Categorias = new List<Categoria>();
        public static List<Producto> Productos = new List<Producto>();

        public static void CargarDatos()
        {
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }
            Categorias = ArchivoJson.Cargar<Categoria>(rutaArchivoCategorias);
            Productos = ArchivoJson.Cargar<Producto>(rutaArchivoProductos);
        }

        public static void GuardarDatos()
        {
            GuardarCategorias();
            GuardarProductos();
        }

        public static void GuardarCategorias()
        {
            ArchivoJson.Guardar(rutaArchivoCategorias, Categorias);
        }

        public static void GuardarProductos()
        {
            ArchivoJson.Guardar(rutaArchivoProductos, Productos);
        }
    }
}