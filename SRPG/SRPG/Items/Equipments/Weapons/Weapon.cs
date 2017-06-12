using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG.Items.Weapons
{
    public class Weapon
    {
        public String Name { get; set; }

        public int Attack { get; set; }

        public int Defence { get; set; }

        public int Range { get; set; }

        public Unit Owner { get; set; }

        public void EquipTo(Unit player)
        {
            Owner = player;
            player.Strength += 2;
        }

        public void Dequip(Unit player)
        {

        }

        List<WeaponEffect> effects = new List<WeaponEffect>();

        public string Apply(Unit p2)
        {
            return "";
        }
    }
}
