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

        /// <summary>
        /// Booleano que representa si el barco se encuentra
        /// hundido.
        /// </summary>
        public bool hundido { get; set; }

        /// <summary>
        /// Entero que representa el número de disparos que ha recibido
        /// el barco.
        /// </summary>
        public int contadorTocados { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase Barco.
        /// </summary>
        public Barco()
        {
            consola = new Pantalla();
            coordenadas = new Coordenadas();
            hundido = false;
            contadorTocados = 0;
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
        /// <param name="_hundido">
        /// Booleano que representa si el barco se encuentra hundido.
        /// </param>
        /// <param name="_contadorTocados">
        /// Entero que representa el número de disparos que ha recibido
        /// el barco.
        /// </param>
        public Barco(string _tipo, int _longitud, int _orientacion, string _nombreJugador, Pantalla _consola, Tablero _tablero, Coordenadas _coordenadas, bool _hundido, int _contadorTocados)
        {
            tipo = _tipo;
            longitud = _longitud;
            orientacion = _orientacion;
            nombreJugador = _nombreJugador;
            consola = _consola;
            tablero = _tablero;
            coordenadas = _coordenadas;
            hundido = _hundido;
            contadorTocados = _contadorTocados;
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
        /// <param name="modo">
        /// String que representa tipo de modo de juego de la partida.
        /// </param>
        public void NuevoBarco(string nombre, string modo)
        {
            nombreJugador = nombre;

            SeleccionarOrientacion(modo);
            IntroducirCoordenadas(modo);
            ColocarBarco();
        }

        /// <summary>
        /// Permite elegir la orientación de los barcos
        /// y asigna el valor correspondiente al atributo
        /// horizontal (0 - Vertical, 1 - Horizontal).
        /// </summary>
        public void SeleccionarOrientacion(string modo)
        {
            int accionOrientacion = 0;

            switch (modo)
            {
                case "MANUAL":
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
                    break;

                case "AUTOMATICO":
                    int seed = Environment.TickCount;
                    Random r = new Random(seed);
                    int numrandom = r.Next(1, 21);
                    if (numrandom % 2 == 0)
                    {
                        orientacion = 0;
                    }
                    else
                    {
                        orientacion = 1;
                    }
                    
                    break;
            }            
        }

        /// <summary>
        /// Permite introducir el valor de las coordenadas 
        /// de los barcos.
        /// </summary>
        /// <param name="modo">
        /// String que representa tipo de modo de juego de la partida.
        /// </param>
        public void IntroducirCoordenadas(String modo) 
        {
            string[] opciones = { "\n\t* Coordenada X: ",
                                  "\t* Coordenada Y: ",
                                  "\t  Error! La longitud de su barco es " + longitud + " y posicionándolo en la casilla ",
                                  "\t  Error! Alguna de las coordendas del barco coincide con otro barco.\n",
                                  "\t  Error! Alguna de las coordenadas del barco coincide con una tierra.\n"};

            coordenadas.ControlIntroducirCoordenadas(orientacion, longitud, consola, tablero, opciones, "BARCO", false, modo, nombreJugador);
        }

        /// <summary>
        /// Permite colocar los barcos en el mapa. LetraBarco representa la
        /// primera letra del tipo de barco correspondiente.
        /// </summary>
        public void ColocarBarco()
        {
            string letraBarco = "| " + tipo.Substring(0, 1).ToUpper() + " "; // Letra del barco en el mapa.
            tablero.RellenarBarcos(orientacion, letraBarco, longitud, coordenadas); // Añadir barcos al mapa.

            /*if (nombreJugador != "Autómata") // No mostrar el tablero si el jugador es el automático.
            {
                tablero.PintarPropio(); // Mostrar el tablero
                consola.Continuar(1); // Pulsar enter para continuar.
            }*/
            tablero.PintarPropio(); // Mostrar el tablero
            consola.Continuar(1); // Pulsar enter para continuar.

        }

        /// <summary>
        /// Permite establecer el estado del barco dependiendo de
        /// si ha sido bombardeado en todas sus coordenadas hundiéndolo.
        /// </summary>
        public void EstadoHundido(List<int> lanzamientosX, List<int> lanzamientosY, Coordenadas coordenadas, Tablero tableroOponente)
        {

            if (hundido)
            {
                return;
            }

            string letraBarco = "| " + tipo.Substring(0, 1).ToUpper() + " "; // Letra del barco en el mapa.
            int indiceCoordenadaLista = lanzamientosX.IndexOf(coordenadas.x[0]); // Indice en la lista de coordenadas de ataques de la coordenada X.

            if (!lanzamientosX.Contains(coordenadas.x[0]) && tableroOponente.mapaOponente[coordenadas.y[0], coordenadas.x[0]] == "| ¬ " && tablero.mapa[coordenadas.y[0], coordenadas.x[0]] == letraBarco)
            {
                contadorTocados += 1;
            }
            else if (lanzamientosX.Contains(coordenadas.x[0]) && lanzamientosY[0] != coordenadas.y[0] && tableroOponente.mapaOponente[coordenadas.y[0], coordenadas.x[0]] == "| ¬ " && tablero.mapa[coordenadas.y[0], coordenadas.x[0]] == letraBarco)
            {
                contadorTocados += 1;
            }

            if (contadorTocados == longitud)
            {
                hundido = true;
                consola.ImprimirConsola("\n\t  Barco de tipo " + tipo.ToLower() + " hundido!.\n\n", 0);
            }
        }
    }
}