/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { HrViewrequestComponent } from './hr-viewrequest.component';

describe('HrViewrequestComponent', () => {
  let component: HrViewrequestComponent;
  let fixture: ComponentFixture<HrViewrequestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HrViewrequestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HrViewrequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
});
