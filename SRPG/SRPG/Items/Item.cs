using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG.Items
{
    public class Item
    {
		public String Name { get; set; }

		public virtual string Use(Unit player)
        {
            player.HP += 2;
            return null;
        }
    }
}
