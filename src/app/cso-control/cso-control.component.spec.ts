/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CsoControlComponent } from './cso-control.component';

describe('CsoControlComponent', () => {
  let component: CsoControlComponent;
  let fixture: ComponentFixture<CsoControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsoControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsoControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
