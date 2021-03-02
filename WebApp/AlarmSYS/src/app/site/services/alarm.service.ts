import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/core/services/http.service';

@Injectable({
  providedIn: 'root'
})
export class AlarmService {

  private INSERT:string = 'alarm/insert';
  private FILTER:string = 'alarm/filter';
  private SELECT:string = 'alarm/SELECT';
  private UPDATE:string = 'alarm/update';
  private DELETE:string = 'alarm/delete';
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
