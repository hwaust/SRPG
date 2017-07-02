using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG.Effects.Buffs
{
	public class AttackSucker: Effect
	{
		public AttackSucker(Unit p1, Unit p2) : base(p1, p2)
		{
			AffectedRounds = int.MaxValue;
		}

		public override BattleRecord applyAfterAttack(BattleRecord record)
		{
			int suck = record.Damage / 4;
			int hp = record.From.HP;
			record.From.HP += suck;

			Console.WriteLine("{0} sucked {1} HP and healed {2} HP.", record.From.Name,  suck,  record.From.HP - hp);

			return base.applyAfterAttack(record);
		}
	}
}
