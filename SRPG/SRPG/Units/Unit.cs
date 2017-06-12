using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRPG.Items.Weapons;
using SRPG.Items;

namespace SRPG
{
    public class Unit
    {
        /// <summary>
        /// Name of the player.
        /// </summary>
		public string Name { get; set; }

        /// <summary>
        /// Level 
        /// </summary>
		public int Level { get; set; }
        public int MaxLevel { get; set; }

        /// <summary>
        /// Current experience. 100 -> Level+1.
        /// </summary>
        public int Experience { get; set; }

        public PlayerType PType { get; set; }


        public int MaxHP { get; set; }

        int _hp;
        public int HP
        {
            get { return _hp; }
            set
            {
                _hp = value < 0 ? 0 : value;
            }
        }


        public int Strength { get; set; }

        public int Defense { get; set; }

        public int MagicPower { get; set; }

        public int Resistance { get; set; }

        public double CriticalRate { get; set; }

        public double CriticalDamage { get; set; }

        public double HitRate { get; set; }

        public double ParryRate { get; set; }


        public int Movement { get; set; }


        public Item Weapon { get; set; }

        public Item Armor { get; set; }


        public List<Item> Equipments { get; set; }


        public Unit()
        {
            CriticalDamage = 1.00; // 100%
            Equipments = new List<Item>();
        }

        public int GetDamage()
        {
            return Strength;
        }

        internal void ProcessDebuff()
        {

        }

        public String Attack(Unit p)
        {
            if (common.TestOdd(p.HitRate))
            {
                return "missed";
            }

            // Computer dodge.
            if (common.GetOdd() <= p.ParryRate)
            {
                return "#to# Dodged.";
            }

  

            int damage = this.GetDamage() - p.Defense;
            string msg = "#from# hit #to#, caused " + damage + " damage"; 
            if (common.TestOdd(p.CriticalRate))
            {
                damage *= (int)(1 + p.CriticalDamage);
                msg += " cricial strike";
            }

            p.HP -= damage;
            return msg;
        }

        public void Show()
        {
            Console.WriteLine("HP: " + HP);
        }

        public void Equip(Weapon wp)
        {
            //wp.EquipTo(this);
            //Equipments.Add(wp);
        }
    }
}
