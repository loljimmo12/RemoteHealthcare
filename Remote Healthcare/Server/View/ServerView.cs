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
        private ServerModel serverModel;

        public ServerView(ServerModel serverModel)
        {
            this.serverModel = serverModel;
        }
         
        ///<summary>
        ///Append text to console.
        ///</summary>
        public void writeToConsole(String s)
        {
            Console.WriteLine(s);
        }
    }
}
