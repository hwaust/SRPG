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

		public Person From { get; set; }

		public Person To { get; set; }

		public Debuff()
		{

		}

		public Debuff(Person p1, Person p2)
		{
			From = p1;
			To = p2;
		}
		public virtual void Apply() { }

		public bool Expired()
		{
			return AffectedRounds <= 0;
		}
	}
}
