/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { browser,element,by } from 'protractor';

import { HomeControlComponent } from './home-control.component';

describe('HomeControlComponent', () => {
 
 it('home control should pass',function(){
   browser.get("http://localhost:49152/home-control");

   element(by.id('inputEmail')).sendKeys('supervisor@123');
  //element(by.name('cardNo')).sendKeys('123');
   element(by.id('inputPassword')).sendKeys('supervisor');

   element(by.id('subbtn')).click();
   /*element(by.id('add')).click();*/
  
  //browser.pause();   

 })

});