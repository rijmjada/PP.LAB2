using System;
using System.Text;

namespace Entidades
{
    public class Autor
    {
        #region Atributos

        private string nombre;
        private string apellido;

        #endregion

        #region Constructor

        public Autor(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }


        #endregion

        #region Operadores
        /// <summary>
        /// Retornará true, si los nombres y los apellidos son iguales, false, caso contrario.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Autor a, Autor b)
        {
            return a.nombre == b.nombre && a.apellido == b.apellido;
        }

        public static bool operator !=(Autor a, Autor b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Implícito. Retornará el nombre y apellido del autor que recibe como parámetro
        /// </summary>
        /// <param name="a"></param>
        public static implicit operator string(Autor a)
        {
            return a.nombre + " - " + a.apellido;

        }

        #endregion

    }
}
