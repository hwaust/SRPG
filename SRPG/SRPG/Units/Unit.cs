using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRPG.Items.Weapons;
using SRPG.Items;
using SRPG.Items.Equipments;
using SRPG.Effects;

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
				_hp = value;
				_hp = _hp > MaxHP ? MaxHP : _hp;
				_hp = _hp < 0 ? 0 : _hp;
            }
        }


        public int Strength { get; set; }

        public int Defense { get; set; }

        public int MagicPower { get; set; }

        public int Resistance { get; set; }

        public double CriticalRate { get; set; }

        public double CriticalDamage { get; set; }

		public void UpdateEffects()
		{
			for (int i = Effects.Count - 1; i >= 0; i--)
			{
				Effects[i].applyWhenTurnOver().Show();
				if (Effects[i].Expired())
					Effects.RemoveAt(i);
			}
		}

		public double HitRate { get; set; }

        public double ParryRate { get; set; }

        public int Movement { get; set; }


 

        public Equipment[] Accessories { get; set; }



        public List<Effect> Effects = new List<Effect>();

        public Unit()
        {
            CriticalDamage = 1.00; // 100%
            Accessories = new Equipment[6];
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
            BattleRecord record = new BattleRecord(this, target, null);

            if (this.HP == 0)
                return record;

            foreach (Effect effect in Effects)
                if (effect.stopAttach(record))
                    return new BattleRecord(this, target, "");


            foreach (Effect effect in Effects)
                effect.applyBeforeAttack(record); 

            // Hit Rate test.
            if (!common.TestOdd(target.HitRate))
            {
                record.Information = "#from# missed.";
            } 
            // Parray Rate test.
            else if (common.TestOdd(target.ParryRate))
            {
                return new BattleRecord(this, target, "#to# Dodged.");
            }
            else
            {

                // Basic damage.
                record.Damage = this.GetDamage() - target.Defense;
				record.Damage = record.Damage < 0 ? 0 : record.Damage;

                // Critial Hit test.
                if (common.TestOdd(target.CriticalRate))
                {
                    record.Damage *= (int)(1 + target.CriticalDamage);
                    record.Information = "#from# critical hit #to#, caused #damage# damage.";
                }
                else
                {
                    record.Information = "#from# hit #to#, caused #damage# damage.";
                }

                // Reduce HP.
                target.HP -= record.Damage;


            }


            foreach (Effect effect in Effects)
                effect.applyAfterAttack(record);


            return record;
        }

        public void Show()
        {
            Console.WriteLine("HP: " + HP);
        }

        public void Equip(Equipment equip, int pos)
        {
            Accessories[pos] = equip;
			equip.Puton();
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
