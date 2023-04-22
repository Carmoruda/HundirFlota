/// <summary>
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
        public Jugador jugadorHumano { get; set; }

        /// <summary>
        /// Instancia de la clase Jugador que permite
        /// a un jugador automático participar en la partida.
        /// </summary>
        public Jugador jugadorAutomatico { get; set; }

        //Constructores

        /// <summary>
        /// Constructor vacío de la clase PartidaIndividual. Inicializa
        /// las instancias de la clase Jugador.
        /// </summary>
        public PartidaIndividual()
        {
            jugadorHumano = new Jugador();
            jugadorAutomatico = new Jugador();
        }

        /// <summary>
        /// Constructor parametrizado de la clase PartidaIndividual.
        /// Inicializa las instancias de la clase Jugador.
        /// </summary>
        /// <param name="_jugadorHumano">
        /// Instancia de Jugador que representa al jugador humano.
        /// </param>
        /// <param name="_jugadorAutomatico">
        /// Instancia de Jugador que representa al jugador automático
        /// </param>
        /// <param name="_nombrePartida">
        /// String que representa el nombre de la partida.
        /// </param>
        public PartidaIndividual(Jugador _jugadorHumano, Jugador _jugadorAutomatico, string _nombrePartida) : base(false, 1, _nombrePartida)
        {
            jugadorHumano = _jugadorHumano; // Humano.
            jugadorAutomatico = _jugadorAutomatico; // Automático.
        }

        /// <summary>
        /// Constructor parametrizado de la clase PartidaIndividual.
        /// Asigna los valores de todos los atributos.
        /// </summary>
        /// <param name="_jugadorHumano">
        /// Instancia de Jugador que representa al jugador humano.
        /// </param>
        /// <param name="_jugadorAutomatico">
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
        public PartidaIndividual(Jugador _jugadorHumano, Jugador _jugadorAutomatico, bool _finalizada, int _numMovimientos, string _nombrePartida, string _nombreGanador)
        {
            jugadorHumano = _jugadorHumano; // Humano.
            jugadorAutomatico = _jugadorAutomatico; // Automático
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
            return "\n\t * Jugador 1: " + jugadorHumano.nombre + "\n\t * Jugador 2: " + jugadorAutomatico.nombre;
        }

        /// <summary>
        /// Controla el inicio de una nueva partida, permitiendo
        /// al jugador 1 (Humano) colocar sus barcos.
        /// </summary>
        public override void NuevaPartida()
        {
            jugadorHumano.NuevaPartida("MANUAL");
            jugadorAutomatico.NuevaPartida("AUTOMATICO");
           
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
            Coordenadas coordenadasAtaque = new Coordenadas();
            bool continuar = true;
            jugadorHumano.tablero.zonasBarcosOponente = jugadorAutomatico.tablero.zonasBarcos;
            jugadorAutomatico.tablero.zonasBarcosOponente = jugadorHumano.tablero.zonasBarcos;


            while (continuar)
            {
                string texto = "------------------------------ PARTIDA " + nombrePartida.ToUpper() + " ------------------------------\n\t--------------------- TURNO DE ";

                if (numMovimientos % 2 != 0) // Turno jugador 1.
                {
                    texto += jugadorHumano.nombre.ToUpper() + " ----------------------\n\n                                MAPA OPONENTE:\n\n";
                    consola.ImprimirConsola(texto, 1); // texto: -- TURNO DE...

                    coordenadasAtaque = jugadorHumano.Atacar("MANUAL");

                    jugadorAutomatico.EstadoBarcos(jugadorHumano.coordenadasLanzamientos, coordenadasAtaque, jugadorHumano.tablero); // Acción de atacar del jugador 1.

                    jugadorHumano.coordenadasLanzamientos.Add(coordenadasAtaque);

                    numMovimientos++; // +1 Movimiento.
                    finalizada = EstadoPartida(); // Comprobar si la partida ha finalizado.

                    if (finalizada)
                    {
                        consola.ImprimirConsola(InformacionStatus(), 0);
                        continuar = false;
                        break;
                    }

                    continuar = SalirPartida(consola); // Salir o continuar.

                }
                else // Turno jugador 2.
                {
                    texto += jugadorAutomatico.nombre.ToUpper() + " ----------------------\n\n";
                    consola.ImprimirConsola(texto, 1); // texto: -- TURNO DE...

                    coordenadasAtaque = jugadorAutomatico.Atacar("AUTOMATICO");

                    jugadorHumano.EstadoBarcos(jugadorAutomatico.coordenadasLanzamientos, coordenadasAtaque, jugadorAutomatico.tablero); // Acción de atacar del jugador 2.

                    jugadorAutomatico.coordenadasLanzamientos.Add(coordenadasAtaque);

                    numMovimientos++; // +1 Movimiento.
                    finalizada = EstadoPartida(); // Comprobar si la partida ha finalizado.

                    if (finalizada)
                    {
                        consola.ImprimirConsola(InformacionStatus(), 0);
                        continuar = false;
                        break;
                    }

                    continuar = SalirPartida(consola); // Salir o continuar.

                }
            }
        }

        /// <summary>
        /// Permite comprobar el estado de la partida y cambiarlo
        /// si ésta a terminado.
        /// </summary>
        /// <returns>
        /// Booleano que representa si la partida ha finalizado.
        /// </returns>
        public override bool EstadoPartida()
        {
            Pantalla consola = new Pantalla();

            if (jugadorHumano.portaaviones.hundido && jugadorHumano.patrullero.hundido && jugadorHumano.submarino.hundido && jugadorHumano.destructor.hundido)
            {
                nombreGanador = jugadorAutomatico.nombre; // Victoria del jugador 2.
                return true; // Partida finalizada.

            }
            else if (jugadorAutomatico.portaaviones.hundido && jugadorAutomatico.patrullero.hundido && jugadorAutomatico.submarino.hundido && jugadorAutomatico.destructor.hundido)
            {
                nombreGanador = jugadorHumano.nombre; // Victoria del jugador 1
                return true; // Partida finalizada.
            }

            return base.EstadoPartida(); // False.
        }
    }

}
