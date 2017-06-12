using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRPG.Items;

namespace SRPG
{
	class UnitFactory
	{
		public  static Unit MakePalyer(PlayerType type)
		{
			Unit p = new Unit();

			switch (type)
			{
				case PlayerType.Standard:
                    p = new Unit()
                    {
                        MaxHP = 100,
                        HP = 100,
                        Strength = 10,
                        Defense = 3,
                        CriticalRate = 0.1,
						ParryRate = 0.3,
					};

					break;
				default:
					break;
			}


			return p;
		}

        public static void GetWeapon(int id)
        {

        }

        public static Item MakeItem(int itemid)
        {

            return null;
        }
	}


	public enum PlayerType
	{
		Standard,
	}
}
