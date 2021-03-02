using AlarmSys.Core.Connection;
using AlarmSys.Core.Treaters;
using AlarmSys.Core.Treaters.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EquipmentService
{
    public class EquipmentBO:INotifiable
    {
        private EquipmentDAL DAL;
        private EquipmentIL IntegrityLayer;
        public Notifiable Notifiable { get; set; }

        public EquipmentBO(ApiConnection apiConnection)
        {
            this.DAL = new EquipmentDAL(apiConnection);
            this.IntegrityLayer = new EquipmentIL();
            this.Notifiable = new Notifiable();
        }

        public int Insert(Equipment equipment)
        {
            IntegrityLayer.ValidateInsert(equipment);

            if (IntegrityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegrityLayer.Notifications;

                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return 0;
            }
            int id = this.DAL.Insert(equipment);

            this.Notifiable.StatusCode = (int)HttpStatusCode.Created;

            return id;
        }
        public List<Equipment> Filter(EquipmentFilter equipmentFilter)
        {
            IntegrityLayer.ValidateFilter(equipmentFilter);

            if (IntegrityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegrityLayer.Notifications;
                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }

            List<Equipment> equipments = this.DAL.Filter(equipmentFilter);

            this.Notifiable.StatusCode = (int)HttpStatusCode.OK;

            return equipments;

        }
        public Equipment Select(Equipment equipment)
        {
            IntegrityLayer.ValidateSelect(equipment);

            if (IntegrityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegrityLayer.Notifications;
                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
            Equipment equipmentObj = this.DAL.Select(equipment);

            this.Notifiable.StatusCode = (int)HttpStatusCode.OK;

            return equipmentObj;
        }
        public void Update(Equipment equipment)
        {
            IntegrityLayer.ValidateUpdate(equipment);

            if (IntegrityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegrityLayer.Notifications;
                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            this.DAL.Update(equipment);

            this.Notifiable.StatusCode = (int)HttpStatusCode.OK;

        }
        public void Delete(Equipment equipment)
        {
            IntegrityLayer.ValidateDelete(equipment);

            if (IntegrityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegrityLayer.Notifications;
                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }
            this.DAL.Delete(equipment);

            this.Notifiable.StatusCode = (int)HttpStatusCode.OK;
        }
    }
}
