using ConsoleGameFramework.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleGameFramework.Scenarios
{
    internal class Coliseum : Scene
    {
        public Fight figth = new Fight();
        public Random rand = new Random();
        protected int opponents;
        protected int opponentsDefeated = 0;

        public Coliseum()
        {
            opponents = rand.Next(1, 5);
            NPC.Instance.Life = 100;
            opponents--;
            Add("Você está no coliseu!");
            Add("1. Atacar");
            Add("2. Defender");
        }
        public override void ProcessOption(string playerOption)
        {
            bool npc = true;
            int damage;
            Console.WriteLine();
            if (playerOption == "1")
            {
                damage = figth.Attack("player");
                Console.WriteLine($"{Player.Instance.Name} atacou! Dano causado {damage}");

                if (NPC.Instance.Life <= 0 && opponents > 0)
                {
                    opponentsDefeated++;
                    Add("");
                    Add($"Oponente {opponentsDefeated} vencido. Restam {opponents} openentes");

                    NPC.Instance.Life = 100;
                    NPC.Instance.RemoveItems();
                    NPC.Instance.SortItems();
                }
                else if (NPC.Instance.Life <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("+------------------------+");
                    Console.WriteLine("| Você Ganhou! + $100,00 |");
                    Console.WriteLine("+------------------------+");
                    Console.ReadKey();
                    Player.Instance.Money += 100;
                    Move(new City());
                }

            }
            else if (playerOption == "2")
            {
                figth.Defense("player");
                Console.WriteLine($"{Player.Instance.Name} defendeu!");
            }/*
            else if (playerOption == "3") { 
                // Recuperar vida
            }
            */
            else
            {
                npc = false;
            }
            if (npc)
            {
                if (rand.Next(1, 10) > 4)
                {
                    damage = figth.Attack("npc");
                    PlayerBar();
                    Console.WriteLine($"Oponente atacou! Dano causado {damage}");

                    if (Player.Instance.Life <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Você morreu");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    figth.Defense("npc");
                    Console.WriteLine($"Oponente defendeu!");
                }
            }
            Show();
        }
    }
}