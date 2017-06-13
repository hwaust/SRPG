using SRPG.Debuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG.Effects.Buffs
{
	class HPRecover : Effect
	{
		public HPRecover(Unit sender, Unit target)
		{
			From = sender;
			To = target;
			AffectedRounds = 5;
		}
		 

		public override Message Apply()
		{
			To.HP += 2;
			AffectedRounds -= 1;

            Message msg = new Message(From, To, "");

            Console.WriteLine(To.Name + " was healed by 2 HP");

            return new Message(From, To, "#to# was healed by 2 HP");
        }
	}
}
