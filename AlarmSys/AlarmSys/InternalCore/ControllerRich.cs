using AlarmSys.Core.Treaters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AlarmSys
{
    public class ControllerRich : ControllerBase
    {
        internal ActionResult ActionResponse(dynamic Data, INotifiable BusinessObject)
        {
            ResponseBase response = new ResponseBase
            {
                Success = false,
                Data = Data,
                StatusCode = BusinessObject.Notifiable.StatusCode,
                Notifications = BusinessObject.Notifiable.Notifications
            };

            if (BusinessObject.Notifiable.StatusCode == 0)
            {
                throw new Exception("Code can't be 0, should set a value to keep going.");
            }
            if (BusinessObject.Notifiable.Notifications.Any())
            {
                return BusinessObject.Notifiable.StatusCode switch
                {
                    // There should be inserted the code who gonna represent The Reponse codes 
                    (int)HttpStatusCode.BadRequest => BadRequest(response),
                    _ => BadRequest(response)
                };
            }
            else
            {
                response.Success = true;
                return BusinessObject.Notifiable.StatusCode switch
                {
                    (int)HttpStatusCode.OK => Ok(response),
                    (int)HttpStatusCode.Created => Created("", response),
                    _ => Ok(response)
                };
            }
        }
    }
}
