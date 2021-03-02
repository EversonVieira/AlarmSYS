using AlarmSys.Core.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ActedAlarmService
{
    internal class ActedAlarmDAL
    {
        private ApiConnection ApiConn;

        public ActedAlarmDAL(ApiConnection apiConnection)
        {
            this.ApiConn = apiConnection;
        }
        public int Insert(ActedAlarm actedAlarm)
        {
            string cmd = @"INSERT INTO Alarms_Acted(Id_Alarm,Id_Status,InputDate,OutputDate)
                           VALUES(@Id_Alarm,@Id_Status,@InputDate,@OutputDate) SELECT SCOPE_IDENTITY()";

            ApiConn.DAO.AddParameter("@Id_Alarm", actedAlarm.Id_Alarm);
            ApiConn.DAO.AddParameter("@Id_Status", actedAlarm.Id_Status);
            if (actedAlarm.InputDate > DateTime.MinValue)
            {
                ApiConn.DAO.AddParameter("@InputDate", actedAlarm.InputDate);
            }
            else
            {
                ApiConn.DAO.AddParameter("@InputDate", DBNull.Value);
            }
            if (actedAlarm.OutputDate > DateTime.MinValue)
            {
                ApiConn.DAO.AddParameter("@OutputDate", actedAlarm.OutputDate);
            }
            else
            {
                ApiConn.DAO.AddParameter("@OutputDate", DBNull.Value);
            }

            return ApiConn.DAO.ExecuteScalar(cmd);
        }
        public void Update(ActedAlarm actedAlarm)
        {
            string cmd = @"UPDATE Alarms_Acted SET
                            Id_Alarm       = @Id_Classification,
                            Id_Status      = @Id_Equipment,
                            InputDate      = @Description,
                            OutputDate     = @OutputDate
                            WHERE       Id = @Id";

            ApiConn.DAO.AddParameter("@Id_Alarm", actedAlarm.Id_Alarm);
            ApiConn.DAO.AddParameter("@Id_Status", actedAlarm.Id_Status);
            ApiConn.DAO.AddParameter("@InputDate", actedAlarm.InputDate);
            ApiConn.DAO.AddParameter("@OutputDate", actedAlarm.OutputDate);

            ApiConn.DAO.ExecuteNonQuery(cmd);
        }
        public void Delete(ActedAlarm actedAlarm)
        {
            string cmd = @"DELETE FROM Alarms_Acted WHERE Id = @Id";

            ApiConn.DAO.AddParameter("@Id", actedAlarm.Id);

            ApiConn.DAO.ExecuteNonQuery(cmd);

        }
        public List<ActedAlarm> Filter(ActedAlarmFilter actedAlarmFilter)
        {
            List<ActedAlarm> actedAlarmFiltered = new List<ActedAlarm>();
            ApiConn.DAO.AddParameter("@StartDate", actedAlarmFilter.StartDate);
            ApiConn.DAO.AddParameter("@AlarmDescription", actedAlarmFilter.AlarmDescription);
            ApiConn.DAO.AddParameter("@EndDate", actedAlarmFilter.EndDate);

            string cmd = @"SELECT AC.Id, AC.InputDate,AC.OutputDate, 
                           A.Description as AlarmDescription, E.Name as EquipmentName,E.Description as EquipmentDescription, S.Value as AlarmStatus,
                           AC.RegisterDate as AcRegisterDate
                           FROM Alarms_Acted AC
                           INNER JOIN Alarms A ON A.Id = AC.Id_Alarm
                           INNER JOIN Equipments E ON E.Id = A.Id_Equipment
                           INNER JOIN Alarms_Status S ON S.Id = AC.Id_Status
                           WHERE
                           (
                                (@StartDate IS NULL OR @EndDate IS NULL) OR (AC.RegisterDate Between @StartDate AND @EndDate) AND
                                (@AlarmDescription IS NULL OR @AlarmDescription = '') OR (A.Description LIKE @AlarmDescription)
                           )";

            DataTable DT = ApiConn.DAO.ExecuteReader(cmd);
            foreach (DataRow row in DT.Rows)
            {
                actedAlarmFiltered.Add(new ActedAlarm
                {
                    Id = int.Parse(row["Id"].ToString()),
                    AlarmStatus = row["AlarmStatus"].ToString(),
                    AlarmDescription = row["AlarmDescription"].ToString(),
                    EquipmentDescription = row["EquipmentDescription"].ToString(),
                    InputDate = row["InputDate"] != DBNull.Value ? (DateTime)row["InputDate"] : DateTime.MinValue,
                    OutputDate = row["OutputDate"] != DBNull.Value ? (DateTime)row["OutputDate"] : DateTime.MinValue,
                    RegisterDate = row["AcRegisterDate"] != DBNull.Value ? (DateTime)row["AcRegisterDate"]:DateTime.MinValue,
                    

                });
            }
            return actedAlarmFiltered;
        }

        public List<ActedAlarmRank> GetTop3Alarms()
        {
            List<ActedAlarmRank> actedAlarmRank = new List<ActedAlarmRank>();
            

            string cmd = @"SELECT TOP(3) Id_Alarm,Count(Id_Alarm) as AlarmCount FROM Alarms_Acted
                           GROUP BY Id_Alarm
                           ORDER BY AlarmCount DESC";

            DataTable DT = ApiConn.DAO.ExecuteReader(cmd);
            foreach (DataRow row in DT.Rows)
            {
                actedAlarmRank.Add(new ActedAlarmRank
                {
                    Id = int.Parse(row["Id_Alarm"].ToString()),
                    Count = int.Parse(row["AlarmCount"].ToString()),
                });
            }
            return actedAlarmRank;
        }

    }
}
