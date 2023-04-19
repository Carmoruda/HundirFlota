using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HundirFlota
{
    internal class Program
    {
        /// <summary>
        /// Constante de tipo string que representa la ruta relativa al 
        /// fichero que almacena la información de todas las partidas.
        /// </summary>
        public const string ficheroPartidas = @"PartidasGuardadas.bin";

        /// <summary>
        /// Constante de tipo string que representa la ruta relativa al 
        /// fichero que almacena la información del ranking.
        /// </summary>
        public const string ficheroRanking = @"PartidasFinalizadas.bin";

        static void Main(string[] args)
        {

            Juego miJuego = new Juego();

            miJuego.CargarFichero(ficheroPartidas, false);
            miJuego.CargarFichero(ficheroRanking, true);
            miJuego.Menu();
        }
    }
}
