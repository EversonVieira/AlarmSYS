using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlarmSys;
using EquipmentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerRich
    {
        private EquipmentBO _EquipmentBO;
        public EquipmentController(EquipmentBO equipmentBO)
        {
            this._EquipmentBO = equipmentBO;
        }

        [HttpPost("insert")]
        public ActionResult Insert(Equipment equipment)
        {
            return ActionResponse(Data: _EquipmentBO.Insert(equipment), BusinessObject: _EquipmentBO);
        }
        [HttpPost("filter")]
        public ActionResult Filter(EquipmentFilter equipmentFilter)
        {
            return ActionResponse(Data: _EquipmentBO.Filter(equipmentFilter), BusinessObject: _EquipmentBO);
        }
        [HttpPut("update")]
        public ActionResult Update(Equipment equipment)
        {
            _EquipmentBO.Update(equipment);
            return ActionResponse(Data: null, BusinessObject: _EquipmentBO);
        }
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            _EquipmentBO.Delete(new Equipment { Id = id });
            return ActionResponse(Data: null, BusinessObject: _EquipmentBO);
        }
        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            return ActionResponse(_EquipmentBO.Select(new Equipment { Id = id }), _EquipmentBO);
        }
    }
}
