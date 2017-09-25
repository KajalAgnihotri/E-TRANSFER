/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { browser,element,by } from 'protractor';

import { RequestGenerateComponent } from './request-generate.component';

describe('RequestGenerateComponent', () => {
 
 it('form of request should pass',function(){
   browser.get("http://localhost:49152/home-control/supervisor/request-generate/121");

   element(by.id('empid')).sendKeys('121');
   element(by.id('empname')).sendKeys('ravi');

   element(by.id('email')).sendKeys('ravi123@niit-tech.com');
   element(by.id('location')).sendKeys('noida');
   element(by.id('companycode')).sendKeys('50098123');
   element(by.id('empname')).sendKeys('ravi');
   
    element.all(by.css('option')).last().click();

   element(by.name('PA')).sendKeys('345');
    element(by.name('PSA')).sendKeys('567');
     element(by.name('OU')).sendKeys('789');
      element(by.name('CC')).sendKeys('123');


   element(by.id('subbtn')).click();
   /*element(by.id('add')).click();*/
  
  browser.pause();   


 })

});