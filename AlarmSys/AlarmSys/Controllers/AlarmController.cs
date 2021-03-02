using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlarmService;
using AlarmSys.Core.Treaters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlarmSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmController : ControllerRich
    {
        private AlarmBO _AlarmBO;
        public AlarmController(AlarmBO alarmBO)
        {
            this._AlarmBO = alarmBO;
        }

        [HttpPost("insert")]
        public ActionResult Insert(Alarm alarm)
        {
            return ActionResponse(Data: _AlarmBO.Insert(alarm), BusinessObject: _AlarmBO);
        }
        [HttpPost("filter")]
        public ActionResult Filter(AlarmFilter alarmFilter)
        {
            return ActionResponse(Data: _AlarmBO.Filter(alarmFilter), BusinessObject: _AlarmBO);
        }
        [HttpPut("update")]
        public ActionResult Update(Alarm alarm)
        {
            _AlarmBO.Update(alarm);
            return ActionResponse(Data: null, BusinessObject: _AlarmBO);
        }
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            _AlarmBO.Delete(new Alarm { Id = id });
            return ActionResponse(Data: null, BusinessObject: _AlarmBO);
        }
        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            return ActionResponse(_AlarmBO.Select(new Alarm { Id = id }), _AlarmBO);
        }
    }
}
