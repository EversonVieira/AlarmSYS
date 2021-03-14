import { Component, OnInit } from '@angular/core';
import { Alarm } from '../../models/alarm';
import { Equipment } from '../../models/equipment';
import { AlarmService } from '../../services/alarm.service';
import { EquipmentService } from '../../services/equipment.service';

@Component({
  selector: 'app-alarm',
  templateUrl: './alarm.component.html',
  styleUrls: ['./alarm.component.sass']
})
export class AlarmComponent implements OnInit {
  model:Alarm = new Alarm();
  equipments:Equipment[] = [];
  alarms:Alarm[] = [];

  constructor(private equipmentService:EquipmentService, private alarmService:AlarmService) { }

  ngOnInit(): void {
    this.filterEquipments();
    this.filterAlarms();
  }

  filterEquipments() {
    this.equipmentService.filter({
      "startDate": new Date(2000, 1, 1),
      "endDate": new Date(2022, 1, 1)
    }).subscribe((response: any) => {
      console.log(response);
      this.equipments = response.data;
    })
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

  insert(){
    this.model.id_Classification = Number(this.model.id_Classification);
    this.model.id_Equipment = Number(this.model.id_Equipment);

    console.log(this.model);
    this.alarmService.insert(this.model).subscribe((response:any)=>{
      console.log(response);

      this.filterAlarms();
    }, error => {
      alert("Error!");
      console.log(error);
    })

  }

  delete(alarm){
    this.alarmService.delete(alarm).subscribe((response:any)=>{
      console.log(response);
      alert("Successful!");
      this.filterAlarms();
    },error =>{
      console.log(error);
      alert("This alarm can't be removed.");
    });
  }
  
}
