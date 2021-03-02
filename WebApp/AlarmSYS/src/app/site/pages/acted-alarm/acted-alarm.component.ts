import { Component, OnInit } from '@angular/core';
import { ActedAlarm } from '../../models/acted-alarm';
import { Alarm } from '../../models/alarm';
import { AlarmRank } from '../../models/alarm-rank';
import { ActedAlarmService } from '../../services/acted-alarm.service';
import { AlarmService } from '../../services/alarm.service';

@Component({
  selector: 'app-acted-alarm',
  templateUrl: './acted-alarm.component.html',
  styleUrls: ['./acted-alarm.component.sass']
})
export class ActedAlarmComponent implements OnInit {
  rawActedAlarmsList:ActedAlarm[] = [];
  alarms:Alarm[] = [];
  alarmRank:AlarmRank[] = [];
  filter:string = "";
  model:ActedAlarm = new ActedAlarm();
  actedAlarms:ActedAlarm[] = [];
  constructor(private alarmService:AlarmService, private actedAlarmService:ActedAlarmService) { }

  ngOnInit(): void {
    this.filterAlarms();
    this.filterActedAlarms();
    this.getAlarmRank();
  }

  filterAlarms(){
    this.alarmService.filter({
      "startDate": new Date(2000, 1, 1),
      "endDate": new Date(2022, 1, 1)
    }).subscribe((response: any) => {
      console.log(response);
      this.alarms = response.data;
    })
  }

  filterActedAlarms(){
    this.actedAlarmService.filter({
      "startDate": new Date(2000, 1, 1),
      "endDate": new Date(2022, 1, 1)
    }).subscribe((response: any) => {
      this.rawActedAlarmsList = response.data;
      this.actedAlarms = response.data;
    })
  }

  getAlarmRank(){
    this.actedAlarmService.getTop3().subscribe((response:any)=>{
      this.alarmRank = response.data;
    })
  }

  insert(){
    this.model.id_Alarm = Number(this.model.id_Alarm);
    this.model.id_Status = Number(this.model.id_Status);

    console.log(this.model);
    this.actedAlarmService.insert(this.model).subscribe((response:any)=>{
      console.log(response);

      this.filterAlarms();
    })
  }

  delete(actedAlarm:ActedAlarmComponent){
    this.actedAlarmService.delete(actedAlarm).subscribe((response:any)=>{
      console.log(response);
    },error => {
      console.log(error);
      alert("This register can't be removed.");
    })
  }

  changeFilter(){
    this.actedAlarms = this.rawActedAlarmsList.filter(x => x.alarmDescription == this.filter);
  }
  
  changeOrder(ordenator:string){
    if (ordenator == 'AlarmDescription'){
      this.actedAlarms = this.rawActedAlarmsList.sort((a,b) => a.alarmDescription.length < b.alarmDescription.length ? 1:-1)
    }
    if (ordenator == 'EquipmentDescription'){
      this.actedAlarms = this.rawActedAlarmsList.sort((a,b) => a.equipmentDescription.length < b.equipmentDescription.length ? 1:-1)
    }
    if (ordenator == 'Alarmstatus'){
      this.actedAlarms = this.rawActedAlarmsList.sort((a,b) => a.alarmStatus < b.alarmStatus ? 1:-1)
    }
    if (ordenator == 'InputDate'){
      this.actedAlarms = this.rawActedAlarmsList.sort((a,b) => a.inputDate < b.inputDate ? 1:-1)
    }
    if (ordenator == 'OutputDate'){
      this.actedAlarms = this.rawActedAlarmsList.sort((a,b) => a.outputDate < b.outputDate ? 1:-1)
    }
   console.log(this.actedAlarms);
  }
}
