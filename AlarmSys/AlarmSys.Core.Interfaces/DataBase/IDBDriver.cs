using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AlarmSys.Core.Interfaces
{
    //This interface exists to goes as an abstraction of SqlConnectors, could Be Mysql,Sql Server, Oracle, Post gree or something else.
    //This will have only one implementation, so we will use Sql Server in this case.
    public interface IDBDriver
    {
        public void BeginTransaction();
        public void CommitTransaction();
        public void RollbackTransaction();
        public void ExecuteNonQuery(string cmd);
        public int ExecuteScalar(string cmd);
        public DataTable ExecuteReader(string cmd);
        public void AddParameter(string field, dynamic value);
    }
}
