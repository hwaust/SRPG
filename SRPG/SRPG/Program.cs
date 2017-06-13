using SRPG.Effects;
using SRPG.Effects.Buffs;
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
            tom.Strength += 1;
            tom.Equip(new Sword(), 0);

            tom.Effects.Add(new HPRecover(tom, tom));

            jack.Name = "Jack";
            jack.ParryRate = 0.55;


            int round = 1;
            while (true)
            {
                Console.WriteLine(" ------------------- Round {0} ------------------- ", round++);
                Show(tom, jack);

                tom.Attack(jack).Show();


                jack.Attack(tom).Show();


                for (int i = dbf.Count - 1; i >= 0; i--)
                {
                    if (dbf[i].Expired())
                        dbf.RemoveAt(i);
                    else
                        dbf[i].Apply();
                }

                Show(tom, jack);
                if (tom.HP == 0 || jack.HP == 0)
                    break;
            }
        }




        private static void Show(Unit p1, Unit p2)
        {
            Console.WriteLine("{0}: HP={1}; {2}: HP = {3}.", p1.Name, p1.HP, p2.Name, p2.HP);
        }
    }
}
