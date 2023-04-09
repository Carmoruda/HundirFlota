/// <summary>
/// 
/// La clase Pantalla controla todas las operaciones de entrada y salida
/// de datos del programa. Su proposito es aislar la interfaz del resto
/// del programa.
/// 
/// <autores>LEdSM, OSV y CMU</autores>
/// <version>0.1</version>
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundirFlota
{
    internal class Pantalla
    {
        // Atributos

        /// <summary>
        /// String que representa el nombre del juego.
        /// </summary>
        public string nombreJuego { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase Pantalla.
        /// </summary>
        public Pantalla() { }

        /// <summary>
        /// Constructor parametrizado de la clase Pantalla.
        /// Establece el valor para el atributo de nombre
        /// del juego y lo imprime por consola.
        /// </summary>
        /// <param name="_nombreJuego">
        /// </param>
        public Pantalla(string _nombreJuego) 
        {
            nombreJuego = _nombreJuego;
            Console.WriteLine(" " +  nombreJuego);
        }

        // Métodos

        /// <summary>
        /// Imprime la opción de salida en los menús.
        /// </summary>
        /// <param name="opciones">
        /// String array que contiene las diferentes opciones
        /// del menú.
        /// </param>
        public void Salir(string[] opciones)
        {
            Console.WriteLine("\t" + opciones.Length + "   Salir.");
        }

        /// <summary>
        /// Pide al usuario que pulse la tecla enter para continuar.
        /// </summary>
        public void Continuar()
        {
            Console.WriteLine("\n  Pulse Enter para continuar:");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.Clear();
        }

        /// <summary>
        /// Muestra por consola texto.
        /// </summary>
        /// <param name="texto">
        /// String que representa el texto que se quiere mostrar.
        /// </param>
        /// <param name="limpiar">
        /// Entero que representa si se desea limpiar la consola
        /// antes de mostrar el texto.
        /// </param>
        public void ImprimirConsola(string texto, int limpiar)
        {
            if (limpiar == 1) // Limpiar consola.
            {
                Console.Clear();
            }

            Console.Write(texto);

        }

        /// <summary>
        /// Muestra por consola un menú de opciones.
        /// </summary>
        /// <param name="opciones">
        /// String array que representa las diferentes opciones del menú.
        /// </param>
        /// <param name="limpiar">
        /// Entero que representa si se desea limpiar (1) la consola
        /// antes de mostrar el texto.
        /// </param>
        /// <returns>
        /// Devuelve un entero que representa la opción seleccionada
        /// por el usuario.
        /// </returns>
        public int PintarMenu(string[] opciones, int limpiar)
        {
            if (limpiar == 1) // Limpiar consola.
            {
                Console.Clear();
            }


            foreach (string opcion in opciones)
            {
                Console.WriteLine(opcion);
            }

            Salir(opciones); // Mostar opción de salida.

            Console.Write("\n\n  Introduzca su elección:\n  ===> ");

            return ComprobarEntero(int.Parse(Console.ReadLine()), 0, opciones.Length); // Opción seleccionada.
        }


        /// <summary>
        /// Muestra por consola un texto y lee el input del usuario.
        /// </summary>
        /// <param name="texto">
        /// String que representa el texto que se quiere mostrar.
        /// </param>
        /// <returns>
        /// Devuelve un string que representa el input del usuario.
        /// </returns>
        public string LeerString(string texto)
        {
            Console.Write(texto);
            return Console.ReadLine();
        }

        /// <summary>
        /// Muestra por consola un texto y lee el input del usuario.
        /// </summary>
        /// <param name="texto">
        /// String que representa el texto que se quiere mostrar.
        /// </param>
        /// <param name="limiteInf">
        /// Entero que representa el límite inferior.
        /// </param>
        /// <param name="limiteSup">
        /// Entero que representa el límite superior.
        /// </param>
        /// <returns>
        /// Devuelve un entero que representa el input del usuario.
        /// </returns>
        public int LeerEntero(string texto, int limiteInf, int limiteSup)
        {
            Console.Write(texto);
            return ComprobarEntero(Convert.ToInt32(Console.ReadLine()), limiteInf, limiteSup);
        }

        /// <summary>
        /// Comprueba si el entero introducido por el usuario se encuentra
        /// entre los límites asignados.
        /// </summary>
        /// <param name="variable">
        /// Entero que se desea comprobar.
        /// </param>
        /// <param name="limiteInf">
        /// Entero que representa el límite inferior.
        /// </param>
        /// <param name="limiteSup">
        /// Entero que representa el límite superior.
        /// </param>
        /// <returns></returns>
        public int ComprobarEntero(int variable, int limiteInf, int limiteSup)
        {
            string mensajeError = "  Error! El valor introducido debe estar entre " + limiteInf + " y " + limiteSup + "\n\n";

            if (limiteInf <= variable && limiteSup >= variable)
            {
                return variable;
            }
            else
            {
                ImprimirConsola(mensajeError, 0); // Mensaje error.
                return 0;
            }
        }

        public void PintarTablero(String[,] mapa, int i, int j)
        {
            for (i = 0; i < 12; i++)
            {
                if (i != 0 && i < 9)
                {
                    Console.Write("   " + (i + 1));
                }
                else if (i == 0)
                {
                    Console.Write("     " + (i + 1));
                }
                else
                {
                    Console.Write("  " + (i + 1));
                }
                
            }
            Console.ResetColor();
            Console.WriteLine();

            for (i = 0; i < 12; i++)
            {
                if (i < 9)
                {
                    Console.Write((i + 1) + ". ");
                }
                else
                {
                    Console.Write((i + 1) + ".");
                }
                
                for (j = 0; j < 12; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    
                    switch(mapa[i, j])
                    {
                        case "| X ":
                            Console.BackgroundColor = ConsoleColor.DarkGreen; // Color Tierra.
                            break;
                        case "| P ":
                            Console.BackgroundColor = ConsoleColor.DarkRed; // Color Patrullero.
                            break;
                        case "| S ":
                            Console.BackgroundColor = ConsoleColor.DarkYellow; // Color Submarino.
                            break;
                        case "| D ":
                            Console.BackgroundColor = ConsoleColor.DarkMagenta; // Color Destructor.
                            break;
                        case "| A ":
                            Console.BackgroundColor = ConsoleColor.DarkGray; // Color PortaAviones.
                            break;
                    }

                    Console.Write(mapa[i, j]);

                }
                Console.ResetColor();
                Console.WriteLine();
            }

            

        }
    }
}
