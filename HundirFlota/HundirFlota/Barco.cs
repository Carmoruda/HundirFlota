/// <summary>
/// 
/// La clase Barco define los atributos necesarios
/// para la creación de cada tipo de barco dentro de 
/// cada jugador.
/// 
/// <autores>LEdSM, OSV y CMU</autores>
/// <version>0.1</version>
/// </summary>

using HundirFlota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HundirFlota
{
    [Serializable]
    internal class Barco
    {
        // Atributos 

        /// <summary>
        /// String que representa el tipo de 
        /// barco.
        /// </summary>
        public string tipo { get; set; }

        /// <summary>
        /// Entero que representa la longitud
        /// del barco.
        /// </summary>
        public int longitud { get; set; }

        /// <summary>
        /// Entero que representa la orientación 
        /// del barco (0 - Vertical, 1 - Horizontal).
        /// </summary>
        public int orientacion { get; set; }

        /// <summary>
        /// String que representa el nombre del 
        /// jugador a quien le pertenece el barco.
        /// </summary>
        public string nombreJugador { get; set; }

        /// <summary>
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </summary>
        public Pantalla consola { get; set; }

        /// <summary>
        /// Instancia de la clase Tablero para controlar los
        /// elementos del tablero.
        /// </summary>
        public Tablero tablero { get; set; }

        /// <summary>
        /// Instancia de la clase Coordenadas para controlar
        /// las coordenadas de los barcos.
        /// </summary>
        public Coordenadas coordenadas { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase Barco.
        /// </summary>
        public Barco()
        {
            consola = new Pantalla();
            coordenadas = new Coordenadas();
        }

        /// <summary>
        /// Constructor parametrizado de la clase Barco. Asigna
        /// los valores de longitud, tipo de barco y nombre del
        /// jugador y llama al constructor vacio.
        /// </summary>
        /// <param name="_longitud">
        /// Entero que representa la longitud del barco.
        /// </param>
        /// <param name="_tipo">
        /// String que representa el tipo de barco.
        /// </param>
        /// <param name="_nombreJugador">
        /// String que representa el nombre del jugador.
        /// </param>
        public Barco(int _longitud, string _tipo, Tablero _tablero) : this()
        {
            longitud = _longitud;
            tipo = _tipo;
            tablero = _tablero;
        }

        /// <summary>
        /// Constructor parametrizado de la clase Barco. Asigna
        /// los valores de todos los atributos.
        /// </summary>
        /// <param name="_tipo">
        /// String que representa el tipo de barco.
        /// </param>
        /// <param name="_longitud">
        /// Entero que representa la longitud del barco.
        /// </param>
        /// <param name="_orientacion">
        /// Entero que representa la orientación 
        /// del barco (0 - Vertical, 1 - Horizontal).
        /// </param>
        /// <param name="_nombreJugador">
        /// String que representa el nombre del jugador/
        /// </param>
        /// <param name="_consola">
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </param>
        /// <param name="_tablero">
        /// Instancia de la clase Tablero para controlar los
        /// elementos del tablero.
        /// </param>
        /// <param name="_coordenadas">
        /// Instancia de la clase Coordenadas para controlar
        /// las coordenadas de los barcos.
        /// </param>
        public Barco(string _tipo, int _longitud, int _orientacion, string _nombreJugador, Pantalla _consola, Tablero _tablero, Coordenadas _coordenadas)
        {
            tipo = _tipo;
            longitud = _longitud;
            orientacion = _orientacion;
            nombreJugador = _nombreJugador;
            consola = _consola;
            tablero = _tablero;
            coordenadas = _coordenadas;
        }

        // Métodos

        /// <summary>
        /// LLama a los métodos necesarios para crear un nuevo 
        /// barco (seleccionar la orientación, introducir las
        /// coordenadas y color el barco en el mapa).
        /// </summary>
        /// <param name="nombre">
        /// String que representa el nombre del jugador.
        /// </param>
        public void NuevoBarco(string nombre)
        {
            nombreJugador = nombre;

            SeleccionarOrientacion();
            IntroducirCoordenadas();
            ColocarBarco();
        }

        /// <summary>
        /// Permite elegir la orientación de los barcos
        /// y asigna el valor correspondiente al atributo
        /// horizontal (0 - Vertical, 1 - Horizontal).
        /// </summary>
        public void SeleccionarOrientacion()
        {
            int accionOrientacion = 0;

            do
            {
                string texto = "------------------------------ JUGADOR " + nombreJugador.ToUpper() + " ------------------------------\n\n" +
                           "------------------------------ NUEVO BARCO ------------------------------\n\n\n  Información barco:" +
                           "\n\n\t * Tipo de barco: " + tipo + "\n\t * Longitud: " + longitud + "\n\t * Letra mapa: "
                           + tipo.Substring(0, 1).ToUpper() + "\n";

                consola.ImprimirConsola(texto, 1); // texto: -- JUGADOR...

                string[] opciones = { "\n  Seleccione una de las siguientes opciones:\n",
                                      "\t1   Orientación vertical.\n\t2   Orientación horizontal."};

                accionOrientacion = consola.PintarMenu(opciones, 0, 0);
                
                consola.Continuar(0); // Pulsar enter para continuar.
            } while (accionOrientacion < 1 || accionOrientacion > 2);
            

            orientacion = accionOrientacion - 1; // Orientación del barco.
            consola.ImprimirConsola("\n", 0); // Imprimir salto de línea.

        }

        /// <summary>
        /// Permite introducir el valor de las coordenadas 
        /// de los barcos.
        /// </summary>
        public void IntroducirCoordenadas() 
        {
            string[] opciones = { "\n\t* Coordenada X: ",
                                  "\t* Coordenada Y: ",
                                  "\t  Error! La longitud de su barco es " + longitud + " y posicionándolo en la casilla ",
                                  "\t  Error! Ya hay otro barco colocado en esa posición.\n",
                                  "\t  Error! Hay una zona de tierra en esa posición.\n"};

            coordenadas.ControlIntroducirCoordenadas(orientacion, longitud, consola, tablero, opciones, "BARCO", false);
        }

        /// <summary>
        /// Permite colocar los barcos en el mapa. LetraBarco representa la
        /// primera letra del tipo de barco correspondiente.
        /// </summary>
        public void ColocarBarco()
        {
            string letraBarco = "| " + tipo.Substring(0, 1).ToUpper() + " "; // Letra del barco en el mapa.
            tablero.RellenarBarcos(orientacion, letraBarco, longitud, coordenadas); // Añadir barcos al mapa.
            tablero.Pintar(false); // Mostrar el tablero
            consola.Continuar(1); // Pulsar enter para continuar.
        }
    }
}