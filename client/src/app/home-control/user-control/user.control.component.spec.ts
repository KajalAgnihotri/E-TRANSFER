
import { async, ComponentFixture, TestBed,fakeAsync,tick} from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import{UserControlService} from './user.control.service'
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/Observable/of';
import{HttpModule} from '@angular/http'
import { UserControlComponent } from './user.control.component';
import {Employee} from '../../model/Employee';
import { Request } from '../../model/request';


let comp: UserControlComponent  ;
let fixture: ComponentFixture<UserControlComponent>;
let de:      DebugElement;
let el:      HTMLElement;
let userService;
let spy:jasmine.Spy;
let spy1:jasmine.Spy;
//let spy2:jasmine.Spy;
//describe for component
describe('UserControlComponent', () => {
  let component: UserControlComponent;
  let fixture: ComponentFixture<UserControlComponent>;

  //mock Employee data
  let data:Employee=
    { employeeCode:"344566", employeeName:"Kajal Agnihotri",
      employeeEmailId:"kajal@niit-tech.com", location:"Greater Noida", localHR:"Sheetal Malhotra",
      localCSO:"Vikas vashisht", oucode:"ou-111", pacode:"pa-101", psacode:"psa-112",
       ccCode:"cc101", companyCode:"n-111", designation:"developer",
       supervisor:"s1",dateOfTransfer:"31 oct,2017", assetCode:"123",
       supervisorName:"chandra sehgal", supervisorEmailId:"chandra@niit-tech.com"}
  
  ;
  //mock request data
let request:Request [] = [{
  employeeCode:'24354',
  supervisorCode:'345436',
  typeOfRequest:'cc',
  newpacode:'34',
  newpsacode:'454',
  newOucode:'46567',
  newCcCode:'346',
  requestStatus:'pending',
  pendingWith:'HR',
},
];



//describe for getEmployeeDetail method
  describe('getEmployeeDetail',()=>{
    beforeEach(async(() => {      //this will execute before execution of every it
      TestBed.configureTestingModule({   //with  help of configureTestingModule ,we can override pipes,declarations,imports 
        declarations: [ UserControlComponent ],
        imports:[HttpModule],
        providers:[UserControlService]  //service
      })
      .compileComponents(); //it will compile external templates,it is necessary to write this statement as this block is in async mode
    }));
  beforeEach(() => {
    fixture = TestBed.createComponent(UserControlComponent); //it will create component 
    comp = fixture.componentInstance; //it will  create component instance  and fetch component data

    //userservice injected into component
    userService=fixture.debugElement.injector.get(UserControlService); //it tells to get data from service

    //setup spy on the getEmployeeDetail method
    spy=spyOn(userService,'getEmployeeDetail').and.returnValue(Promise.resolve(data));  //it will spyOn the getEmployeeDetail function of userService and will always return mock data
    spy1=spyOn(userService,'getRequestInfoForEmployee').and.returnValue(Promise.resolve(request)); //it will spyOn the getRequestInfoForEmployee function of  userService and will always return mock data
  
  });
  //test case for getEmployeeDetails
  it('get Employee Details',fakeAsync(()=>{  //fakesync will pretend as if it is synchronous 
    fixture.detectChanges(); //test tells angular to detect changes
    tick();  //simulate the async passage of time untill all pending async activities finish
    fixture.detectChanges();
    expect(comp.employee).toEqual(data); //expectation for spec
  
  })
  )
 //test case for get request info
  it('get Request Info ',fakeAsync(()=>{ 
    fixture.detectChanges(); 
    tick();
    fixture.detectChanges();
    expect(comp.request).toEqual(request);
    console.log('Request is=',comp.request);
    // console.log(comp.request.pendingWith);
    // console.log("Request is ",request);
  })
  )
});
});
