using SRPG.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG.Effects.Buffs
{
	class HPRecover : Effect
	{

		public HPRecover(Unit owner, Unit target)
		{
			Owner = owner;
			Target = target;
			AffectedRounds = 5;
		}

		public override BattleRecord applyWhenTurnOver()
		{
			AffectedRounds -= 1;

			Owner.HP += 2;
			BattleRecord msg = new BattleRecord(Owner, Target, "#from# was healed by 2 HP");
			
			return msg;
		}

	}
}
