using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG
{
	public class common
	{
		static Random rnd = new Random();
		public static double GetOdd()
		{
			return rnd.NextDouble();
		}

        public static bool TestOdd(double odd)
        {
            return rnd.NextDouble() <= odd;
        }
    }
}
