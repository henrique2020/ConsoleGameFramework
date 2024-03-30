using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.src
{
    internal class Player
    {
        private static Player instance;

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }
                return instance;
            }
        }
        
        public string Name;
        public int Life;
        public double Money;
        public Backpack Backpack;

        private Player()
        {
            Backpack = new Backpack();
            Life = 100;
            Money = 200;
        }
    }    

}
