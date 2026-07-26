using System;
using System.Collections.Generic;
using System.Text;

namespace miniproyecto
{
    namespace MiniProyecto
    {
        public class Categoria
        {
            // Atributos privados
            private int _id;
            private string _nombre;

            // Constructores
            public Categoria() { }

            public Categoria(int id, string nombre)
            {
                _id = id;
                _nombre = nombre;
            }

            // Propiedades
            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public string Nombre
            {
                get { return _nombre; }
                set { _nombre = value; }
            }
        }
    }
}

