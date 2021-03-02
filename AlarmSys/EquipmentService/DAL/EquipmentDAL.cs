using AlarmSys.Core.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EquipmentService
{
    internal class EquipmentDAL
    {
        private ApiConnection ApiConn;

        public EquipmentDAL(ApiConnection apiConnection)
        {
            this.ApiConn = apiConnection;
        }

        public int Insert(Equipment equipment)
        {
            string cmd = @"INSERT INTO Equipments(Name,SerialNumber,Id_Type,Description)
                           VALUES(@Name,@SerialNumber,@Id_Type,@Description) SELECT SCOPE_IDENTITY()";

            ApiConn.DAO.AddParameter("@Name", equipment.Name);
            ApiConn.DAO.AddParameter("@SerialNumber", equipment.SerialNumber);
            ApiConn.DAO.AddParameter("@Id_Type", equipment.Id_Type);
            ApiConn.DAO.AddParameter("@Description", equipment.Description);


            return ApiConn.DAO.ExecuteScalar(cmd);
        }
        public void Update(Equipment equipment)
        {
            string cmd = @"UPDATE Equipments SET
                            Name              = @Name,
                            SerialNumber      = @SerialNumber,
                            Id_Type           = @Id_Type,
                            Description       = @Description
                            WHERE Id = @Id";


            ApiConn.DAO.AddParameter("@Id", equipment.Id);
            ApiConn.DAO.AddParameter("@Name", equipment.Name);
            ApiConn.DAO.AddParameter("@SerialNumber", equipment.SerialNumber);
            ApiConn.DAO.AddParameter("@Description", equipment.Description);
            ApiConn.DAO.AddParameter("@Id_Type", equipment.Id_Type);


            ApiConn.DAO.ExecuteNonQuery(cmd);
        }
        public void Delete(Equipment equipment)
        {
            string cmd = @"DELETE FROM Equipments WHERE Id = @Id";

            ApiConn.DAO.AddParameter("@Id", equipment.Id);

            ApiConn.DAO.ExecuteNonQuery(cmd);

        }
        public List<Equipment> Filter(EquipmentFilter equipment)
        {
            List<Equipment> equipments = new List<Equipment>();

            ApiConn.DAO.AddParameter("@Name", equipment.Name);
            ApiConn.DAO.AddParameter("@SerialNumber", equipment.SerialNumber);
            ApiConn.DAO.AddParameter("@Id_Type", equipment.Id_Type);
            ApiConn.DAO.AddParameter("@StartDate", equipment.StartDate);
            ApiConn.DAO.AddParameter("@EndDate", equipment.EndDate);

            string cmd = @"SELECT Id,[Name],SerialNumber,Id_Type,RegisterDate,Description
                           FROM Equipments WHERE
                           (
                                (@Name IS NULL) OR ([Name] LIKE @Name) AND
                                (@SerialNumber IS NULL) OR (SerialNumber = @SerialNumber) AND
                                (@Id_Type IS NULL) OR (Id_Type = @Id_Type) AND
                                (@StartDate IS NULL OR @EndDate IS NULL) OR (RegisterDate Between @StartDate AND @EndDate)
                           )";

            DataTable DT = ApiConn.DAO.ExecuteReader(cmd);
            foreach (DataRow row in DT.Rows)
            {
                equipments.Add(new Equipment
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                    Description = row["Description"].ToString(),
                    SerialNumber = int.Parse(row["SerialNumber"].ToString()),
                    Id_Type = int.Parse(row["Id_Type"].ToString()),
                    RegisterDate = (DateTime)row["RegisterDate"]
                });
            }
            return equipments;
        }
        public Equipment Select(Equipment equipment)
        {
            List<Equipment> equipments = new List<Equipment>();
            string cmd = @"SELECT Id,[Name],SerialNumber,Id_Type,RegisterDate,Description
                           FROM Equipments WHERE Id = @Id";

            ApiConn.DAO.AddParameter("@Id", equipment.Id);

            DataTable DT = ApiConn.DAO.ExecuteReader(cmd);

            foreach (DataRow row in DT.Rows)
            {
                equipments.Add(new Equipment
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                    Description = row["Description"].ToString(),
                    SerialNumber = int.Parse(row["SerialNumber"].ToString()),
                    Id_Type = int.Parse(row["Id_Type"].ToString()),
                    RegisterDate = (DateTime)row["RegisterDate"]
                });
            }

            return equipments.FirstOrDefault();
        }
    }
}
