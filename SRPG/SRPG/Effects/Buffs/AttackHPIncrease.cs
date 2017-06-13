using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG.Effects.Buffs
{
	class AttackHPIncrease : Effect
	{
		int increasement = 0;

		public AttackHPIncrease(Unit owner, Unit target) : base(owner, target) { AffectedRounds = 20; }

		public override BattleRecord applyBeforeAttack(BattleRecord record)
		{
			increasement = (record.From.MaxHP - record.From.HP) / 5;
			record.From.Strength += increasement;
			return record;
		}


		public override BattleRecord applyAfterAttack(BattleRecord record)
		{
			record.From.Strength -= increasement;
			return record;
		}

	}
}
