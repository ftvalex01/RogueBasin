using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace probandomapa
{
    public class GameManager
    {

        Mapa map;
        Jugador player;
        Enemigo enemigo;
        Enemigo enemigo2;
        Random rng = new Random();

        private bool enemigo2Spawned = false;
        public GameManager(Mapa map, Jugador player, Enemigo enemigo, Enemigo enemigo2)
        {
            this.map = map;
            this.player = player;
            this.enemigo = enemigo;
            this.enemigo2 = enemigo2;
            this.rng = new Random();

            RespawnPlayer();


        }
        public void RespawnPlayer()
        {
            int x, y;
            do
            {
                x = rng.Next(map.tablero.GetLength(0));
                y = rng.Next(map.tablero.GetLength(1));

            } while
                    (map.tablero[x, y] is Muro ||
                    map.tablero[x, y].objeto is not null ||
                    map.tablero[x, y] is Salida ||
                    map.tablero[x, y].objeto is Comida ||
                    map.tablero[x, y].objeto is Veneno ||
                    map.tablero[x, y].objeto is Moneda);
            player.x = x;
            player.y = y;
        }
        public void RespawnEnemigo()
        {
            int x, y;

            do
            {
                x = rng.Next(map.tablero.GetLength(0));
                y = rng.Next(map.tablero.GetLength(1));
            } while (map.tablero[x, y] is Muro ||
                    map.tablero[x, y].objeto is not null ||
                    map.tablero[x, y] is Salida ||
                    map.tablero[x, y].objeto is Comida ||
                    map.tablero[x, y].objeto is Veneno ||
                    map.tablero[x, y].objeto is Moneda ||
                    map.tablero[player.x, player.y] is Jugador ||
                    map.tablero[enemigo2.x, enemigo2.y] is Enemigo);
            if (enemigo == null)
            {
                enemigo = new Enemigo(map);
            }
            enemigo.x = x;
            enemigo.y = y;

        }
        public void RespawnEnemigo2()
        {
            int x, y;


            do
            {
                x = rng.Next(map.tablero.GetLength(0));
                y = rng.Next(map.tablero.GetLength(1));
            } while (map.tablero[x, y] is Muro ||
                    map.tablero[x, y].objeto is not null ||
                    map.tablero[x, y] is Salida ||
                    map.tablero[x, y].objeto is Comida ||
                    map.tablero[x, y].objeto is Veneno ||
                    map.tablero[x, y].objeto is Moneda ||
                    map.tablero[player.x, player.y] is Jugador ||
                    map.tablero[enemigo.x, enemigo.y] is Enemigo);
            if (enemigo2 == null)
            {
                enemigo2 = new Enemigo(map);
            }
            enemigo2.x = x;
            enemigo2.y = y;

        }


        public void MuevePlayer(ConsoleKey tecla)
        {


            Celda celda = map.tablero[player.x, player.y];
            map.tablero[player.x, player.y].Dibuja();
            Console.SetCursorPosition(player.x, player.y);
            celda.Dibuja();

            switch (tecla)
            {
                case ConsoleKey.UpArrow:
                    MueveArriba();
                    break;
                case ConsoleKey.DownArrow:
                    MueveAbajo();
                    break;
                case ConsoleKey.LeftArrow:
                    MueveIzquierda();
                    break;
                case ConsoleKey.RightArrow:
                    MueveDerecha();
                    break;
            }
            if (map.tablero[player.x, player.y] is Salida)
            {
                map.RandomWalk();
                map.Salida();
                RespawnPlayer();
                if (player.MonedasRecogidas < 10 && !enemigo2Spawned)
                {
                    RespawnEnemigo();
                }

                if (player.MonedasRecogidas >= 10 && !enemigo2Spawned)
                {
                    RespawnEnemigo();
                    RespawnEnemigo2();
                    enemigo2Spawned = true;
                }

                map.ColocaComida(1);
                map.ColocaMonedasAleatorias(2);
                enemigo.Dibuja();

                map.ColocaVeneno(3);
                map.Dibuja();
            }
            if (map.tablero[player.x, player.y].objeto is Comida)
            {
                player.life += 1;
                map.tablero[player.x, player.y].objeto = null;
            }
            if (map.tablero[player.x, player.y].objeto is Veneno)
            {
                player.life--;
                map.tablero[player.x, player.y].objeto = null;
                if (player.life <= 0)
                {
                    Console.Clear();

                    string[] lines = File.ReadAllLines("Veneno.txt");
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                    Environment.Exit(0);
                }

            }
            if (map.tablero[player.x, player.y].objeto is Moneda)
            {
                Moneda moneda = (Moneda)map.tablero[player.x, player.y].objeto;
                player.bolsa.Add(new Moneda());
                map.tablero[player.x, player.y].objeto = null;
                player.MonedasRecogidas++;

                if (player.MonedasRecogidas >= 20)
                {
                    Console.Clear();

                    string[] lines = File.ReadAllLines("Victoria.txt");
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                    Environment.Exit(0);
                }

            }

            if (player.x == enemigo.x && player.y == enemigo.y ||
                (enemigo2 != null && player.x == enemigo2.x && player.y == enemigo2.y))
            {
                Console.Clear();

                string[] lines = File.ReadAllLines("Derrota.txt");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                Environment.Exit(0);
            }



        }
        void MueveDerecha()
        {
            Mueve(1, 0);
        }
        void MueveIzquierda()
        {
            Mueve(-1, 0);
        }
        void MueveArriba()
        {
            Mueve(0, -1);
        }
        void MueveAbajo()
        {
            Mueve(0, 1);
        }
        void Mueve(int pasosX, int pasosY)
        {
            int nuevaX = player.x + pasosX;
            int nuevaY = player.y + pasosY;


            if (nuevaX >= 0 &&
                nuevaX < map.tablero.GetLength(0) &&
                nuevaY >= 0 &&
                nuevaY < map.tablero.GetLength(1) &&
                map.tablero[nuevaX, nuevaY] is not Muro

                )

            {
                player.x = nuevaX;
                player.y = nuevaY;


            }

        }

        public static void MueveEnemigoAleatorio(Enemigo enemigo, Mapa map)

        {

            Random rng = new Random();

            int direccion = rng.Next(4);
            int pasosX = 0, pasosY = 0;

            switch (direccion)
            {
                case 0: // Arriba
                    pasosY = -1;
                    break;
                case 1: // Abajo
                    pasosY = 1;
                    break;
                case 2: // Izquierda
                    pasosX = -1;
                    break;
                case 3: // Derecha
                    pasosX = 1;
                    break;
            }


            int nuevaX = enemigo.x + pasosX;
            int nuevaY = enemigo.y + pasosY;

            if (nuevaX >= 0 &&
                nuevaX < map.tablero.GetLength(0) &&
                nuevaY >= 0 &&
                nuevaY < map.tablero.GetLength(1) &&
                map.tablero[nuevaX, nuevaY] is not Muro
                && map.tablero[nuevaX, nuevaY] is not Salida
                && map.tablero[nuevaX, nuevaY].objeto is not Veneno
                )
            {

                Console.SetCursorPosition(enemigo.x, enemigo.y);
                map.tablero[enemigo.x, enemigo.y] = new Suelo();
                map.tablero[enemigo.x, enemigo.y].Dibuja();


                enemigo.x = nuevaX;
                enemigo.y = nuevaY;


                Console.SetCursorPosition(enemigo.x, enemigo.y);
                enemigo.Dibuja();
            }

        }



        public static void MueveEnemigoAleatorio2(Enemigo enemigo2, Mapa map)

        {
            Random rng = new Random();

            int direccion = rng.Next(4);
            int pasosX = 0, pasosY = 0;

            switch (direccion)
            {
                case 0: // Arriba
                    pasosY = -1;
                    break;
                case 1: // Abajo
                    pasosY = 1;
                    break;
                case 2: // Izquierda
                    pasosX = -1;
                    break;
                case 3: // Derecha
                    pasosX = 1;
                    break;
            }


            int nuevaX = enemigo2.x + pasosX;
            int nuevaY = enemigo2.y + pasosY;


            if (nuevaX >= 0 &&
                nuevaX < map.tablero.GetLength(0) &&
                nuevaY >= 0 &&
                nuevaY < map.tablero.GetLength(1) &&
                map.tablero[nuevaX, nuevaY] is not Muro
                && map.tablero[nuevaX, nuevaY] is not Salida
                && map.tablero[nuevaX, nuevaY].objeto is not Veneno
                )
            {

                Console.SetCursorPosition(enemigo2.x, enemigo2.y);
                map.tablero[enemigo2.x, enemigo2.y] = new Suelo();
                map.tablero[enemigo2.x, enemigo2.y].Dibuja();


                enemigo2.x = nuevaX;
                enemigo2.y = nuevaY;


                Console.SetCursorPosition(enemigo2.x, enemigo2.y);
                enemigo2.Dibuja();
            }

        }


    }

}