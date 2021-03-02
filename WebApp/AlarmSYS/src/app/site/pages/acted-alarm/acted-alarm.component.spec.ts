import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActedAlarmComponent } from './acted-alarm.component';

describe('ActedAlarmComponent', () => {
  let component: ActedAlarmComponent;
  let fixture: ComponentFixture<ActedAlarmComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActedAlarmComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActedAlarmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
