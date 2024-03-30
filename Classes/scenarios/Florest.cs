using ConsoleGameFramework.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Scenarios
{
    internal class Florest : Scene
    {
        public Florest()
        {
            Add(@"           /\       ");
            Add(@"          /  \      ");
            Add(@"      /\ /    \     ");
            Add(@"     /  /      \/\  ");
            Add(@"   /\  /        \ \ ");
            Add(@"  /  \/          \_\");
            Add(@" /    \           \ ");
            Add(@"/______\___________\");
            Add(@"   |        |       ");
        }

        public override void ProcessOption(string playerOption)
        {
            throw new NotImplementedException();
        }
    }
}
