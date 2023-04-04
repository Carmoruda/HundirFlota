/// <summary>
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
        /// Instancia de la clase Pantalla para controlar la entrada
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
        /// el atributo consola y asigna el valor la lista de barcos.
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
                                  "\t2   Crear una partida de 2 jugadores.",
                                  "\t3   Crear una partida de 1 jugador.",
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
                        CrearPartida(2); // Partida Múltiple.
                        break;
                    case 3:
                        CrearPartida(1); // Partida Individual.
                        break;
                    case 4:
                        RankingPartidas();
                        break;
                    case 5: // Salir.
                        Environment.Exit(0);
                        break;
                    default: // Mensaje error desde PintarMenu en Pantalla.
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
            consola.ImprimirConsola("------------------------------ LISTADO PARTIDAS ------------------------------\n\n", 1);

            foreach (Partida partida in listaPartidas)
            {
                string informacion = "\n   * Partida: " + partida.nombrePartida + ": \n" + partida.InformacionJugadores() + "\n\t * Número Movimientos: " + partida.numMovimientos + "\n\t * Estatus: " + partida.InformacionStatus() + "\n";
                consola.ImprimirConsola(informacion, 0);
                consola.ImprimirConsola("\n", 0);
            }

            consola.Continuar(); // Pulsa enter para continuar.
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
            string[] opciones = {"------------------------------ NUEVA PARTIDA ------------------------------\n\n\nInformación partida:\n\n",
                                  "\t * Nombre de la Partida: ",
                                  "\t * Nombre Jugador 1: ",
                                  "\t * Nombre Jugador 2: ",
                                  "\n  Partida creada correctamente.\n\n",
                                  "\n  Ya existe una partida con ese nombre.\n"};

            Jugador nuevoJugador1; // Instancia jugador1.
            Jugador nuevoJugador2; // Instancia jugador2.

            consola.ImprimirConsola(opciones[0], 1); // Opciones[0]: -- NUEVA PARTIDA --...
            string nuevoNombrePartida = consola.LeerString(opciones[1]); // Opciones[1]: * Nombre de la Partida.
        

            // Búscar otra partida con el nombre introducido.
            Partida partidaInsertar = BuscarPartida(nuevoNombrePartida);
            if (partidaInsertar != null) // Ya existe.
            {
                consola.ImprimirConsola(opciones[5], 0); // Opciones[4]: Ya existe una partida con ese nombre.
                consola.Continuar(); // Pulsar enter para continuar.
                return; // Volver al menú.
            }

            nuevoJugador1 = new Jugador(consola.LeerString(opciones[2])); // Opciones[2]: * Nombre Jugador 1.

            switch (numJugadores) // Partida de 1 o 2 jugadores.
            {
                case 1: // Individual (Humano VS Auto)
                    opciones[3] = "\t * Nombre Jugador 2: " + "Autómata"; // Opciones[3]: * Nombre Jugador 2 = Autómata.

                    consola.ImprimirConsola(opciones[3], 0);

                    nuevoJugador2 = new Jugador("Autómata");
                    partidaInsertar = new PartidaIndividual(nuevoJugador1, nuevoJugador2, nuevoNombrePartida);
                    break;
               
                case 2: // Multiple (Humano VS Humano)
                    nuevoJugador2 = new Jugador(consola.LeerString(opciones[3])); // Opciones[3]: * Nombre Jugador 2.
                    partidaInsertar = new PartidaMultiple(nuevoJugador1, nuevoJugador2, nuevoNombrePartida);
                    break;
            }

            listaPartidas.Add(partidaInsertar);

            consola.ImprimirConsola(opciones[4], 0);// Opciones[4]: Partida creada correctamente.
            consola.Continuar(); // Pulsar enter para continuar.
        }

        /// <summary>
        /// Muestra todas las partidas que han finalizado en victoria
        /// y muestra su información (Nombre jugadores, número movimientos
        /// y ganador).
        /// </summary>
        public void RankingPartidas()
        {

        }

        /// <summary>
        /// Busca si existe una partida con el nombre introducido.
        /// </summary>
        /// <param name="nombre">
        /// String que representa el nombre de la partida que se 
        /// busca.
        /// </param>
        /// <returns>
        /// Si existe, devuleve ese objeto de tipo Barco.
        /// En el caso contrario, devuelve una referencia nula.
        /// </returns>
        public Partida BuscarPartida(string nombre)
        {
            return listaPartidas.SingleOrDefault(r => r.nombrePartida == nombre);
        }
    }
}
