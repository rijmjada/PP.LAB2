using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Biblioteca
    {
        #region Atributos

        private int capacidad;
        private List<Libro> libros;

        #endregion

        #region Constructores

        /// <summary>
        /// El constructor por defecto será el único que inicializará la lista genérica.
        /// </summary>
        private Biblioteca()
        {
            this.libros = new List<Libro>();
        }

        /// <summary>
        /// La sobrecarga, inicializará la capacidad de la biblioteca.
        /// </summary>
        /// <param name="capacidad"></param>
        private Biblioteca(int capacidad)
            : this()
        {
            this.capacidad = capacidad;
        }


        #endregion

        #region Propiedades

        public double PrecioDeManuales
        {
            get
            {
                return this.ObtenerPrecio(ELibro.PrecioDeManuales);
            }
        }

        public double PrecioDeNovelas
        {
            get
            {
                return this.ObtenerPrecio(ELibro.PrecioDeNovelas);
            }
        }

        public double PrecioTotal
        {
            get
            {
                return this.ObtenerPrecio(ELibro.PrecioTotal);
            }
        }



        #endregion

        #region Metodos

        /// <summary>
        /// Método privado y de instancia ObtenerPrecio, retornará el valor de la biblioteca de acuerdo con el enumerado ELibro que
        /// recibe como parámetro.Las propiedades públicas PrecioDeManuales, PrecioDeNovelas y PrecioTotal están asociadas al
        /// método ObtenerPrecio.Reutilizar código.
        /// </summary>
        /// <param name="tipoLibro"></param>
        /// <returns></returns>
        private double ObtenerPrecio(ELibro tipoLibro)
        {
            double precioRet = 0;

            foreach (Libro item in this.libros)
            {
                switch (tipoLibro)
                {
                    case ELibro.PrecioDeManuales:
                        if (item is Manual manual)
                        {
                            precioRet += (Single)manual;
                        }
                        break;

                    case ELibro.PrecioDeNovelas:
                        if (item is Novela novela)
                        {
                            precioRet += (Single)novela;
                        }
                        break;

                    case ELibro.PrecioTotal:
                        if (item is Manual m)
                        {
                            precioRet += (Single)m;
                        }
                        if (item is Novela n)
                        {
                            precioRet += (Single)n;
                        }
                        break;

                    default:
                        break;
                }

            }
            return precioRet;
        }

        /// <summary>
        /// El método público de clase Mostrar, retornará una cadena con toda la información de la biblioteca, incluyendo el detalle
        /// (completo) de cada uno de sus libros.Reutilizar código.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Mostrar(Biblioteca b)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.AppendFormat("Capacidad: {0}\r\n", b.capacidad);
            sb.AppendFormat("Total por Manuales: {0}\r\n", b.PrecioDeManuales);
            sb.AppendFormat("Total por Novelas: {0}\r\n", b.PrecioDeNovelas);
            sb.AppendFormat("Total:  {0}\r\n", b.PrecioTotal);

            sb.AppendLine("\n****************************************");
            sb.AppendLine("Listado de Libros");
            sb.AppendLine("****************************************\n");


            foreach(Libro item in b.libros)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

  
        #endregion

        #region Operadores
        /// <summary>
        /// Implícito, retornará una instancia de Biblioteca cuya capacidad coincida con el parámetro recibido.
        /// </summary>
        /// <param name="capacidad"></param>
        public static implicit operator Biblioteca(int capacidad)
        {
            return new Biblioteca(capacidad);
        }

        /// <summary>
        /// Igualdad, retornará true, si es que el manual o la novela ya se encuentra en la biblioteca, false, caso contrario
        /// </summary>
        /// <param name="b"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static bool operator ==(Biblioteca b, Libro l)
        {
            foreach(Libro item in b.libros)
            {
                if((item is Manual m1) && (l is Manual m2 )&& (m1 == m2))
                {
                    return true;
                }
                if((item is Novela n1) && (l is Novela n2) && (n1 == n2))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Biblioteca b, Libro l)
        {
            return !(b == l);
        }

        /// <summary>
        /// Adición, si la biblioteca posee capacidad de almacenar al menos un libro más y ese manual o novel no se encuentra en la biblioteca, lo agregará a la colección, caso contrario, informará lo acontecido. Reutilizar código.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static Biblioteca operator +(Biblioteca b, Libro l)
        {
            if(b.capacidad > b.libros.Count)
            {
                if(b != l)
                {
                    b.libros.Add(l);
                }
                else
                {
                    Console.WriteLine("El libro ya esta en la biblioteca!!!");
                }
            }
            else
            {
                Console.WriteLine("No hay más lugar en la biblioteca!!!");
            }

            return b;
        }

        #endregion
    }
    
}
