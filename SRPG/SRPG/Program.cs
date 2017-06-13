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
            List<Effect> dbf = new List<Effect>();

            Unit tom = UnitFactory.MakePalyer(PlayerType.Standard);
            Unit jack = UnitFactory.MakePalyer(PlayerType.Standard);


            tom.Name = "Tom";
			//  tom.Equip(new Sword(), 0);
			tom.MaxHP = 200;
			tom.HP = 200;
			tom.Strength = 0;
			tom.HitRate = 1;
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




        private static void Show(Unit p1, Unit p2)
        {
            Console.WriteLine("{0}: HP={1}; {2}: HP = {3}.", p1.Name, p1.HP, p2.Name, p2.HP);
        }
    }
}
