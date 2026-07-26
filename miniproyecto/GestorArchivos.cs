using System;
using System.Collections.Generic;
using System.Text;

namespace miniproyecto
{
    public class GestorArchivos
    {
        // Atributo privado
        private string _nombreArchivo;

        // Constructor
        public GestorArchivos(string nombreArchivo)
        {
            _nombreArchivo = nombreArchivo;
        }

        // Propiedad
        public string NombreArchivo
        {
            get { return _nombreArchivo; }
            set { _nombreArchivo = value; }
        }

        // Método para guardar un registro en el archivo
        public void GuardarProducto(Producto producto)
        {
            string linea = producto.ObtenerResumen();
            File.AppendAllText(_nombreArchivo, linea + Environment.NewLine);
            Console.WriteLine("✔ Producto guardado en el archivo exitosamente.");
        }

        // Método para leer todo el archivo
        public void LeerArchivo()
        {
            if (!File.Exists(_nombreArchivo))
            {
                Console.WriteLine("⚠ El archivo aún no existe.");
                return;
            }

            Console.WriteLine("\n--- CONTENIDO DEL ARCHIVO DE TEXTO ---");
            string[] lineas = File.ReadAllLines(_nombreArchivo);
            foreach (string linea in lineas)
            {
                Console.WriteLine(linea);
            }
            Console.WriteLine("--------------------------------------\n");
        }
    }
}