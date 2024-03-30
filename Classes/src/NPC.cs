using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.src
{
    internal class NPC
    {
        private void addToBackpack(String name)
        {
            instance.Backpack.Items.Add(new Item
            {
                Name = name,
                Value = 0
            });
        }

        public void SortItems()
        {
            Random rand = new Random();

            if (rand.Next(1, 10) > 6)
            {
                instance.addToBackpack("Espada");
            }

            if (rand.Next(1, 10) > 7)
            {
                instance.addToBackpack("Escudo");
            }
        }

        public void RemoveItems()
        {
            Backpack = new Backpack();
        }


        private static NPC instance;
        public static NPC Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NPC();

                    instance.SortItems();
                }
                return instance;
            }
        }

        public string Name;
        public int Life;
        public Backpack Backpack;

        private NPC()
        {
            Backpack = new Backpack();
            Life = 100;
        }
    }
}
