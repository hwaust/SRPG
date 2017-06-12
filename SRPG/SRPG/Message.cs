using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPG
{
   public class Message
    {
        public Person From { get; set; }
        public Person To { get; set; }
        public string Information { get; set; }

        public Message() { }
        public Message(Person from, Person to, string msg)
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
