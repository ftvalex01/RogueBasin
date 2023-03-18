using System;
using System.IO;
using System.Timers;
using System.Text.RegularExpressions;
using Timer = System.Timers.Timer;

namespace probandomapa
{
    internal class Program
    {
        
        private static void Main(string[] args)
        
        {


            Console.OutputEncoding = System.Text.Encoding.UTF8;
            String titulo = "instrucciones del juego:";
            string newTitulo = titulo.ToUpper();
            Console.WriteLine(newTitulo);
            Console.WriteLine("-----------------------");
            string[] lines = File.ReadAllLines("Instrucciones.txt");
            Regex regex = new Regex(@"\bfrank\b", RegexOptions.IgnoreCase);
            foreach (string line in lines)
            {
                string newLine = regex.Replace(line, "FRANK");
                Console.WriteLine(newLine);
            }


            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey(true);
            Console.Clear();
            // Declarar e instanciar los objetos necesarios
            GameManager game;
            Mapa map;
            Jugador player;
            Enemigo enemigo;
            Enemigo enemigo2;

            map = new Mapa(60, 20);
            player = new Jugador();
            enemigo = new Enemigo(map);
            enemigo2 = new Enemigo(map);
            game = new GameManager(map, player, enemigo,enemigo2);
            game.RespawnPlayer();
            game.RespawnEnemigo();
           
            Console.CursorVisible = false;

            map.Dibuja();
            ConsoleKey tecla;
            var timer = new Timer(200); 
            timer.Elapsed += (sender, e) => {
                
                enemigo.Mover(map);
                if (player.MonedasRecogidas > 10 && enemigo2 != null)
                {
                    enemigo2.Mover(map);
                }
            };
            timer.Start();
         

            do
            {


                HUD.Info(player);
        
                    
              

             
                player.Dibuja();
                
                if (player.MonedasRecogidas < 10)
                {
                    enemigo.Dibuja();
                    
                }else if (player.MonedasRecogidas > 10)
                {
                    enemigo.Dibuja();
                    enemigo2.Dibuja();
                }

                tecla = Console.ReadKey(true).Key;
                
                game.MuevePlayer(tecla);

            } while (tecla != ConsoleKey.Escape);
            

           





        }
    }
}