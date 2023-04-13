/// <summary>
/// 
/// La clase Tablero define los atributos necesarios 
/// para el control de los tableros de los jugadores
/// del juego.
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
    internal class Tablero
    {
        // Atributos

        /// <summary>
        /// Array bidimesional de strings que representa el mapa
        /// del jugador.
        /// </summary>
        public String[,] mapa { get; set; }

        /// <summary>
        /// Array bidimesional de strings que representa el mapa
        /// del oponente.
        /// </summary>
        public String[,] mapaOponente { get; set; }

        /// <summary>
        /// Lista de la clase Coordenadas que representan las coordenadas de las 
        /// zonas de tierra en el mapa.
        /// </summary>
        public List<Coordenadas> zonasTierra = new List<Coordenadas>();

        /// <summary>
        /// Lista de la clase Coordenadas que representan las coordenadas de los 
        /// barcos en el mapa.
        /// </summary>
        public List<Coordenadas> zonasBarcos = new List<Coordenadas>();

        /// <summary>
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del tablero.
        /// </summary>
        public Pantalla consola { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la case Tablero. Inicializa los
        /// atributos de consola, zonasTierra y el mapa.
        /// </summary>
        public Tablero()
        {
            consola = new Pantalla();
            zonasTierra = new List<Coordenadas>();
            mapa = new string[12, 12];
            mapaOponente = new string[12, 12];
        }

        /// <summary>
        /// Constructor parametrizado de la clase Tablero. Inicializa el 
        /// atributo consola y asigna el valor de zonasTierra y mapa.
        /// </summary>
        /// <param name="_zonasTierra">
        /// Lista de enteros que representan las coordenadas de las zonas
        /// de tierra en el mapa.
        /// </param>
        /// <param name="_mapa">
        /// Array bidimesional de string que representa el mapa
        /// del juego.
        /// </param>
        public Tablero(List<Coordenadas> _zonasTierra, String[,] _mapa) : this()
        {
            zonasTierra = _zonasTierra;
            mapa = _mapa;
        }

        /// <summary>
        /// Constructor parametrizado de la clase Tablero. Inicializa el 
        /// atributo consola y asigna el valor de zonasTierra y mapa.
        /// </summary>
        /// <param name="_mapa">
        /// Array bidimesional de string que representa el mapa
        /// del juego.
        /// </param>
        /// <param name="_zonasTierra">
        /// Lista de enteros que representan las coordenadas de las zonas
        /// de tierra en el mapa.
        /// </param>
        /// <param name="_zonasBarcos">
        /// Lista de enteros que representan las coordenadas de las zonas
        /// de barcos en el mapa.
        /// </param>
        /// <param name="_consola">
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </param>
        public Tablero(string[,] _mapa, List<Coordenadas> _zonasTierra, List<Coordenadas> _zonasBarcos, Pantalla _consola)
        {
            mapa = _mapa;
            zonasTierra = _zonasTierra;
            zonasBarcos = _zonasBarcos;
            consola = _consola;
        }

        // Métodos 

        /// <summary>
        /// Permite colocar los trozos de tierra en el mapa y
        /// añadir las coordenadas a la lista de zonasTierra.
        /// </summary>
        public void RellenarTierra()
        {
            zonasTierra.Clear();
            int[] coordenadasX   = { 1, 1, 1, 3, 3, 3,  3, 5, 5, 5, 7,  7, 8, 8}; // Cordenadas eje X.
            int[] coordenadasY   = { 1, 2, 8, 6, 7, 9, 10, 3, 4, 5, 2, 10, 3, 9}; // Cordenadas eje Y.
            int[] longitudTierra = { 1, 2, 3, 1, 1, 1,  1, 1, 2, 3, 3,  4, 2, 2}; // Longitud trozos de tierra.

          

            for (int i = 0; i < coordenadasX.Length; i++)
            {
                Coordenadas nuevasCoordenas = new Coordenadas();

                nuevasCoordenas.x[0] = coordenadasX[i];
                nuevasCoordenas.x[1] = coordenadasX[i] + longitudTierra[i] - 1;

                nuevasCoordenas.y[0] = nuevasCoordenas.y[1] = coordenadasY[i];
                
                zonasTierra.Add(nuevasCoordenas); // Añadir coordenadas a la lista de zonasTierra.

                for (int j = 0; j  < longitudTierra[i]; j++)
                {
                    mapa[coordenadasY[i], coordenadasX[i] + j] = "| X ";
                    mapaOponente[coordenadasY[i], coordenadasX[i] + j] = "| X ";
                }
            }
        }

        /// <summary>
        /// Permite colocar los barcos en el mapa y
        /// añadir las coordenadas a la lista de zonasBarcos.
        /// </summary>
        /// <param name="orientacion">
        /// Entero que representa la orientación 
        /// del barco (0 - Vertical, 1 - Horizontal).
        /// </param>
        /// <param name="letraBarco">
        /// String que representa la letra del barco en el mapa.
        /// </param>
        /// <param name="longitud">
        /// Entero que determina la longitud del barco.
        /// </param>
        /// <param name="coordenadas">
        /// Instancia de la clase Coordenadas para controlar
        /// las posiciones de las letras dentro del mapa.
        /// </param>
        public void RellenarBarcos(int orientacion, string letraBarco, int longitud, Coordenadas coordenadas)
        {
            zonasBarcos.Add(coordenadas); // Añadir coordenadas a la lista de zonasBarcos.

            switch (orientacion)
            {
                case 0: // Orientación vertical. 
                    for (int i = 0; i < longitud; i++)
                    {
                        mapa[coordenadas.y[0] + i, coordenadas.x[0]] = letraBarco;
                    }
                    break;
                case 1: // Orientación horizontal.
                    for (int i = 0; i < longitud; i++)
                    {
                        mapa[coordenadas.y[0], coordenadas.x[0] + i] = letraBarco;
                    }
                    break;
            }
        }

        /// <summary>
        /// Permite rellenar el tablero con su estado inicial (todo agua).
        /// </summary>
        /// <param name="mapa">
        /// Array bidimesional de strings que representa el mapa
        /// del jugador.
        /// </param>
        /// <param name="mapaOponente">
        /// Array bidimesional de strings que representa el mapa
        /// del oponente.
        /// </param>
        public void RellenarTableroInicial(String[,] mapa, String[,] mapaOponente)
        {
            for (int i = 0; i<12; i++)
            {
                for (int j = 0; j<12; j++)
                {
                    mapa[i, j] = "| _ ";
                    mapaOponente[i, j] = "| _ ";
                }
            }
        }

        /// <summary>
        /// Permite pintar el mapa del jugador.
        /// </summary>
        public void PintarPropio()
        {
            consola.PintarTablero(mapa);
        }

        /// <summary>
        /// Permite pintar el mapa del oponente.
        /// </summary>
        public void PintarOponente()
        {
            consola.PintarTablero(mapaOponente);
        }

    }
}
