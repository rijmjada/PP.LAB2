using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Manual : Libro
    {
        #region Atributos

        public ETipo tipo;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de Instancia que cargara su unico atributo.
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="apellido"></param>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        /// <param name="tipo"></param>
        public Manual(string titulo, string apellido, string nombre, float precio, ETipo tipo)
            :base(titulo, apellido, nombre, precio)
        {
            this.tipo = tipo;
        }

        #endregion

        #region Operadores


        /// <summary>
        ///  Igualdad (Manual, Manual). Retornará true, si los libros y los tipos son iguales, false, caso contrario
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Manual a, Manual b)
        {
            return a.tipo == b.tipo && (Libro)a == (Libro)b;
        }


        public static bool operator !=(Manual a, Manual b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Explícito. Retornará el precio del manual que recibe como parámetro.
        /// </summary>
        /// <param name="m"></param>
        public static explicit operator Single(Manual m)
        {
            return m.precio;
        }

        /// <summary>
        /// Polimorfismo en ToString, retornará una cadena conteniendo la información completa del objeto. Reutilizar código
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append((String)this);
            sb.AppendFormat("TIPO: {0}\r\n", this.tipo);

            return sb.ToString();
        }

        /// <summary>
        /// Polimorfismo en Equals. Retornará true, si el parámetro recibido es igual a la instancia actual. Reutilizar código
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            // Si obj es de tipo Manual lo guardo en  'otroManual', caso contrario guardara NULL
            Manual otroManual = obj as Manual;

            return otroManual is not null && otroManual == this;
        }

        #endregion

    }
}
