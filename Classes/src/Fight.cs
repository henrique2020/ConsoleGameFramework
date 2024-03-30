using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.src
{
    internal class Fight
    {
        protected int baseDamage = 10;

        protected string[] lastMove = ["Defesa", "Defesa"];


        private bool bufador(Backpack backpack, string equipment)
        {
            foreach (Item item in backpack.Items)
            {
                if (item.Name == equipment)
                {
                    return true;
                }
            }

            return false;
        }
        protected int SwordMultiplicator(int damage) => (int) Math.Round(damage * 1.2, 0);
        protected int ShieldReducer(int damage) => (int) Math.Round(damage * 0.7, 0);

        private void moveSet(String movement, String turn)
        {
            if (turn == "player")
            {
                lastMove.SetValue(movement, 0);
            } else
            {
                lastMove.SetValue(movement, 1);
            }
        }
            

        public int Attack(String turn)
        {
            int damage = baseDamage;

            moveSet("Ataque", turn);

            if (turn == "player")
            {
                if (bufador(Player.Instance.Backpack, "Espada")) { damage = SwordMultiplicator(damage); }
                if (bufador(NPC.Instance.Backpack, "Escudo")) { damage = ShieldReducer(damage); }

                if (lastMove.GetValue(1).Equals("Defesa")) { damage = ShieldReducer(damage); }

                NPC.Instance.Life -= damage;
            }
            else if (turn == "npc")
            {
                if (bufador(NPC.Instance.Backpack, "Espada")) { damage = SwordMultiplicator(damage); }
                if (bufador(Player.Instance.Backpack, "Escudo")) { damage = ShieldReducer(damage); }

                if (lastMove.GetValue(1).Equals("Defesa")) { damage = ShieldReducer(damage); }

                Player.Instance.Life -= damage;
            }

            return damage;
        }

        public void Defense(string turn)
        { 
            moveSet("Defesa", turn);
 
        }
    }
}
