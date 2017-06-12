using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG.Debuffs
{
	public class Debuff
	{
		public int AffectedRounds { get; set; }

		public Unit From { get; set; }

		public Unit To { get; set; }

		public Debuff()
		{

		}

		public Debuff(Unit p1, Unit p2)
		{
			From = p1;
			To = p2;
		}

		public virtual Message initialize()
		{
			return null;
		}



		public virtual Message applyBeforeAttack(Unit target)
		{
			return null;
		}

		public virtual Message applyAfterAttack(Unit target)
		{
			return null;
		}

		public virtual Message applyWhenTurnOver(Unit target)
		{
			return null;
		}




		public virtual void Apply() { }

		public bool Expired()
		{
			return AffectedRounds <= 0;
		}
	}
}
