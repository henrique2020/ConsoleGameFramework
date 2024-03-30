using ConsoleGameFramework.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Scenarios
{
    internal class PlayerCreation : Scene
    {
        public PlayerCreation() {
            UserOptionMessage = "Por favor digite o nome do Jogador: ";
            Add("Você está na janela de criação do personagem.");
        }

        public override void ProcessOption(string playerOption)
        {
            if (string.IsNullOrWhiteSpace(playerOption))
            {
                Move(new PlayerCreation());
            } else
            {
                Player.Instance.Name = playerOption;
                Move(new City());
            }
        }
    }
}
