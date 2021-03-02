import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './site/pages/home/home.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { SideMenuComponent } from './core/layout/side-menu/side-menu.component';
import { EquipmentComponent } from './site/pages/equipment/equipment.component';
import { AlarmComponent } from './site/pages/alarm/alarm.component';
import { ActedAlarmComponent } from './site/pages/acted-alarm/acted-alarm.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    SideMenuComponent,
    EquipmentComponent,
    AlarmComponent,
    ActedAlarmComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
