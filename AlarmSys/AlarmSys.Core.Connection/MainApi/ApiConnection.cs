using AlarmSys.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSys.Core.Connection
{
    public class ApiConnection
    {
        // Here we are supposed to ADD the current Login Account, or some another config who also can be used in the scope of some request, JWT Token, Session, Permissions or something like this.
        // In this case we just gonna use DAO cause there's not need to have authentication in this CRUD. But this class is a "Centralizer" class. 
        public IDBDriver DAO { get; }

        public ApiConnection(IDBDriver dbDriver)
        {
            this.DAO = dbDriver;
        }
    }
}
