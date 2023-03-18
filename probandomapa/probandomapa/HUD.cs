using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace probandomapa
{
    public static class HUD
    {
        public static void Info(Jugador player)
        {

            int cursorx = 70;
            int cursory = 1;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(70, 0);
            Console.Write("*********************");
            Console.SetCursorPosition(70, 10);
            Console.Write("*********************");
            Console.SetCursorPosition(72, 3);

            Console.Write("Monedas: " + player.MonedasRecogidas);
            Console.SetCursorPosition(75, 11);
            Console.Write("Movimiento: Flechas de direccion");
          

            for (int i = 0; i <= cursory; i++)
            {
                for (int j = 0; j <= 9; j++)
                {

                    Console.SetCursorPosition(cursorx, cursory + j);
                    Console.Write("*");
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(72, 1);
            Console.Write("Vidas: ");
            for (int i = 0; i < player.life; i++)

            {

                Console.Write("♥");

            }
            Console.Write("   ");

        }
    }
}