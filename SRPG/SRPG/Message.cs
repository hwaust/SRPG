using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG
{
   public class Message
    {
        public Unit From { get; set; }
        public Unit To { get; set; }
        public string Information { get; set; }

        public Message() { }
        public Message(Unit from, Unit to, string msg)
        {
            From = from;
            To = to;
            Information = msg;
        }


        public void Show()
        {

        }
    }
}
