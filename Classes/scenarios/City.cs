using ConsoleGameFramework.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Scenarios
{
    internal class City : Scene
    {
        public City()
        {
            Add("Você está na cidade, ela é fria como o gelo.");
            Add(@"         /\        ");
            Add(@"        /  \       ");
            Add(@"   /\  /    \  /\");
            Add(@"  /  \/      \/  \");
            Add(@" /    \______/    \");
            Add(@"/__________________\");
            Add(@"|                  |");
            Add(@"| |___|            |");
            Add(@"|       ____       |      __");
            Add(@"|      |    |      |     |__|");
            Add(@"|      |    |      |     |    ");
            Add(@"-----------------------------");

            Add("");
            Add("1. Você deseja entrar no castelo?");
            Add("2. Você deseja entrar na loja?");
            Add("3. Você deseja entrar no coliseu?");
            Add("4. Você deseja ir para a floresta?");
            Add("5. Você deseja ir para outra cidade?");
        }

        public override void ProcessOption(string playerOption)
        {
            if (playerOption == "1")
            {
                Move(new Castle());
            }
            else if (playerOption == "2")
            {
                Move(new Shop());
            }
            else if (playerOption == "3")
            {
                Move(new Coliseum());
            }
            
            else if (playerOption == "4")
            {
                Move(new Florest());
            }
            else if (playerOption == "5")
            {
                Move(new PathToAnotherCity());
            }
            else
            {
                Show();
            }
        }
    }
}
