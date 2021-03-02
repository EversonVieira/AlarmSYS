using AlarmSys.Core.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AlarmService
{
    internal class AlarmDAL
    {
        private ApiConnection ApiConn;

        public AlarmDAL(ApiConnection apiConnection)
        {
            this.ApiConn = apiConnection;
        }

        public int Insert(Alarm alarm)
        {
            string cmd = @"INSERT INTO Alarms(Id_Classification,Id_Equipment,Description)
                           VALUES(@Id_Classification,@Id_Equipment,@Description) SELECT SCOPE_IDENTITY()";

            ApiConn.DAO.AddParameter("@Id_Classification", alarm.Id_Classification);
            ApiConn.DAO.AddParameter("@Id_Equipment", alarm.Id_Equipment);
            ApiConn.DAO.AddParameter("@Description", alarm.Description);

            return ApiConn.DAO.ExecuteScalar(cmd);
        }
        public void Update(Alarm alarm)
        {
            string cmd = @"UPDATE Alarms SET
                            Id_Classification = @Id_Classification,
                            Id_Equipment      = @Id_Equipment,
                            Description       = @Description
                            WHERE Id = @Id";

            ApiConn.DAO.AddParameter("@Id", alarm.Id);
            ApiConn.DAO.AddParameter("@Id_Classification", alarm.Id_Classification);
            ApiConn.DAO.AddParameter("@Id_Equipment", alarm.Id_Equipment);
            ApiConn.DAO.AddParameter("@Description", alarm.Description);

            ApiConn.DAO.ExecuteNonQuery(cmd);
        }
        public void Delete(Alarm alarm)
        {
            string cmd = @"DELETE FROM ALARMS WHERE Id = @Id";

            ApiConn.DAO.AddParameter("@Id", alarm.Id);

            ApiConn.DAO.ExecuteNonQuery(cmd);

        }
        public List<Alarm> Filter(AlarmFilter alarm)
        {
            List<Alarm> alarms = new List<Alarm>();

            ApiConn.DAO.AddParameter("@Description", alarm.Description);
            ApiConn.DAO.AddParameter("@Id_Classification", alarm.Id_Classification);
            ApiConn.DAO.AddParameter("@Id_Equipment", alarm.Id_Equipment);
            ApiConn.DAO.AddParameter("@StartDate", alarm.StartDate);
            ApiConn.DAO.AddParameter("@EndDate", alarm.EndDate);

            string cmd = @"SELECT Id,Description,Id_Classification,Id_Equipment,RegisterDate
                           FROM Alarms WHERE
                           (
                                (@Description IS NULL) OR (Description LIKE @Description) AND
                                (@Id_Classification IS NULL) OR (Id_Classification = @Id_Classification) AND
                                (@Id_Equipment IS NULL) OR (Id_Equipment = @Id_Equipment) AND
                                (@StartDate IS NULL OR @EndDate IS NULL) OR (RegisterDate Between @StartDate AND @EndDate)
                           )";

            DataTable DT = ApiConn.DAO.ExecuteReader(cmd);
            foreach(DataRow row in DT.Rows)
            {
                alarms.Add(new Alarm
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Id_Classification = int.Parse(row["Id_Classification"].ToString()),
                    Id_Equipment = int.Parse(row["Id_Equipment"].ToString()),
                    Description = row["Description"].ToString(),
                    RegisterDate = (DateTime) row["RegisterDate"]
                });
            }
            return alarms;
        }
        public Alarm Select(Alarm alarm)
        {
            List<Alarm> alarms = new List<Alarm>();
            string cmd = @"SELECT Id,Description,Id_Classification,Id_Equipment,RegisterDate
                           FROM Alarms WHERE Id = @Id";

            ApiConn.DAO.AddParameter("@Id", alarm.Id);

            DataTable DT = ApiConn.DAO.ExecuteReader(cmd);

            foreach (DataRow row in DT.Rows)
            {
                alarms.Add(new Alarm
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Id_Classification = int.Parse(row["Id_Classification"].ToString()),
                    Id_Equipment = int.Parse(row["Id_Equipment"].ToString()),
                    Description = row["Description"].ToString(),
                    RegisterDate = (DateTime)row["RegisterDate"]
                });
            }

            return alarms.FirstOrDefault();
        }
    }
}
