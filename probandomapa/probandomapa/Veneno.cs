using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace probandomapa
{
    public class Veneno : Item
    {
        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.Write("V");

        }
    }
}