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

        public Person Owner { get; set; }

        public void EquipTo(Person player)
        {
            Owner = player;
            player.Strength += 2;
        }

        public void Dequip(Person player)
        {

        }

        List<WeaponEffect> effects = new List<WeaponEffect>();

        public string Apply(Person p2)
        {
            return "";
        }
    }
}
