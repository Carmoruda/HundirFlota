﻿/// <summary>
/// 
/// La clase PartidaIndividual define los atributos que permiten
/// controlar las partidas del juego con el perfil
/// de un jugador humano contra un jugador automático.
/// 
/// <autores>LEdSM, OSV y CMU</autores>
/// <version>0.1</version>
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HundirFlota
{
    [Serializable]
    internal class PartidaIndividual : Partida
    {
        //Atributos

        /// <summary>
        /// Instancia de la clase Jugador que permite
        /// a un jugador humano participar en la partida.
        /// </summary>
        public Jugador jugador1 { get; set; }

        /// <summary>
        /// Instancia de la clase Jugador que permite
        /// a un jugador automático participar en la partida.
        /// </summary>
        public Jugador jugador2 { get; set; }

        //Constructores

        /// <summary>
        /// Constructor vacío de la clase PartidaIndividual. Inicializa
        /// las instancias de la clase Jugador.
        /// </summary>
        public PartidaIndividual()
        {
            jugador1 = new Jugador();
            jugador2 = new Jugador();
        }

        /// <summary>
        /// Constructor parametrizado de la clase PartidaIndividual.
        /// Inicializa las instancias de la clase Jugador.
        /// </summary>
        /// <param name="_jugador1">
        /// Instancia de Jugador que representa al jugador humano.
        /// </param>
        /// <param name="_jugador2">
        /// Instancia de Jugador que representa al jugador automático
        /// </param>
        /// <param name="_nombrePartida">
        /// String que representa el nombre de la partida.
        /// </param>
        public PartidaIndividual(Jugador _jugador1, Jugador _jugador2, string _nombrePartida) : base(false, 0, _nombrePartida)
        {
            jugador1 = _jugador1; // Humano.
            jugador2 = _jugador2; // Automático.
        }

        /// <summary>
        /// Constructor parametrizado de la clase PartidaIndividual.
        /// Asigna los valores de todos los atributos.
        /// </summary>
        /// <param name="_jugador1">
        /// Instancia de Jugador que representa al jugador humano.
        /// </param>
        /// <param name="_jugador2">
        /// Instancia de Jugador que repsenta al jugador automático
        /// </param>
        /// <param name="_finalizada">
        /// Booleano que reprsenta el estado de la partida
        /// (True ≡ Finalizada).
        /// </param>
        /// <param name="_numMovimientos">
        /// Entero que representa el número de movimientos que 
        /// han sido realizados en la partida.
        /// </param>
        /// <param name="_nombrePartida">
        /// String que representa el nombre de la partida.
        /// </param>
        /// <param name="_nombreGanador">
        /// String que representa el nombre del ganador.
        /// </param>
        public PartidaIndividual(Jugador _jugador1, Jugador _jugador2, bool _finalizada, int _numMovimientos, string _nombrePartida, string _nombreGanador)
        {
            jugador1 = _jugador1; // Humano.
            jugador2 = _jugador2; // Automático
            finalizada = _finalizada;
            numMovimientos = _numMovimientos;
            nombrePartida = _nombrePartida;
            nombreGanador = _nombreGanador;
        }

        // Métodos

        /// <summary>
        /// Muestra la información correspondiente a cada jugador
        /// de la partida.
        /// </summary>
        /// <returns>
        /// String que muestra el nombre del jugador 1 y del jugador 2.
        /// </returns>
        public override string InformacionJugadores()
        {
            return "\n\t * Jugador 1: " + jugador1.nombre + "\n\t * Jugador 2: " + jugador2.nombre;
        }

        /// <summary>
        /// Controla el inicio de una nueva partida, permitiendo
        /// al jugador 1 (Humano) colocar sus barcos.
        /// </summary>
        public override void NuevaPartida()
        {
            jugador1.NuevaPartida();
           
        }

        /// <summary>
        /// Permite jugar una partida entre dos jugadores.
        /// </summary>
        /// <param name="consola">
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </param>
        public override void Jugar(Pantalla consola)
        {
            bool continuar = true;

            while (continuar)
            {
                string texto = "------------------------------ PARTIDA " + nombrePartida.ToUpper() + " ------------------------------\n\t--------------------- TURNO DE ";

                if (numMovimientos % 2 != 0) // Turno jugador 1.
                {
                    texto += jugador1.nombre + " ----------------------\n\n";
                    consola.ImprimirConsola(texto, 1); // texto: -- TURNO DE...

                    jugador1.Atacar(); // Acción de atacar del jugador 1.

                    numMovimientos++; // +1 Movimiento.
                    continuar = SalirPartida(consola); // Salir o continuar.

                }
                else // Turno jugador 2.
                {
                    texto += jugador2.nombre + " ----------------------\n\n";
                    consola.ImprimirConsola(texto, 1); // texto: -- TURNO DE...

                    jugador2.Automático(); // Acción de atacar del jugador 2.

                    numMovimientos++; // +1 Movimiento.
                    continuar = SalirPartida(consola); // Salir o continuar.

                }
            }
        }
    }

}
