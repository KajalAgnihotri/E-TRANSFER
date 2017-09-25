/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { browser,element,by } from 'protractor';

import { EmployeeListComponent } from './employee-list.component';

describe('EmployeeListComponent', () => {
 
 it('employee list should pass',function(){
   browser.get("http://localhost:49152/home-control/supervisor/employee-list");
  element(by.css('tr:first-of-type > td:last-child > button:first-of-type')).click();
  
   browser.pause();   

 })

});
