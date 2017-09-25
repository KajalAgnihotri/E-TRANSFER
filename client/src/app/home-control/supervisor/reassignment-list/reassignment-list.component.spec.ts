/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { browser,element,by } from 'protractor';
import { DebugElement } from '@angular/core';

import { ReassignmentListComponent } from './reassignment-list.component';

describe('ReassignmentListComponent', () => {
  it('form of request should pass',function(){
   browser.get("http://localhost:4200/home-control/supervisor/reassignment-list");

   // element(by.id('empsearch')).sendKeys('121');
  

   element(by.id('generate')).click();
   /*element(by.id('add')).click();*/
  
  browser.pause();   


 })

});
