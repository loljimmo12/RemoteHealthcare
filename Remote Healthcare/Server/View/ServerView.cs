using System;

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
