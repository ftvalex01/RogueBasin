using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace probandomapa
{
    public class Jugador 

    {
        public int x, y;
        public int life;
        public List<IItem> bolsa;

        public Jugador()
        {
            life = 5; 
            bolsa = new List<IItem>();
        }
        public void Dibuja()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("☻");
        }
        public int MonedasRecogidas { get; set; }
    }
}