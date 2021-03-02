using AlarmSys.Core.Connection;
using AlarmSys.Core.Treaters;
using AlarmSys.Core.Treaters.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ActedAlarmService
{
    public class ActedAlarmBO:INotifiable
    {
        private ActedAlarmDAL DAL;
        private ActedAlarmIL IntegityLayer = new ActedAlarmIL();

        public Notifiable Notifiable { get; set; } = new Notifiable();

        public ActedAlarmBO(ApiConnection apiConnection)
        {
            this.DAL = new ActedAlarmDAL(apiConnection);
        }
        public int Insert(ActedAlarm actedAlarmIL)
        {
            IntegityLayer.ValidateInsert(actedAlarmIL);

            if (IntegityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegityLayer.Notifications;

                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return 0;
            }
            int id = this.DAL.Insert(actedAlarmIL);

            this.Notifiable.StatusCode = (int)HttpStatusCode.Created;

            return id;
        }
        public List<ActedAlarm> Filter(ActedAlarmFilter actedAlarmFilter)
        {
            IntegityLayer.ValidateFilter(actedAlarmFilter);

            if (IntegityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegityLayer.Notifications;
                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }

            List<ActedAlarm> alarms = this.DAL.Filter(actedAlarmFilter);

            this.Notifiable.StatusCode = (int)HttpStatusCode.OK;

            return alarms;

        }
        public void Update(ActedAlarm actedAlarm)
        {
            IntegityLayer.ValidateUpdate(actedAlarm);

            if (IntegityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegityLayer.Notifications;
                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            this.DAL.Update(actedAlarm);

            this.Notifiable.StatusCode = (int)HttpStatusCode.OK;

        }
        public void Delete(ActedAlarm actedAlarm)
        {
            IntegityLayer.ValidateDelete(actedAlarm);

            if (IntegityLayer.Notifications.Count > 0)
            {
                this.Notifiable.Notifications = IntegityLayer.Notifications;
                this.Notifiable.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }
            this.DAL.Delete(actedAlarm);

            this.Notifiable.StatusCode = (int)HttpStatusCode.OK;
        }
    }
}
