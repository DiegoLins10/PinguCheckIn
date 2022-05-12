/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { HotelReservaComponent } from './hotel-reserva.component';

describe('HotelReservaComponent', () => {
  let component: HotelReservaComponent;
  let fixture: ComponentFixture<HotelReservaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotelReservaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotelReservaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
