using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Novela : Libro
    {

        #region Atributos
        public EGenero genero;
        #endregion

        #region Constructores

        public Novela(string titulo, float precio, Autor autor, EGenero genero)
            :base(precio, titulo, autor)
        {
            this.genero = genero;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Igualdad (Novela, Novela). Retornará true, si los libros y los géneros son iguales, false, caso contrario
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Novela a , Novela b)
        {
            return a.genero == b.genero && (Libro)a == (Libro)b;
        }

        public static bool operator !=(Novela a, Novela b)
        {
            return !(a == b);
        }


        /// <summary>
        /// Implícito. Retornará el precio de la novela que recibe como parámetro
        /// </summary>
        /// <param name="a"></param>
        public static implicit operator Single(Novela a)
        {
            return a.precio;
        }

        /// <summary>
        /// Polimorfismo en ToString, retornará una cadena conteniendo la información completa del objeto. Reutilizar código.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append((String)this);
            sb.AppendFormat("GENERO: {0}\r\n", this.genero);

            return sb.ToString();
        }

        /// <summary>
        /// Polimorfismo en Equals. Retornará true, si el parámetro recibido es igual a la instancia actual. Reutilizar código.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Novela otraNovela = obj as Novela;

            return otraNovela is not null && otraNovela == this;
        }


        #endregion

    }
}
