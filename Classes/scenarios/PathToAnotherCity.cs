using ConsoleGameFramework.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.scenarios
{
    internal class PathToAnotherCity : Scene
    {

        public PathToAnotherCity()
        {

            Add(@"   /\         _            ");
            Add(@"  /  \       / \           ");
            Add(@" /    \/\    \  \______    ");
            Add(@"/______\_\    \ |      \   ");
            Add(@"   |    |      \|______/   ");
            Add("                 |          ");
            Add("----------------------------");
            Add("Andando pela estrada você se depara com uma placa");
            Add("Norte -> Floresta");
            Add("Oeste -> Anor Londo");
            Add("Sul -> Pântano");
            Add("Tome sua decisão!");
            Add("1. Seguir para a outra cidade");
            Add("2. Entrar na Floresta");
            Add("3. Explorar o Pântano");
            Add("4. Retornar");
            Add("5. ???");
        }

        public bool TreasureEvent()
        {
            Add("Você se deparou com uma carroça em pedaços.");
            Add("Ao se aproximar dela encontrou um baú cheio de tesouros.");
            Add("Gostaria de saquear? (Esta ação influência diretamente na história)");
            Add("1. Sim");
            Add("2. Não");

            Random rand = new Random();
            int lucky = rand.Next(1, 11);
            string playerOption = RequestUserOption();
            if (playerOption == "1" && lucky > 5)
            {
                Add("Dia de sorte, você recebeu +100 ouro");
            } else if(playerOption == "2")
            {
                Add("Você é uma pessoa que não liga para bens materiais ~palmas~");
            } else
            {
                Add("Não muito depois de pegar o ouro, apareceu uma grupo de soldados que o prenderam por saquer");
                Add("Você foi condenado a morte.");
                return false;
            }

            return true;

        }
        public override void ProcessOption(string playerOption)
        {
            if (playerOption == "1")
            {
                //AnorLondo city = new AnorLondo();
                //Move(city);
            }
            else if (playerOption == "2")
            {
                Florest florest = new Florest();
                Move(florest);
            }
            else if (playerOption == "3")
            {
                //Pantano pantano = new Pantano();
                //Move(pantano);
            }
            else if (playerOption == "4")
            {
                City city = new City();
                Move(city);
            }
            else if (playerOption == "5")
            {
                if (TreasureEvent())
                {
                    Move(new PathToAnotherCity());
                }
                else
                {
                    Console.WriteLine("Você Morreu");
                    Environment.Exit(0);
                }
            } else
            {
                Console.Clear();
                Show();
            }
        }
    }
}
