﻿/// <summary>
/// 
/// La clase Coordenadas define los atributos y métodos necesarios
/// para el correcto funcionamiento de las coordenadas de los barcos.
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
    [Serializable]
    internal class Coordenadas
    {
        // Atributos

        /// <summary>
        /// Array de enteros que representa la coordenada en 
        /// el eje X del barco.
        /// </summary>
        public int[] x {  get; set; }

        /// <summary>
        /// Array de enteros que representa la coordenada en 
        /// el eje Y del barco.
        /// </summary>
        public int[] y { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase jugador.
        /// </summary>
        public Coordenadas() 
        {
            x = new int[2];
            y = new int[2];
        }

        /// <summary>
        /// Constructor parametrizado de la clase Coordenadas. Asigna
        /// los valor de las coordenas x e y del barco.
        /// </summary>
        /// <param name="_x">
        /// Array de enteros que representa la coordenada X del barco.
        /// </param>
        /// <param name="_y">
        /// Array de enteros que representa la coordenada Y del barco.
        /// </param>
        public Coordenadas(int[] _x, int[] _y)
        {
            x = _x;
            y = _y;
        }

        // Métodos

        /// <summary>
        /// Permite controlar las coordenadas introducidas
        /// en función de la acción que se deseé realizar.
        /// </summary>
        /// <param name="orientacion">
        /// Entero que representa la orientación 
        /// de la entidad que se quiere introducir
        /// (0 - Vertical, 1 - Horizontal).
        /// </param>
        /// <param name="longitud">
        /// Entero que representa la longitud
        /// de la entidad que se quiere introducir.
        /// </param>
        /// <param name="consola">
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </param>
        /// <param name="tablero">
        /// Instancia de la clase Tablero para controlar los
        /// elementos del tablero.
        /// </param>
        /// <param name="opciones">
        /// String array que representa las diferentes opciones del menú.
        /// </param>
        /// <param name="objeto">
        /// String que representa la entidad que se quiere introducir.
        /// </param>
        /// <param name="mostrarOponente">
        /// Booleano que indica si se desea pintar el tablero del oponente.
        /// </param>
        /// <param name="modo">
        /// String que representa tipo de modo de juego de la partida.
        /// </param>
        /// <param name="nombreJugador">
        /// String que representa el nombre del jugador.
        /// </param>
        public void ControlIntroducirCoordenadas(int orientacion, int longitud, Pantalla consola, Tablero tablero, string[] opciones, string objeto, bool mostrarOponente, string modo, string nombreJugador)
        {
            int coordenadaX = 0;
            int coordenadaY = 0;
            bool coincideConAlgo = true;
            int indice = 0;

            if (!mostrarOponente && nombreJugador != "Autómata")
            {
                tablero.PintarPropio(); // Mostrar el tablero.
            }
            else if (nombreJugador != "Autómata")
            {
                tablero.PintarOponente(); // Mostrar el tablero del oponente.
            }

            do
            {
                coordenadaX = IntroducirCoordenadas(orientacion, longitud, consola, opciones, objeto, 0, "x", modo);
                coordenadaY = IntroducirCoordenadas(orientacion, longitud, consola, opciones, objeto, 1, "y", modo);

                switch (objeto) // Asignación de las coordenadas.
                {
                    case "BARCO":
                        if (orientacion == 0) // Orientación vertical.
                        {
                            x[0] = x[1] = coordenadaX - 1;

                            y[0] = coordenadaY - 1;
                            y[1] = coordenadaY + longitud - 2;
                        }
                        else // Orientación horizontal
                        {
                            y[0] = y[1] = coordenadaY - 1;

                            x[0] = coordenadaX - 1;
                            x[1] = coordenadaX + longitud - 2;
                            break;
                        }
                        break;
                    case "ATACAR":
                        x[0] = x[1] = coordenadaX - 1;
                        y[0] = y[1] = coordenadaY - 1;
                        break;
                }

                coincideConAlgo = ComprobarCoordenadasCoincidente(tablero, ref indice, objeto);

                TextoCoincidencia(objeto, coincideConAlgo, indice, opciones, consola, tablero, modo);

                if(objeto == "ATACAR")
                {
                    return;
                }



            } while (coincideConAlgo);

            consola.ImprimirConsola("\n", 0); // Imprimir salto de línea.
        }

        /// <summary>
        /// Permite que el usuario introduzca coordenadas.
        /// </summary>
        /// <param name="orientacion">
        /// Entero que representa la orientación 
        /// de la entidad que se quiere introducir
        /// (0 - Vertical, 1 - Horizontal).
        /// </param>
        /// <param name="longitud">
        /// Entero que representa la longitud
        /// de la entidad que se quiere introducir.
        /// </param>
        /// <param name="consola">
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </param>
        /// <param name="tablero">
        /// Instancia de la clase Tablero para controlar los
        /// elementos del tablero.
        /// </param>
        /// <param name="opciones">
        /// String array que representa las diferentes opciones del menú.
        /// </param>
        /// <param name="objeto">
        /// String que representa la entidad que se quiere introducir.
        /// </param>
        /// <param name="indice">
        /// Entero que representa el indice del elemento del array
        /// opciones que se desea mostrar por pantalla.
        /// </param>
        /// <param name="tipo">
        /// String que representa el eje de la coordenada introducida (X, Y).
        /// </param>
        /// <param name="modo">
        /// String que representa tipo de modo de juego de la partida.
        /// </param>
        /// <returns>
        /// Entero que representa la coordenada introducida en su respectivo eje.
        /// </returns>
        public int IntroducirCoordenadas (int orientacion, int longitud, Pantalla consola, string[] opciones, string objeto, int indice, string tipo, string modo)
        {
            int coordenada = 0;
            do // Coordenadas eje. 
            {
                if (modo == "AUTOMATICO")
                {
                    int seed = Environment.TickCount;
                    Random r = new Random(seed);
                    coordenada = r.Next(1, 12); // Opciones[0]: * Coordenada ...
                }
                else
                {
                    coordenada = consola.LeerEntero(opciones[indice], 1, 12); // Opciones[0]: * Coordenada ...
                }

                if (objeto == "BARCO" && modo != "AUTOMATICO") 
                {
                    if (coordenada + longitud - 1 > 12 && tipo.ToUpper() == "X" && orientacion == 1) // Mensaje de error cuando se sale del tablero.
                    {
                        consola.ImprimirConsola(opciones[2] + coordenada + " se sale del tablero.\n", 0); // Error, ... se sale del tablero
                    } else if (coordenada + longitud - 1 > 12 && tipo.ToUpper() == "Y" && orientacion == 0)
                    {
                        consola.ImprimirConsola(opciones[2] + coordenada + " se sale del tablero.\n", 0); // Error, ... se sale del tablero
                    }
                } 
            } while (coordenada < 1 || coordenada > 12 || (coordenada + longitud - 1 > 12 && orientacion == 0 && tipo.ToUpper() == "Y") 
                    || (coordenada + longitud - 1 > 12 && orientacion == 1 && tipo.ToUpper() == "X"));

            return coordenada;
        }

        /// <summary>
        /// Permite comprobar si las coordenadas introducidas coinciden
        /// con alguna entidad en el tablero y devuelve el indice (para
        /// el array de opciones que indica el tipo de elemento con el 
        /// que coincide (tierra = 4, barco = 3).
        /// </summary>
        /// <param name="tablero">
        /// Instancia de la clase Tablero para controlar los
        /// elementos del tablero.
        /// </param>
        /// <param name="indice">
        /// Entero que representa el indice del elemento del array
        /// que se desea mostrar por pantalla.
        /// </param>
        /// <returns>
        /// Booleano que representa si en las coordenadas introducidas
        /// existe al menos 1 entidad (true - coincide, false - no coincide).
        /// </returns>
        public bool ComprobarCoordenadasCoincidente(Tablero tablero, ref int indice, string modo)
        {

            if (modo == "BARCO" && BuscarEntidad(tablero.zonasBarcos)) // Buscar barcos.
            {
                indice = 3; // Error! Ya hay otro barco...
                return true;
            }
            else if (BuscarEntidad(tablero.zonasTierra)) // Buscar tierra.
            {
                indice = 4; // Error! Hay una zona de...
                return true;
            }
            else if (modo == "ATACAR" && BuscarEntidad(tablero.zonasBarcosOponente))
            {
                indice = 3;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Permite imprimir el texto que indica con que coinciden las coordenadas introducidas.
        /// </summary>
        /// <param name="objeto">
        /// String que representa la entidad que se quiere introducir.
        /// </param>
        /// <param name="coincideConAlgo">
        /// Booleano que representa si las coordenadas introducidas coinciden con algún otro 
        /// objeto en el Tablero.
        /// </param>
        /// <param name="indice">
        /// Entero que representa el indice del elemento del array
        /// que se desea mostrar por pantalla.
        /// </param>
        /// <param name="opciones">
        /// String array que representa las diferentes opciones del menú.
        /// </param>
        /// <param name="consola">
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </param>
        /// <param name="modo">
        /// String que representa tipo de modo de juego de la partida.
        /// </param>
        public void TextoCoincidencia(string objeto, bool coincideConAlgo, int indice, string[] opciones, Pantalla consola, Tablero tablero, string modo)
        {
            if (objeto == "BARCO" && coincideConAlgo && modo != "AUTOMATICO")
            {
                consola.ImprimirConsola(opciones[indice], 0);
            }
            else if (objeto == "ATACAR" && coincideConAlgo)
            {
                switch (indice)
                {
                    case 3: // Disparo bombardea barco.
                        consola.ImprimirConsola("\t* Resultado disparo: Barco tocado.\n\n", 0);
                        tablero.mapaOponente[y[0], x[0]] = "| ¬ "; // Cambiar caracter tablero.
                        tablero.PintarOponente();
                        return;
                    case 4: // Disparo bombardea tierra.
                        consola.ImprimirConsola("\t* Resultado disparo: Tierra bombardeada.\n\n", 0);
                        tablero.mapaOponente[y[0], x[0]] = "| # "; // Cambiar caracter tablero.
                        tablero.PintarOponente();
                        return;
                }
            }
            else if (objeto == "ATACAR" && !coincideConAlgo) // Disparo bombardea agua.
            {
                consola.ImprimirConsola("\t* Resultado disparo: Agua.\n\n", 0);
                tablero.mapaOponente[y[0], x[0]] = "| ~ "; // Cambiar caracter tablero.
                tablero.PintarOponente();
                return;
            }
        }

        /// <summary>
        /// Busca si existen entidades donde al menos 1 de las 
        /// coordenadas coincida.
        /// </summary>
        /// <param name="coordenadas">
        /// Instancias de la clase Coordenadas que representa
        /// las coordenadas del barco que se quiere colocar.
        /// </param>
        /// <returns>
        /// Devuelve un booleano que es verdadero si existe al menos 1 barco
        /// donde coincida mínimo 1 de las coordenadas.
        /// </returns>
        public bool BuscarEntidad(List<Coordenadas> listacoordenadas)
        {
            for (int i = 0; i < listacoordenadas.Count; i++)
            {
                if ((x[0] <= listacoordenadas[i].x[0] && listacoordenadas[i].x[0] <= x[1]) || listacoordenadas[i].x[0] <= x[0] && x[0] <= listacoordenadas[i].x[1])
                {
                    if ((listacoordenadas[i].y[0] <= y[0] && y[0] <= listacoordenadas[i].y[1]) || y[0] <= listacoordenadas[i].y[0] && listacoordenadas[i].y[0] <= y[1])
                    { return true; }
                }

            }

            return false;
        }
    }
}
