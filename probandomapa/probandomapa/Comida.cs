using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace probandomapa
{
    public class Comida : Item
    {
        
        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("♥");
            
        }

    }
}