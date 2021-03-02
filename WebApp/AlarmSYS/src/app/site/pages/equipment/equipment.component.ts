import { Component, OnInit } from '@angular/core';
import { Equipment } from '../../models/equipment';
import { EquipmentService } from '../../services/equipment.service';

@Component({
  selector: 'app-equipment',
  templateUrl: './equipment.component.html',
  styleUrls: ['./equipment.component.sass']
})
export class EquipmentComponent implements OnInit {

  constructor(private equipmentService: EquipmentService) { }

  ngOnInit(): void {
    this.filter();
  }
  model: Equipment = new Equipment();
  equipments: Equipment[] = [];

  insert() {
    this.model.id_Type = Number(this.model.id_Type);

    this.equipmentService.insert(this.model).subscribe(response => {
      console.log(response);

      this.filter();

    });

  }
  filter() {
    this.equipmentService.filter({
      "startDate": new Date(2000, 1, 1),
      "endDate": new Date(2022, 1, 1)
    }).subscribe((response: any) => {
      console.log(response);
      this.equipments = response.data;
    })
  }
  delete(equipment:Equipment){
    this.equipmentService.delete(equipment).subscribe((response:any)=>{
      console.log(response);

      this.filter();
    },error =>{
      console.log(error);
      alert("This register can't be removed.");
    });
  }
}

