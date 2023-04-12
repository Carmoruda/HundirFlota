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
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace HundirFlota
{
    [Serializable]
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

        /// <summary>
        /// Constructor parametrizado de la clase Juego. Asigna
        /// los valores de todos los atributos.
        /// </summary>
        /// <param name="_listaPartidas">
        /// Lista de instancias de Partida que almacena todas las
        /// partidas de un jugador VS otro jugador humano o automático.
        /// </param>
        /// <param name="_consola">
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </param>
        public Juego(List<Partida> _listaPartidas, Pantalla _consola)
        {
            consola = _consola;
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

                accionMenu = consola.PintarMenu(opciones, 0, 1);

                switch (accionMenu)
                {
                    case 1:
                        ListarPartidas(); // Listar partidas y cargar 1.
                        break;
                    case 2:
                        CrearPartida(2); // Partida Múltiple.
                        break;
                    case 3:
                        CrearPartida(1); // Partida Individual.
                        break;
                    case 4:
                        RankingPartidas(); // Ranking de partidas.
                        break;
                    case 5: // Salir.
                        GuardarFichero(listaPartidas, Program.ficheroPartidas); // Guardar listaPartidas.
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
        public void ListarPartidas()
        {
            consola.ImprimirConsola("------------------------------ LISTADO PARTIDAS ------------------------------\n\n", 1);

            if (listaPartidas.Count < 1) // Comprobar que al menos hay 1 partida.
            {
                consola.ImprimirConsola("  No hay partidas guardadas.\n", 0);
                consola.Continuar(1); // Pulsa enter para continuar.
                return;
            }

            foreach (Partida partida in listaPartidas)
            {
                consola.ImprimirConsola(InformacionPartida(partida, 0), 0);
                consola.ImprimirConsola("\n", 0);
            }

            consola.Continuar(1); // Pulsa enter para continuar.

            JugarPartida(listaPartidas[0]);
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
                                  "\n  Ya existe una partida con ese nombre.\n"};

            Jugador nuevoJugador1; // Instancia jugador1.
            Jugador nuevoJugador2; // Instancia jugador2.

            consola.ImprimirConsola(opciones[0], 1); // Opciones[0]: -- NUEVA PARTIDA --...
            string nuevoNombrePartida = consola.LeerString(opciones[1]); // Opciones[1]: * Nombre de la Partida.
        

            // Búscar otra partida con el nombre introducido.
            Partida partidaInsertar = BuscarPartida(nuevoNombrePartida);
            if (partidaInsertar != null) // Ya existe.
            {
                consola.ImprimirConsola(opciones[4], 0); // Opciones[4]: Ya existe una partida con ese nombre.
                consola.Continuar(1); // Pulsar enter para continuar.
                return; // Volver al menú.
            }

            nuevoJugador1 = new Jugador(consola.LeerString(opciones[2])); // Opciones[2]: * Nombre Jugador 1.

            switch (numJugadores) // Partida de 1 o 2 jugadores.
            {
                case 1: // Individual (Humano VS Auto)
                    opciones[3] = "\t * Nombre Jugador 2: " + "Autómata\n"; // Opciones[3]: * Nombre Jugador 2 = Autómata.

                    consola.ImprimirConsola(opciones[3], 0);

                    nuevoJugador2 = new Jugador("Autómata");
                    partidaInsertar = new PartidaIndividual(nuevoJugador1, nuevoJugador2, nuevoNombrePartida);
                    break;
               
                case 2: // Multiple (Humano VS Humano)
                    nuevoJugador2 = new Jugador(consola.LeerString(opciones[3])); // Opciones[3]: * Nombre Jugador 2.
                    partidaInsertar = new PartidaMultiple(nuevoJugador1, nuevoJugador2, nuevoNombrePartida);
                    break;
            }

            consola.Continuar(1); // Pulsa enter para continuar.

            partidaInsertar.NuevaPartida();
            listaPartidas.Add(partidaInsertar);
            GuardarFichero(listaPartidas, Program.ficheroPartidas);
            
        }

        /// <summary>
        /// Muestra todas las partidas que han finalizado en victoria
        /// y muestra su información (Nombre jugadores, número movimientos
        /// y ganador).
        /// </summary>
        public void RankingPartidas()
        {
            consola.ImprimirConsola("------------------------------ LISTADO PARTIDAS ------------------------------\n\n", 1);

            foreach (Partida partida in listaPartidas)
            {
                if (partida.finalizada == true)
                {
                    consola.ImprimirConsola(InformacionPartida(partida, 1), 0);
                    consola.ImprimirConsola("\n", 0);
                }
            }

            consola.Continuar(1); // Pulsa enter para continuar.
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

        public void CargarPartida(string nombre)
        {

        }

        /// <summary>
        /// Muestra la información de la cada partida (Nombre, nombre jugadores,
        /// nº movimientos y estatus).
        /// </summary>
        /// <param name="partida">
        /// Instancia de la clase Partida que representa aquella partida de la que se
        /// quiere saber la información.
        /// </param>
        /// <param name="mostrarGanador">
        /// Entero que representa si se desea mostrar el nombre del ganador.
        /// </param>
        /// <returns>
        /// String que contiene toda la información de la partida.
        /// </returns>
        public string InformacionPartida(Partida partida, int mostrarGanador)
        {
            if (mostrarGanador == 1) // Mostrar nombre ganador.
            {
                return "\n   * Partida: " + partida.nombrePartida + ": \n" + partida.InformacionJugadores() + "\n\t * Número Movimientos: " + partida.numMovimientos + "\n\t * Estatus: " + partida.InformacionStatus() + "\n\t * Ganador: " + partida.nombreGanador + "\n";

            }

            return "\n   * Partida: " + partida.nombrePartida + ": \n" + partida.InformacionJugadores() + "\n\t * Número Movimientos: " + partida.numMovimientos + "\n\t * Estatus: " + partida.InformacionStatus() + "\n";
        }

        /// <summary>
        /// Guarda un objeto de forma síncrona en su respectivo fichero.
        /// </summary>
        /// <param name="listadoPartidas">
        /// Listado de partidas que se quiere guardar
        /// en el fichero.
        /// </param>
        /// <param name="nombreFichero">
        /// String que representa la ruta relativa al fichero en el que
        /// se quiere guardar la información.
        /// </param>
        public void GuardarFichero(List<Partida> listadoPartidas, string nombreFichero)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream Archivo = File.OpenWrite(nombreFichero);
            binaryFormatter.Serialize(Archivo, listadoPartidas);
            Archivo.Close();
        }

        /// <summary>
        /// Carga la lista de partidas de un fichero.
        /// </summary>
        /// <param name="nombreFichero">
        /// String que represeta la ruta relativa al fichero del que
        /// se quiere leer la información.
        /// </param>
        public void CargarFichero(string nombreFichero)
        {
            // Si el fichero no existe se crea.
            if (!File.Exists(nombreFichero))
            {
                File.Create(nombreFichero).Close();
                GuardarFichero(listaPartidas, nombreFichero);
                return;
            }

            // Cargar a listaPartidas las partidas guardadas en el fichero.
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream Archivo = File.Open(nombreFichero, FileMode.Open);
            listaPartidas = (List<Partida>)binaryFormatter.Deserialize(Archivo);
            Archivo.Close();
        }

        /// <summary>
        /// Permite jugar una partida concreta.
        /// </summary>
        /// <param name="partida">
        /// Instancia de la clase Partida que representa
        /// aquella partida que se quiere jugar.
        /// </param>
        public void JugarPartida(Partida partida)
        {
            partida.Jugar(consola);
            Console.ReadKey();
        }
    }
}
