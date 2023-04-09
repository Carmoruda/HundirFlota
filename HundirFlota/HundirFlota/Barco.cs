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
        public int horizontal { get; set; }

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
        /// String que representa el nombre del jugador/
        /// </param>
        public Barco(int _longitud, string _tipo, Tablero _tablero) : this()
        {
            longitud = _longitud;
            tipo = _tipo;
            tablero = _tablero;
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
            

            horizontal = accionOrientacion - 1; // Orientación del barco.
            consola.ImprimirConsola("\n", 0); // Imprimir salto de línea.

        }

        /// <summary>
        /// Permite introducir el valor de las coordenadas 
        /// de los barcos.
        /// </summary>
        public void IntroducirCoordenadas() 
        {
            int coordenadaX = 0;
            int coordenadaY = 0;
            bool existeBarco = true;

            tablero.Pintar(); // Mostrar el tablero.

            string[] opciones = { "\n\t* Coordenada X: ",
                                  "\t* Coordenada Y: ",
                                  "\t  Error! La longitud de su barco es " + longitud + " y posicionándolo en la casilla ",
                                  "\t  Error! Ya hay otro barco colocado en esa posición.\n"};

            do
            {
                do // Coordenadas eje X. 
                {
                    coordenadaX = consola.LeerEntero(opciones[0], 1, 12); // Opciones[0]: * Coordenada X.

                    if (coordenadaX + longitud > 12 && horizontal == 1) // Mensaje de error cuando se sale del tablero.
                    {
                        consola.ImprimirConsola(opciones[2] + coordenadaX + " se sale del tablero.\n", 0); // Error, la longitud de su barco es...
                    }

                } while (coordenadaX < 1 || coordenadaX > 12 || (coordenadaX + longitud > 12 && horizontal == 1));

                do // Coordenadas eje Y.
                {
                    coordenadaY = consola.LeerEntero(opciones[1], 1, 12); // Opciones[1]: * Coordenada Y.

                    if (coordenadaY + longitud > 12 && horizontal == 0) // Mensaje de error cuando se sale del tablero.
                    {
                        consola.ImprimirConsola(opciones[2] + coordenadaY + " se sale del tablero.\n", 0); // Error, la longitud de su barco es...
                    }
                } while (coordenadaY < 1 || coordenadaY > 12 || (coordenadaY + longitud > 12 && horizontal == 0));

                switch (horizontal) // Asignación de las coordenadas.
                {
                    case 0: // Orientación vertical
                        coordenadas.x[0] = coordenadas.x[1] = coordenadaX - 1;

                        coordenadas.y[0] = coordenadaY - 1;
                        coordenadas.y[1] = coordenadaY + longitud - 2;
                        break;
                    case 1: // Orientación horizontal
                        coordenadas.y[0] = coordenadas.y[1] = coordenadaY - 1;

                        coordenadas.x[0] = coordenadaX - 1;
                        coordenadas.x[1] = coordenadaX + longitud - 2;
                        break;
                }

                existeBarco = tablero.BuscarBarco(coordenadas);

                if (existeBarco)
                {
                    consola.ImprimirConsola(opciones[3], 0); // Error! Ya hay otro barco...
                }

            } while (existeBarco);
            
            consola.ImprimirConsola("\n", 0); // Imprimir salto de línea.
        }

        /// <summary>
        /// Permite colocar los barcos en el mapa. LetraBarco representa la
        /// primera letra del tipo de barco correspondiente.
        /// </summary>
        public void ColocarBarco()
        {
            string letraBarco = "| " + tipo.Substring(0, 1).ToUpper() + " "; // Letra del barco en el mapa.
            tablero.RellenarBarcos(horizontal, letraBarco, longitud, coordenadas); // Añadir barcos al mapa.
            tablero.Pintar(); // Mostrar el tablero
            consola.Continuar(1); // Pulsar enter para continuar.
        }
    }
}