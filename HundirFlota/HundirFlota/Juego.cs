﻿/// <summary>
/// 
/// La clase Juego define los atributos y métodos necesarios
/// para el correcto funcionamiento de la gestión de partidas
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
    internal class Juego
    {

        // Atributos

        /// <summary>
        /// Lista de instancias de Partida que almacena todas las
        /// partidas de un jugador VS otro jugador humano o automático.
        /// </summary>
        public List<Partida> listaPartidas { get; set; }

        /// <summary>
        /// Intacia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </summary>
        public Pantalla consola { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase Juego. Inicializa el
        /// atributo consola y la lista de partidas.
        /// </summary>
        public Juego() 
        {
            consola = new Pantalla();
            listaPartidas = new List<Partida>();
        }

        /// <summary>
        /// Constructor parametrizado de la clase Juego. Inicializa
        /// el atributo consola y la lista de barcos.
        /// </summary>
        /// <param name="_listaPartidas">
        /// Lista que representa las partidas del Juego.
        /// </param>
        public Juego(List<Partida> _listaPartidas)
        {
            consola = new Pantalla();
            listaPartidas = _listaPartidas;
        }

        // Métodos

        /// <summary>
        /// Información del nombre del juego, fecha 
        /// y hora actuales.
        /// </summary>
        public void NuevaSesion()
        {
            string bienvenidaJuego = "------------------------------ HUNDIR LA FLOTA ------------------------------\n\n";
            bienvenidaJuego += "\t *   Hora: " + DateTime.Now.ToString("HH:mm tt") + "\n";
            bienvenidaJuego += "\t *   Día: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n";
            consola.ImprimirConsola(bienvenidaJuego, 0);
        }

        /// <summary>
        /// Menú principal del juego. Permite crear nuevas partidas (1 y 2 jugadores),
        /// cargar partidas anteriores y ver el ranking.
        /// </summary>
        public void Menu()
        {
            int accionMenu = 0;

            string[] opciones = { "\n  Seleccione una de las siguientes opciones:\n",
                                  "\t1   Cargar una partida anterior.",
                                  "\t2   Jugar una partida de 2 jugadores.",
                                  "\t3   Jugar una partida de 1 jugador.",
                                  "\t4   Ranking."};

            do
            {
                NuevaSesion();

                accionMenu = consola.PintarMenu(opciones, 0);

                switch (accionMenu)
                {
                    case 1:
                        CargarPartidas();
                        break;
                    case 2:
                        CrearPartida(2);
                        break;
                    case 3:
                        CrearPartida(1);
                        break;
                    case 4:
                        RankingPartidas();
                        break;
                    case 5: // Salir.
                        Environment.Exit(0);
                        break;
                    default: // Mensaje Error.
                        consola.ImprimirConsola("  Error! El valor introducido debe estar entre 1 y 5.\n\n", 0);
                        break;

                }
            } while (true);

        }

        /// <summary>
        /// Muestra un listado de todas las partidas que no han finalizado,
        /// permitiendo elegir una para continuarla.
        /// </summary>
        public void CargarPartidas()
        {
            
        }

        /// <summary>
        /// Recoge la información básica necesaria para la creación de 
        /// una nueva partida.
        /// </summary>
        /// <param name="numJugadores">
        /// Entero que representa el número de jugadores humanos de la
        /// partida.
        /// </param>
        public void CrearPartida(int numJugadores)
        {

        }

        /// <summary>
        /// Muestra todas las partidas que han finalizado en victoria
        /// y muestra su información (Nombre jugadores, número movimientos
        /// y ganador).
        /// </summary>
        public void RankingPartidas()
        {

        }
    }
}
