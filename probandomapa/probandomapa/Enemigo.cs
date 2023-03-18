using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace probandomapa
{
    public class Enemigo
    {
        private Mapa mapa;
        public int x, y;

        public Enemigo(Mapa mapa)
        {
            this.mapa = mapa;
            x = mapa.tablero.GetLength(0) / 2;
            y = mapa.tablero.GetLength(1) / 2;
        }

        public void Dibuja()
        {
            
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("F");

            
        }

        public void Mover(Mapa map)
        {
            // Obtener una dirección aleatoria
            GameManager.MueveEnemigoAleatorio(this, mapa);

        }
    }
}