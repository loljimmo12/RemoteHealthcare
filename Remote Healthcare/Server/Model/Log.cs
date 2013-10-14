using System;

namespace Server.Model
{
    ///<summary>
    ///The base class for a Log, 
    /// containing the client's name and the start- and endtime of the session.
    ///</summary>
    [Serializable]
    class Log
    {
        public DateTime login { get; set; }
        public bool accepted { get; set; }

        ///<summary>
        ///Initalization of a Log object.
        ///</summary>
        public Log(DateTime login, bool accepted)
        {
            this.login = login;
            this.accepted = accepted;
        }
    }
}
