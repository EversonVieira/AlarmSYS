import { Injectable } from '@angular/core';
import { from } from 'rxjs';
import {HttpService} from '../../core/services/http.service'
@Injectable({
  providedIn: 'root'
})


export class ActedAlarmService {

  private INSERT:string = 'actedalarm/insert';
  private FILTER:string = 'actedalarm/filter';
  private UPDATE:string = 'actedalarm/update';
  private DELETE:string = 'actedalarm/delete';

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
  delete(model){
    return this.httpService.delete(`${this.DELETE}/${model.id}`);
  }
}
