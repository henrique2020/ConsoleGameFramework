﻿using ConsoleGameFramework.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Scenarios
{
    internal class Menu : Scene
    {
        public Menu()
        {
            Add("1. Jogar");
            Add("2. Fechar");
        }

        public override void ProcessOption(string playerOption)
        {
            if (playerOption == "1")
            {
                Move(new PlayerCreation());
            } else
            {
                Console.WriteLine("Você escolheu sair");
                Environment.Exit(0);
            }
        }
    }
}
