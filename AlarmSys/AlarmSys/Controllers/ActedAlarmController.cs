using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActedAlarmService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlarmSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActedAlarmController : ControllerRich
    {
        private ActedAlarmBO _ActedAlarmBO;
        public ActedAlarmController(ActedAlarmBO alarmBO)
        {
            this._ActedAlarmBO = alarmBO;
        }

        [HttpPost("insert")]
        public ActionResult Insert(ActedAlarm alarm)
        {
            return ActionResponse(Data: _ActedAlarmBO.Insert(alarm), BusinessObject: _ActedAlarmBO);
        }
        [HttpPost("filter")]
        public ActionResult Filter(ActedAlarmFilter alarmFilter)
        {
            return ActionResponse(Data: _ActedAlarmBO.Filter(alarmFilter), BusinessObject: _ActedAlarmBO);
        }
        [HttpPut("update")]
        public ActionResult Update(ActedAlarm alarm)
        {
            _ActedAlarmBO.Update(alarm);
            return ActionResponse(Data: null, BusinessObject: _ActedAlarmBO);
        }
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            _ActedAlarmBO.Delete(new ActedAlarm { Id = id });
            return ActionResponse(Data: null, BusinessObject: _ActedAlarmBO);
        }
    }
}
