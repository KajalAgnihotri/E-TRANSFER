/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { HomeControlComponent } from './home-control.component';

describe('HomeControlComponent', () => {
  let component: HomeControlComponent;
  let fixture: ComponentFixture<HomeControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
