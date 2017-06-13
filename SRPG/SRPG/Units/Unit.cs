using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRPG.Items.Weapons;
using SRPG.Items;
using SRPG.Items.Equipments;
using SRPG.Debuffs;

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



        public Equipment Weapon { get; set; }


        public Item Armor { get; set; }


        public List<Equipment> Accessories { get; set; }



        public List<Effect> Effects = new List<Effect>();

        public Unit()
        {
            CriticalDamage = 1.00; // 100%
            Accessories = new List<Equipment>();
        }

        public int GetDamage()
        {
            return Strength;
        }

        internal void ProcessDebuff()
        {

        }

        public BattleRecord Attack(Unit target)
        {
            BattleRecord msg = new BattleRecord(this, target, null);

            if (this.HP == 0)
                return msg;


            // Hit Rate test.
            if (common.TestOdd(target.HitRate))
            {
                msg.Information = "#from# missed.";
                return msg;
            }

            // Parray Rate test.
            if (common.TestOdd(target.ParryRate))
                return new BattleRecord(this, target, "#to# Dodged.");


            msg.Damage = this.GetDamage() - target.Defense;
            msg.Information = "#from# hit #to#, caused #damage# damage.";


            // Critial Hit test.
            if (common.TestOdd(target.CriticalRate))
            {
                msg.Damage *= (int)(1 + target.CriticalDamage);
                msg.Information = "#from# critical hit #to#, caused #damage# damage.";
            }


            target.HP -= msg.Damage;

            foreach (Effect effect in Effects)
            {
                effect.applyAfterAttack(msg);
            }


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


        public bool Immune()
        {
            foreach (Effect ef in Effects)
            {

            }
            return false;
        }
    }
}
