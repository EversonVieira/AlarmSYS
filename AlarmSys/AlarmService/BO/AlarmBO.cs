using AlarmSys.Core.Connection;
using AlarmSys.Core.Treaters;
using AlarmSys.Core.Treaters.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AlarmService
{
    public class AlarmBO: INotifiable
    {
        private AlarmDAL DAL;
        private AlarmIL IntegityLayer = new AlarmIL();

        public Notifiable Notifiable { get; set; } = new Notifiable();

        public AlarmBO(ApiConnection apiConnection)
        {
            this.DAL = new AlarmDAL(apiConnection);
        }
        public int Insert(Alarm alarm)
        {
            IntegityLayer.ValidateInsert(alarm);

            if (IntegityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegityLayer.Notifications;

                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return 0;
            }
            int id = this.DAL.Insert(alarm);

            this.Notifiable.StatusCode = (int) HttpStatusCode.Created;

            return id;
        }
        public List<Alarm> Filter(AlarmFilter alarmFilter)
        {
            IntegityLayer.ValidateFilter(alarmFilter);

            if (IntegityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegityLayer.Notifications;
                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }

            List<Alarm> alarms = this.DAL.Filter(alarmFilter);

            this.Notifiable.StatusCode = (int)HttpStatusCode.OK;

            return alarms;

        }
        public Alarm Select(Alarm alarm)
        {
            IntegityLayer.ValidateSelect(alarm);

            if (IntegityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegityLayer.Notifications;
                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
            Alarm alarmObj = this.DAL.Select(alarm);

            this.Notifiable.StatusCode = (int)HttpStatusCode.OK;

            return alarmObj;
        }
        public void Update(Alarm alarm)
        {
            IntegityLayer.ValidateUpdate(alarm);

            if (IntegityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegityLayer.Notifications;
                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            this.DAL.Update(alarm);

            this.Notifiable.StatusCode = (int)HttpStatusCode.OK;

        }
        public void Delete(Alarm alarm)
        {
            IntegityLayer.ValidateDelete(alarm);

            if (IntegityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegityLayer.Notifications;
                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }
            this.DAL.Delete(alarm);

            this.Notifiable.StatusCode = (int)HttpStatusCode.OK;
        }
    }
}
