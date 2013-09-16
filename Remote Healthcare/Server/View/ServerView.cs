using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.View
{
    class ServerView
    {
        private ServerModel serverModel = new ServerModel();

        public void writeToConsole(String s)
        {
            Console.WriteLine(s);
        }
    }
}
