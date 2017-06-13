using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG.Debuffs
{
	public class Effect
	{
		public int AffectedRounds { get; set; }

		public Unit From { get; set; }

		public Unit To { get; set; }

		public Effect()
		{

		}

		public Effect(Unit p1, Unit p2)
		{
			From = p1;
			To = p2;
		}

		public virtual BattleRecord initialize(BattleRecord message)
		{
			return null;
		}



		public virtual BattleRecord applyBeforeAttack(BattleRecord target)
		{
			return null;
		}

		public virtual BattleRecord applyAfterAttack(BattleRecord target)
		{
			return null;
		}

		public virtual BattleRecord applyWhenTurnOver(BattleRecord target)
		{
			return null;
		}




		public virtual BattleRecord Apply() { return new BattleRecord(); }

		public bool Expired()
		{
			return AffectedRounds <= 0;
		}
	}
}
