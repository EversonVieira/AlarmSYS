import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActedAlarmComponent } from './site/pages/acted-alarm/acted-alarm.component';
import { AlarmComponent } from './site/pages/alarm/alarm.component';
import { EquipmentComponent } from './site/pages/equipment/equipment.component';
import { HomeComponent } from './site/pages/home/home.component';
const routes: Routes = [
  {path:"equipment", component: EquipmentComponent},
  {path:"alarm", component: AlarmComponent},
  {path:"acted/alarm", component: ActedAlarmComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
