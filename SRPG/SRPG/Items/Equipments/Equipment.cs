using SRPG.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG.Items.Equipments
{
	public class Equipment : Item
	{
		public int Strength { get; set; }
		public int Defence { get; set; }
		public double HitRate { get; set; }
		public double CriticalRate { get; set; }
		public int Range { get; set; }

		public List<Effect> Effects { get; set; }


		public Unit Owner { get; set; }

		public void AddEffect(Effect effct)
		{
			if (Effects == null)
				Effects = new List<Effect>();
			Effects.Add(effct);
		}

		public virtual void Puton()
		{
			Owner.Strength += this.Strength;
			Owner.Defense += this.Defence;
			Owner.HitRate += this.HitRate;
			Owner.CriticalRate += this.CriticalRate;
			Owner.Effects.AddRange(this.Effects);
		}

		public virtual void Takeoff()
		{
			Owner.Strength -= this.Strength;
			Owner.Defense -= this.Defence;
			Owner.HitRate -= this.HitRate;
			Owner.CriticalRate -= this.CriticalRate;
			foreach (Effect e in Effects)
			{
				if (Owner.Effects.Contains(e))
					Owner.Effects.Remove(e);
			}
		}
	}
}
