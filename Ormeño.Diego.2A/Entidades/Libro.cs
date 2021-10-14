using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Libro
    {
        #region Atributos

        protected Autor autor;
        protected int cantidadDePaginas;
        protected static Random generadorDePaginas;
        protected float precio;
        protected string titulo;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de Clase
        /// </summary>
        static Libro()
        {
            Libro.generadorDePaginas = new Random();
        }

        /// <summary>
        /// Constructor de Instancia
        /// </summary>
        /// <param name="precio"></param>
        /// <param name="titulo"></param>
        /// <param name="autor"></param>
        public Libro(float precio, string titulo, Autor autor)
        {
            this.precio = precio;
            this.titulo = titulo;
            this.autor = autor;

        }
        /// <summary>
        /// Constructor De Instancia, crea un nuevo Autor con nombre y apellido para pasarlos al otro Constructor
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="apellido"></param>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        public Libro(string titulo, string apellido, string nombre, float precio)
            :this(precio, titulo, new Autor(nombre, apellido))
        {

        }

        #endregion

        #region Propiedades

        /// <summary>
        /// La propiedad (de sólo lectura) CantidadDePaginas, retornará el valor correspondiente del atributo cantidadDePaginas, que
        /// se inicializará en dicha propiedad, si y sólo si su valor es cero. Para inicializar dicho atributo, se utilizará el atributo estático
        /// generadorDePaginas (valores aleatorios entre 10 y 570). Ninguno debe de repetirse.
        /// </summary>
        public int CantidadDePaginas
        {
            get
            {
                if(this.cantidadDePaginas == 0)
                {
                    
                    this.cantidadDePaginas = generadorDePaginas.Next(10, 570);
   
                }
                return this.cantidadDePaginas;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// El método privado y de clase Mostrar, retornará una cadena detallando los atributos de la clase.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        private static string Mostrar(Libro l)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("AUTOR: {0}\r\n", (string)l.autor);
            sb.AppendFormat("TITULO: {0}\r\n", l.titulo);
            sb.AppendFormat("CANTIDAD PAGINAS: {0}\r\n", l.CantidadDePaginas);
            sb.AppendFormat("PRECIO: {0}\r\n", l.precio);
          
            return sb.ToString();

        }

        #endregion

        #region Operadores

        /// <summary>
        /// Retornará true, si los títulos y los autores son iguales, false, caso contrario
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Libro a, Libro b)
        {
            return a.titulo == b.titulo && a.autor == b.autor;
        }

        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Explícito. Retornará el detalle completo del libro que recibe como parámetro.
        /// </summary>
        /// <param name="l"></param>
        public static explicit operator String(Libro l)
        {
            return Mostrar(l);
        }

        #endregion

    }
}
