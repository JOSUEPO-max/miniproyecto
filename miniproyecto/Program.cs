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
            // Cargar los datos guardados en la carpeta "Datos" al iniciar el programa
            Database.CargarDatos();

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("******************* Sistema de Gestión de Inventario *******************");
                Console.WriteLine("Menú de Opciones:");
                Console.WriteLine("1.- Crear Categoría");
                Console.WriteLine("2.- Listar Categorías");
                Console.WriteLine("3.- Crear Producto");
                Console.WriteLine("4.- Listar Productos");
                Console.WriteLine("5.- Salir");
                Console.WriteLine("");
                Console.Write("Ingrese una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearCategoria();
                        break;
                    case "2":
                        ListarCategorias();
                        break;
                    case "3":
                        CrearProducto();
                        break;
                    case "4":
                        ListarProductos();
                        break;
                    case "5":
                        salir = true;
                        Console.WriteLine("\n¡Gracias por usar el sistema!");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para intentar de nuevo...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // --- MÉTODOS PARA CATEGORÍAS ---

        static void CrearCategoria()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR NUEVA CATEGORÍA ===");

            Console.Write("Ingrese el ID de la categoría: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID no válido.");
                Pausar();
                return;
            }

            Console.Write("Ingrese el Nombre de la categoría: ");
            string nombre = Console.ReadLine();

            // Instancia de Categoría usando el constructor parametrizado
            Categoria nuevaCategoria = new Categoria(id, nombre);

            // Agregar a la lista y guardar en el JSON
            Database.Categorias.Add(nuevaCategoria);
            Database.GuardarCategorias();

            Console.WriteLine("\n✔ Categoría guardada exitosamente en JSON.");
            Pausar();
        }

        static void ListarCategorias()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE CATEGORÍAS ===");

            if (Database.Categorias.Count == 0)
            {
                Console.WriteLine("No hay categorías registradas.");
            }
            else
            {
                foreach (var cat in Database.Categorias)
                {
                    Console.WriteLine($"ID: {cat.Id} | Nombre: {cat.Nombre}");
                }
            }

            Pausar();
        }

        // --- MÉTODOS PARA PRODUCTOS ---

        static void CrearProducto()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR NUEVO PRODUCTO ===");

            if (Database.Categorias.Count == 0)
            {
                Console.WriteLine("⚠ Debe registrar al menos una categoría antes de crear productos.");
                Pausar();
                return;
            }

            Console.Write("Ingrese el Código del producto: ");
            string codigo = Console.ReadLine();

            Console.Write("Ingrese el Nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el Precio: ");
            if (!double.TryParse(Console.ReadLine(), out double precio))
            {
                Console.WriteLine("Precio no válido.");
                Pausar();
                return;
            }

            // Seleccionar categoría existente
            Console.WriteLine("\nCategorías disponibles:");
            for (int i = 0; i < Database.Categorias.Count; i++)
            {
                Console.WriteLine($"{i + 1}.- {Database.Categorias[i].Nombre}");
            }

            Console.Write("Seleccione el número de la categoría: ");
            if (int.TryParse(Console.ReadLine(), out int seleccionCat) && seleccionCat > 0 && seleccionCat <= Database.Categorias.Count)
            {
                Categoria categoriaSeleccionada = Database.Categorias[seleccionCat - 1];

                // Instancia de Producto
                Producto nuevoProducto = new Producto(codigo, nombre, precio, categoriaSeleccionada);

                // Agregar a la lista y guardar en el JSON
                Database.Productos.Add(nuevoProducto);
                Database.GuardarProductos();

                Console.WriteLine("\n✔ Producto guardado exitosamente en JSON.");
            }
            else
            {
                Console.WriteLine("Selección de categoría inválida.");
            }

            Pausar();
        }

        static void ListarProductos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE PRODUCTOS ===");

            if (Database.Productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
            }
            else
            {
                foreach (var prod in Database.Productos)
                {
                    Console.WriteLine($"Código: {prod.Codigo} | Nombre: {prod.Nombre} | Precio: ${prod.Precio} | Categoría: {prod.Categoria.Nombre}");
                }
            }

            Pausar();
        }

        // Método auxiliar para pausar la pantalla
        static void Pausar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
