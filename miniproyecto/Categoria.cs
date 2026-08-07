using System;
using System.Collections.Generic;
using System.Text;

namespace miniproyecto
{
    namespace MiniProyecto
    {
        public class Categoria
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            // Constructores
            public Categoria() { }

            public Categoria(string nombre)
            {
                Nombre = nombre;
            }

            public Categoria(int id, string nombre)
            {
                Id = id;
                Nombre = nombre;
            }
        }
    }
}
