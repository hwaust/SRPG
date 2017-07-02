using SRPG.Effects;
using SRPG.Effects.Buffs;
using SRPG.Items.Equipments.Weapons;
using SRPG.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Effect> mapeffects = new List<Effect>();
			mapeffects.Add(new Effect());

			Unit tom = UnitFactory.MakePalyer(PlayerType.Standard);
			Unit jack = UnitFactory.MakePalyer(PlayerType.Standard);


			tom.Name = "Tom";
			//  tom.Equip(new Sword(), 0);
			tom.MaxHP = 200;
			tom.HP = 200;
			tom.Strength = 0;
			tom.HitRate = 1.00;
			tom.Effects.Add(new HPRecover(tom, tom));
			tom.Effects.Add(new AttackHPIncrease(tom, tom));
			tom.Equip(new BlookSword(tom), 0);

			jack.Name = "Jack";
			jack.MaxHP = 1000;
			jack.HP = 1000;
			tom.Strength = 50;
			jack.ParryRate = 0;
			jack.HitRate = 1;


			int round = 1;
			while (tom.HP != 0 && jack.HP != 0)
			{
				Console.WriteLine(" ------------------- Round {0} ------------------- ", round++);
				Show(tom, jack);


				tom.Attack(jack).Show();

				jack.Attack(tom).Show();



				tom.UpdateEffects();
				jack.UpdateEffects();

				Show(tom, jack);
			}


		}

		// play statues
		// 

		public static void Attack(Unit attacker, Unit target)
		{

			if (attacker.HP == 0)
				return;

			BattleRecord record = new BattleRecord(attacker, target, null);


			foreach (Effect effect in target.Effects)
				if (effect.stopAttach(record))
				{
					new BattleRecord(attacker, target, "").Show();
					return;
				}

			foreach (Effect effect in attacker.Effects)
				effect.applyBeforeAttack(record);

			// Hit Rate test.
			if (!common.TestOdd(target.HitRate))
			{
				record.Information = "#from# missed.";
			}
			// Parray Rate test.
			else if (common.TestOdd(target.ParryRate))
			{
				 new BattleRecord(attacker, target, "#to# Dodged.").Show();
				return;
			}
			else
			{
				// Basic damage.
				record.Damage = attacker.GetDamage() - target.Defense;
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


			foreach (Effect effect in attacker.Effects)
				effect.applyAfterAttack(record);


			// return record;
		}


		private static void Show(Unit p1, Unit p2)
		{
			Console.WriteLine("{0}: HP={1}; {2}: HP = {3}.", p1.Name, p1.HP, p2.Name, p2.HP);
		}
	}
}
