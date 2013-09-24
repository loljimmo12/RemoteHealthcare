using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.View
{
    ///<summary>
    ///The base class for the Control.
    ///</summary>
    public static class ServerView
    {
       
        ///<summary>
        ///Append text to console.
        ///</summary>
        public static void writeToConsole(String s)
        {
            Console.WriteLine(s);
        }
    }
}
