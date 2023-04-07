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
    internal class Tablero
    {
        // Atributos

        /// <summary>
        /// Array bidimesional de strings que representa el mapa
        /// del juego.
        /// </summary>
        public String[,] mapa { get; set; }

        /// <summary>
        /// Lista de enteros que representan las coordenadas de las 
        /// zonas de tierra en el mapa.
        /// </summary>
        public List<int> zonasTierra = new List<int>();

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
            zonasTierra = new List<int>();
            mapa = new string[12, 12];
            RellenarTableroInicial(mapa); // esto no es muy buena practica?? pq quiero llamarlo cada vez que accedo al contstructor

        }

        /// <summary>
        /// Constructor parametrizado de la clase Juego. Inicializa el 
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
        public Tablero(List<int> _zonasTierra, String[,] _mapa)
        {
            consola = new Pantalla();
            zonasTierra = _zonasTierra;
            mapa = _mapa;
            RellenarTableroInicial(mapa); // esto no es muy buena practica?? pq quiero llamarlo cada vez que accedo al contstructor
            
        }


        // Métodos 


        public void RellenarTableroInicial(String[,] mapa) // creo esta funcion pq modifico el contenido cuando pongo barcos
        {
            for (int i = 0; i<12; i++)
            {
                for (int j = 0; j<12; j++)
                {
                    mapa[i, j] = "| _ ";
                }
            }
        }
        public void Pintar()
        {
            consola.PintarTablero(mapa, 0, 0);

        }
    }
}
