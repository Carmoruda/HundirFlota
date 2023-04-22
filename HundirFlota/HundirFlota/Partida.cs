/// <summary>
/// 
/// La clase Partide define los atributos que permiten
/// controlar las partidas del juego dentro del juego.
/// 
/// <autores>LEdSM, OSV y CMU</autores>
/// <version>0.1</version>
/// </summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HundirFlota
{
    [Serializable]

    internal abstract class Partida
    {
        // Atributos

        /// <summary>
        /// Booleano que reprsenta el estado de la partida
        /// (True ≡ Finalizada).
        /// </summary>
        public bool finalizada { get; set; }

        /// <summary>
        /// Entero que representa el número de movimientos que 
        /// han sido realizados en la partida.
        /// </summary>
        public int numMovimientos { get; set; }

        /// <summary>
        /// String que representa el nombre de la partida.
        /// </summary>
        public string nombrePartida { get; set; }

        /// <summary>
        /// String que representa el nombre del jugador ganador.
        /// </summary>
        public string nombreGanador { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase Partida. Inicializa el
        /// atributo de tablero y asigna valores a finalizada, a
        /// numMovimientos y a nombrePartida.
        /// </summary>
        public Partida()
        {
            finalizada = false;
            numMovimientos = 1;
            nombrePartida = "Partida" + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
        }

        /// <summary>
        /// Constructor parametrizado de la clase Partida. Inicializa el
        /// atributo tablro y asigna el valor de finalizada y numMovimientos.
        /// </summary>
        /// <param name="_finalizada">
        /// Booleano que representa si la partida ha sido finalizada.
        /// </param>
        /// <param name="_numMovimientos">
        /// Entero que representa el número de movimientos que han sido
        /// realizados en la partida.
        /// </param>
        /// <param name="_nombrePartida">
        /// String que representa el nombre de la partida.
        /// </param>
        public Partida (bool _finalizada, int _numMovimientos, string _nombrePartida)
        {
            finalizada = _finalizada;
            numMovimientos= _numMovimientos;
            nombrePartida = _nombrePartida;
        }

        /// <summary>
        /// onstructor parametrizado de la clase Partida. Asigna
        /// los valores de todos los atributos.
        /// </summary>
        /// <param name="_finalizada">
        /// Booleano que reprsenta el estado de la partida
        /// (True ≡ Finalizada)
        /// </param>
        /// <param name="_numMovimientos">
        /// Entero que representa el número de movimientos que 
        /// han sido realizados en la partida.
        /// </param>
        /// <param name="_nombrePartida">
        /// String que representa el nombre de la partida.
        /// </param>
        /// <param name="_nombreGanador">
        /// String que representa el nombre del jugador ganador.
        /// </param>
        public Partida(bool _finalizada, int _numMovimientos, string _nombrePartida, string _nombreGanador)
        {
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
        public virtual string InformacionJugadores()
        {
            return "No hay jugadores";
        }

        /// <summary>
        /// Controla el inicio de una nueva partida.
        /// </summary>
        public virtual void NuevaPartida()
        {
        }

        /// <summary>
        /// Muestra la información correspondiente al status
        /// de la partida
        /// </summary>
        /// <returns>
        /// String que muestra el nombre del jugador 1 y del jugador 2.
        /// </returns>
        public string InformacionStatus()
        {
            finalizada = EstadoPartida(); // Comprobar si la partida ha finalizado.

            switch (finalizada)
            {
                case true:
                    return "Partida finalizada.";
                case false:
                    return "Partida no finalizada.";

            }

            return "\n\t * Jugadores: No hay información del estatus.";
        }

        /// <summary>
        /// Permite jugar una partida entre dos jugadores.
        /// </summary>
        /// <param name="consola">
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </param>
        public virtual void Jugar(Pantalla consola)
        {
            
        }

        /// <summary>
        /// Permite continuar una partida o guardar y volver
        /// al menú principal.
        /// </summary>
        /// <param name="consola">
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </param>
        /// <returns></returns>
        public bool SalirPartida(Pantalla consola)
        {
            int accionSalir = 0;

            string[] opciones = { "\n  Seleccione una de las siguientes opciones:\n",
                                  "\t1   Continuar partida.",
                                  "\t2   Guardar y salir."};

            do
            {
                accionSalir = consola.PintarMenu(opciones, 0, 0);

                switch (accionSalir)
                {
                    case 1:
                        return true; // Continuar partida.
                    case 2:
                        return false; // Volver al menú
                }
            } while (true);

        }

        /// <summary>
        /// Permite comprobar el estado de la partida y cambiarlo
        /// si ésta a terminado.
        /// </summary>
        /// <returns>
        /// Booleano que representa si la partida ha finalizado.
        /// </returns>
        public virtual bool EstadoPartida()
        {
            return false;
        }

    }
}
