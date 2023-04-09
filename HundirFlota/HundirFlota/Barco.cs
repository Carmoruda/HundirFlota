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
            string texto = "------------------------------JUGADOR " + nombreJugador.ToUpper() + "------------------------------\n\n" +
                           "------------------------------ NUEVO BARCO ------------------------------\n\n\n  Información barco:" +
                           "\n\n\t * Tipo de barco: " + tipo + "\n\t * Longitud: " + longitud + "\n\t * Letra mapa: " 
                           + tipo.Substring(0, 1).ToUpper() + "\n";

            consola.ImprimirConsola(texto, 1);

            string[] opciones = { "\n  Seleccione una de las siguientes opciones:\n",
                                  "\t1   Orientación vertical.",
                                  "\t2   Orientación horizontal."};

            accionOrientacion = consola.PintarMenu(opciones, 0) - 1;

            if(accionOrientacion == 3) // Salir
            {
                return;
            }

            horizontal = accionOrientacion;
        }

        /// <summary>
        /// Permite introducir el valor de las coordenadas 
        /// de los barcos.
        /// </summary>
        public void IntroducirCoordenadas() 
        {
            int coordenadaX = 0;
            int coordenadaY = 0;

            tablero.Pintar(); // Mostrar el tablero.

            string[] opciones = { "\n\t* Coordenada X: ",
                                  "\t* Coordenada Y: "};

            do
            {
                coordenadaX = consola.LeerEntero(opciones[0], 1, 12); // Opciones[0]: * Coordenada X.
            } while (coordenadaX < 1 || coordenadaX > 12);

            do
            {
                coordenadaY = consola.LeerEntero(opciones[1], 1, 12); // Opciones[1]: * Coordenada Y.
            } while (coordenadaY < 1 || coordenadaY > 12);


            switch (horizontal) // Asignación de las coordenadas.
            {
                case 0: // Orientación vertical
                    coordenadas.x[0] = coordenadas.x[1] = coordenadaY - 1;
                    
                    coordenadas.y[0] = coordenadaX - 1;
                    coordenadas.y[1] = coordenadaX + longitud - 2;
                    break;
                case 1: // Orientación horizontal
                    coordenadas.x[0] = coordenadaY - 1;
                    coordenadas.x[1] = coordenadaY + longitud - 2;
                    
                    coordenadas.y[0] = coordenadas.y[1] = coordenadaX - 1;
                    break;
            }

            consola.ImprimirConsola("\n", 0); // Imprimir salto de línea.
        }

        /// <summary>
        /// Permite colocar los barcos en el mapa. LetraBarco representa la
        /// primera letra del tipo de barco correspondiente.
        /// </summary>
        public void ColocarBarco()
        {
            string letraBarco = "| " + tipo.Substring(0, 1).ToUpper() + " ";
            switch (horizontal)
            {
                case 0: // Orientación vertical. 
                    for (int i = 0; i < longitud; i++)
                    {
                        tablero.mapa[coordenadas.x[0] + i, coordenadas.y[0]] = letraBarco;
                    }
                    break;
                case 1: // Orientación horizontal.
                    for (int i = 0; i < longitud; i++)
                    {
                        tablero.mapa[coordenadas.x[0], coordenadas.y[0] + i] = letraBarco;
                    }
                    break;
            }


            tablero.Pintar();
            consola.Continuar();
        }
    }
}




