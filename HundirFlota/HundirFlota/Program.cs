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
        public const string ficheroPartidas = @"PartidasGuardadas.json";

        /// <summary>
        /// Constante de tipo string que representa la ruta relativa al 
        /// fichero que almacena la información del ranking.
        /// </summary>
        public const string ficheroRanking = @"RankingPartidas.json";

        static void Main(string[] args)
        {

            Juego miJuego = new Juego();
            //Tablero tablero = new Tablero();
            //tablero.Pintar();
            //Console.ReadKey();
            //miJuego.CargarFichero(ficheroPartidas);
            miJuego.Menu();
        }
    }
}
