using miniproyecto.MiniProyecto;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniproyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMOSTRACIÓN DEL PROYECTO ===\n");

            // 1. Crear instancia de Categoría
            Categoria catHardware = new Categoria(1, "Hardware");

            // 2. Crear instancia de Producto (usando constructores y propiedades)
            Producto prod1 = new Producto("P001", "Teclado Mecánico", 45.50, catHardware);
            Producto prod2 = new Producto("P002", "Mouse Gamer", 25.00, catHardware);

            // 3. Crear instancia del Gestor de Archivos
            GestorArchivos gestor = new GestorArchivos("productos.txt");

            // 4. Guardar datos en el archivo
            gestor.GuardarProducto(prod1);
            gestor.GuardarProducto(prod2);

            // 5. Leer y mostrar el contenido del archivo
            gestor.LeerArchivo();

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
