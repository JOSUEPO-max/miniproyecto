using miniproyecto.dbcontext;
using miniproyecto.MiniProyecto;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace miniproyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            // Asegura que la base de datos "INVENTARIO_DB" y sus tablas se creen en SQL Server
            using (var db = new InventarioDbContext())
            {
                db.Database.EnsureCreated();
            }

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

            Console.Write("Ingrese el Nombre de la categoría: ");
            string nombre = Console.ReadLine();

            using (var db = new InventarioDbContext())
            {
                Categoria nuevaCategoria = new Categoria(nombre);
                db.Categorias.Add(nuevaCategoria);
                db.SaveChanges(); // Guarda en SQL Server
            }

            Console.WriteLine("\n✔ Categoría guardada exitosamente en SQL Server.");
            Pausar();
        }

        static void ListarCategorias()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE CATEGORÍAS ===");

            using (var db = new InventarioDbContext())
            {
                var categorias = db.Categorias.ToList();

                if (categorias.Count == 0)
                {
                    Console.WriteLine("No hay categorías registradas.");
                }
                else
                {
                    foreach (var cat in categorias)
                    {
                        Console.WriteLine($"ID: {cat.Id} | Nombre: {cat.Nombre}");
                    }
                }
            }

            Pausar();
        }

        // --- MÉTODOS PARA PRODUCTOS ---

        static void CrearProducto()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR NUEVO PRODUCTO ===");

            using (var db = new InventarioDbContext())
            {
                var categorias = db.Categorias.ToList();

                if (categorias.Count == 0)
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
                for (int i = 0; i < categorias.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.- {categorias[i].Nombre}");
                }

                Console.Write("Seleccione el número de la categoría: ");
                if (int.TryParse(Console.ReadLine(), out int seleccionCat) && seleccionCat > 0 && seleccionCat <= categorias.Count)
                {
                    Categoria categoriaSeleccionada = categorias[seleccionCat - 1];

                    // Instancia de Producto
                    Producto nuevoProducto = new Producto
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Precio = precio,
                        CategoriaId = categoriaSeleccionada.Id
                    };

                    db.Productos.Add(nuevoProducto);
                    db.SaveChanges(); // Guarda en SQL Server

                    Console.WriteLine("\n✔ Producto guardado exitosamente en SQL Server.");
                }
                else
                {
                    Console.WriteLine("Selección de categoría inválida.");
                }
            }

            Pausar();
        }

        static void ListarProductos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE PRODUCTOS ===");

            using (var db = new InventarioDbContext())
            {
                // Usamos .Include(p => p.Categoria) para traer los datos de la Categoría asociada desde SQL
                var productos = db.Productos.Include(p => p.Categoria).ToList();

                if (productos.Count == 0)
                {
                    Console.WriteLine("No hay productos registrados.");
                }
                else
                {
                    foreach (var prod in productos)
                    {
                        string nombreCat = prod.Categoria != null ? prod.Categoria.Nombre : "Sin Categoría";
                        Console.WriteLine($"ID: {prod.Id} | Código: {prod.Codigo} | Nombre: {prod.Nombre} | Precio: ${prod.Precio} | Categoría: {nombreCat}");
                    }
                }
            }

            Pausar();
        }

        static void Pausar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}