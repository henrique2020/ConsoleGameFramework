using ConsoleGameFramework.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.scenarios
{
    internal class Castle : Scene
    {
        public Castle()
        {
            Add(@"+-----------------+");
            Add(@"|    |       |    |");
            Add(@"|    |   _   |    |");
            Add(@"|    |__/ \__|    |");
            Add(@"|                 |");
            Add(@"|      /   \      |");
            Add(@"| .   /     \   . |");
            Add(@"|/   /       \   \|");
            Add(@"|   /         \   |");
            Add(@"|__/___________\__|");
        }

        public override void ProcessOption(string playerOption)
        {
            throw new NotImplementedException();
        }
    }
}
