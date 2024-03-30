using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameFramework.src;
using ConsoleGameFramework.Scenarios;

namespace ConsoleGameFramework.Scenarios
{
    internal class Shop : Scene
    {
        public List<Item> Items;

        public Shop()
        {
            Items = new List<Item>();

            Items.Add(new Item
            {
                Name = "Poção de Vida",
                Value = 10
            });

            Items.Add(new Item
            {
                Name = "Poção de Magia",
                Value = 20
            });

            Items.Add(new Item
            {
                Name = "Escudo",
                Value = 5
            });

            Items.Add(new Item
            {
                Name = "Espada",
                Value = 50
            });

            Items.Add(new Item
            {
                Name = "Pão",
                Value = 1
            });


            Add("Bem vindo a Loja, aqui estão os itens:");

            int number = 1;
            foreach (Item item in Items)
            {
                Add($"{number}. {item.Name} - ${item.Value}");
                number++;
            }

            Add($"LISTAR) Listar Itens da Mochila");
            Add($"SAIR) Sair");
        }

        public override void ProcessOption(string playerOption)
        {
            int option;
            if(Int32.TryParse(playerOption, out option) && Items.Count >= option)
            {
                option--;
                if (Player.Instance.Money >= Items[option].Value)
                {
                    Player.Instance.Backpack.Items.Add(new Item
                    {
                        Name = Items[option].Name,
                        Value = Items[option].Value
                    });
                    Player.Instance.Money -= Items[option].Value;
                }
                else
                {
                    Console.WriteLine("Você não tem dinheiro o suficiente para esta ação");
                    Console.WriteLine("Precione qualquer tecla para voltar a Loja");
                    Console.ReadKey();
                }
            } else
            {
                playerOption = playerOption.ToUpper();
                if (playerOption == "LISTAR")
                {
                    Console.WriteLine("Os itens da sua mochila são:");
                    foreach (var item in Player.Instance.Backpack.Items)
                    {
                        Console.WriteLine($"Item: {item.Name}");
                    }

                    Console.WriteLine("Pressione qualquer tecla pra continuar...");
                    Console.ReadKey();
                } else if(playerOption == "SAIR")
                {
                    Move(new City());
                }
            }
            
            Move(new Shop());
        }
    }
}



