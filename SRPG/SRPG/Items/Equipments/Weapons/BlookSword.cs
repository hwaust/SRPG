using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG.Items.Equipments.Weapons
{
	public class BlookSword : Sword
	{
		public BlookSword(Unit owner)
		{
			this.Owner = owner;
			this.Strength = 15;
			this.HitRate = 0.05;
			this.CriticalRate = 0.05;
			this.Defence = 2;
			AddEffect(new SRPG.Effects.Buffs.AttackSucker(owner, owner));
		}
	}
}
