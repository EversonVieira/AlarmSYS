using AlarmSys.Core.Interfaces;
using AlarmSys.Core.Providers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AlarmSys;

namespace AlarmSys.Core.Providers
{
    public class SqlDataBaseDriver : IDBDriver
    {
        private SqlConnection GlobalConnection;
        private List<SqlParameter> Parameters;
        private SqlTransaction SqlTransaction;
        public SqlDataBaseDriver(string ConnectionString)
        {
            this.GlobalConnection = new SqlConnection();
            this.GlobalConnection.ConnectionString = ConnectionString;
            this.Parameters = new List<SqlParameter>();
        }
        public void AddParameter(string field, dynamic value)
        {
            this.Parameters.Add(new SqlParameter(field, value));
        }

        public void BeginTransaction()
        {
            try
            {

                if (this.GlobalConnection.State != ConnectionState.Open)
                {
                    throw new Exception("Connection isn't open");
                }
                if (this.SqlTransaction != null)
                {
                    throw new Exception("Transaction is already running");
                }
                this.SqlTransaction = this.GlobalConnection.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CommitTransaction()
        {
            try
            {
                if (this.SqlTransaction == null)
                {
                    throw new Exception("There's no transaction to commit");
                }
                this.SqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteNonQuery(string cmd)
        {
            try
            {
                OpenConnection();

                using (SqlCommand command = new SqlCommand(cmd, this.GlobalConnection))
                {
                    AssignParameterList(command);

                    command.ExecuteNonQuery();

                }

                CloseConnection();
            }
            catch (Exception exception)
            {
                this.CloseConnection(true);
                throw exception;
            }
        }

        public DataTable ExecuteReader(string cmd)
        {
            try
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand(cmd, this.GlobalConnection))
                {
                    AssignParameterList(command);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        CloseConnection();


                        return dataTable;
                    }
                }

            }
            catch (Exception exception)
            {
                this.CloseConnection(true);
                throw exception;
            }
        }

        public int ExecuteScalar(string cmd)
        {
            try
            {
                OpenConnection();

                int id = 0;
                using (SqlCommand command = new SqlCommand(cmd, this.GlobalConnection))
                {
                    AssignParameterList(command);

                    id = int.Parse(command.ExecuteScalar().ToString());

                }

                CloseConnection();

                return id;
            }
            catch (Exception exception)
            {
                this.CloseConnection(true);
                throw exception;
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                if (this.SqlTransaction == null)
                {
                    throw new Exception("There's no transaction to RollBack");
                }
                this.SqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void OpenConnection()
        {
            if (this.GlobalConnection.State == System.Data.ConnectionState.Open)
            {
                throw new Exception("Connection is already open");
            }

            this.GlobalConnection.Open();
        }
        private void CloseConnection()
        {


            if (this.GlobalConnection.State == System.Data.ConnectionState.Closed)
            {
                throw new Exception("Connection is already closed");
            }

            this.GlobalConnection.Close();

        }
        private void CloseConnection(bool ignoreFail)
        {
            try
            {

                if (this.GlobalConnection.State == System.Data.ConnectionState.Closed)
                {
                    throw new Exception("Connection is already closed");
                }

                this.GlobalConnection.Close();
            }
            catch (Exception ex)
            {
                if (!ignoreFail)
                {
                    throw ex;
                }
            }
        }
        private void AssignParameterList(SqlCommand cmd)
        {
            foreach (SqlParameter parameter in Parameters)
            {
                cmd.Parameters.Add(parameter);
            }

            this.Parameters.Clear();
        }
    }
}
