import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/core/services/http.service';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {
  private INSERT:string = 'equipment/insert';
  private FILTER:string = 'equipment/filter';
  private SELECT:string = 'equipment/SELECT';
  private UPDATE:string = 'equipment/update';
  private DELETE:string = 'equipment/delete';
  constructor(private httpService:HttpService) { }
  insert(model){
    return this.httpService.post(this.INSERT,model);
  }
  filter(model){
    return this.httpService.post(this.FILTER,model);
  }
  update(model){
    return this.httpService.patch(this.UPDATE,model);
  }
  select(model){
    return this.httpService.delete(`${this.SELECT}/${model.id}`);
  }
  delete(model){
    return this.httpService.delete(`${this.DELETE}/${model.id}`);
  }
  
}
