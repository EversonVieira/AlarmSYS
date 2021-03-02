using AlarmSys.Core.Treaters;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentService
{
    internal class EquipmentIL:INotifiableIL
    {
        private List<Notification> _Notifications = new List<Notification>();
        public IReadOnlyCollection<Notification> Notifications => _Notifications;
        public bool ValidateInsert(Equipment equipment)
        {
            if (equipment.Id != 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = equipment.Id,
                    message = "Id can't be different than 0."
                });
            }

            if (equipment.Id_Type == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Type",
                    value = equipment.Id_Type,
                    message = "Choose an Type to insert this Equipment."
                });
            }

            if (equipment.SerialNumber == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Equipment",
                    value = equipment.SerialNumber,
                    message = "Equipment can't be inserted without an SerialNumber."
                });
            }

            if (string.IsNullOrEmpty(equipment.Name))
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = equipment.Id,
                    message = "Name should be informed."
                });
            }

            if (equipment.RegisterDate != DateTime.MinValue)
            {
                this._Notifications.Add(new Notification
                {
                    field = "RegisterDate",
                    value = equipment.RegisterDate,
                    message = "Register Date should be inserted by DataBase."
                });
            }
            return _Notifications.Count > 0 ? false : true;
        }
        public bool ValidateUpdate(Equipment equipment)
        {
            if (equipment.Id == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = equipment.Id,
                    message = "Id can't be 0."
                });
            }

            if (equipment.Id_Type == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Type",
                    value = equipment.Id_Type,
                    message = "Should choose an Type to update this register."
                });
            }

            if (equipment.SerialNumber == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id_Equipment",
                    value = equipment.SerialNumber,
                    message = "Should set an SerialNumber to update this register."
                });
            }

            if (string.IsNullOrEmpty(equipment.Name))
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = equipment.Id,
                    message = "Name should be informed."
                });
            }

            if (equipment.RegisterDate != DateTime.MinValue)
            {
                this._Notifications.Add(new Notification
                {
                    field = "RegisterDate",
                    value = equipment.RegisterDate,
                    message = "Register date should be inserted by DataBase."
                });
            }
            return _Notifications.Count > 0 ? false : true;
        }
        public bool ValidateDelete(Equipment equipment)
        {
            if (equipment.Id == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = equipment.Id,
                    message = "Id can't be 0."
                });
            }

            return _Notifications.Count > 0 ? false : true;
        }
        public bool ValidateSelect(Equipment equipment)
        {
            if (equipment.Id == 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = equipment.Id,
                    message = "Id can't be 0."
                });
            }

            return _Notifications.Count > 0 ? false : true;
        }
        public bool ValidateFilter(EquipmentFilter equipmentFilter)
        {
            if (equipmentFilter.Id != 0)
            {
                this._Notifications.Add(new Notification
                {
                    field = "Id",
                    value = equipmentFilter.Id,
                    message = "Id can't be different than 0."
                });
            }

            if (equipmentFilter.StartDate > equipmentFilter.EndDate)
            {
                this._Notifications.Add(new Notification
                {
                    field = "StartDate",
                    value = equipmentFilter.StartDate,
                    message = "StartDate can't be higher than EndDate."
                });
            }

            return _Notifications.Count > 0 ? false : true;
        }
    }
}
