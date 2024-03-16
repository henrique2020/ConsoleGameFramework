using ConsoleGameFramework.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.scenarios
{
    internal class City : Scene
    {
        public City()
        {
            Add("Você está na cidade, ela é fria como o gel.");
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
            Add("2. Você deseja ir para a floresta?");
            Add("3. Você deseja ir para outra cidade?");
        }

        public override void ProcessOption(string playerOption)
        {
            if (playerOption == "1")
            {
                Castle castle = new Castle();
                Move(castle);
            }
            else if (playerOption == "2")
            {
                Florest florest = new Florest();
                Move(florest);
            }
            else if (playerOption == "3")
            {
                PathToAnotherCity path = new PathToAnotherCity();
                Move(path);
            }
            else
            {
                Show();
            }
        }
    }
}
