//import statements
import { TestBed, async, inject } from '@angular/core/testing';
import {
HttpModule,
Http,
Response,
ResponseOptions,
XHRBackend
} from '@angular/http';

import { RouterTestingModule } from '@angular/router/testing';
import { MockBackend } from '@angular/http/testing';
import { UserControlService } from './user.control.service';

//describe for user service
describe(' UserControlService ', () => { 
beforeEach(() => {
TestBed.configureTestingModule({  //importing necessary modules,injecting services
  imports: [HttpModule,RouterTestingModule],
  providers: [  
    UserControlService ,
    { provide: XHRBackend, useClass: MockBackend }, 
  ]
});
});
//describe for method GetEmployeeDetail()
describe('GetEmployeeDetail()', () => {

// spec for employee details
it('should return employee details',
    inject([UserControlService , XHRBackend], (UserControlService, mockBackend) => {
    const mockResponse =    //mockData
       [
        { employeeCode: 0, employeeName:"Kajal Agnihotri",designation:"Full stack developer",employeeEmailId:"kajal@niit-tech.com",ccCode:"cc101",oucode:"ou101",
        pacode:"pa101",psacode:"psa101" , location:"Greater noida"},
        { employeeCode: 1, employeeName:"Ishu Tripathi",designation:"Full stack developer",employeeEmailId:"ishu@niit-tech.com",ccCode:"cc101",oucode:"ou101",
        pacode:"pa101",psacode:"psa101" , location:"Greater noida"}
     
      ];
      //connecting to mockBackend
    mockBackend.connections.subscribe((connection) => {
      connection.mockRespond(new Response(new ResponseOptions({
        body: JSON.stringify(mockResponse)
      })));
    });
    //expectations for employeeDetails
    UserControlService.getEmployeeDetail().then((data) => {
   expect(data[0].employeeCode).toEqual(0);
    expect(data[1].employeeName).toEqual("Ishu Tripathi");
});
}));
});

//describe for Request Details
describe('getRequestInfoForEmployee()', () => {
  
  it('should return request details',
      inject([UserControlService , XHRBackend], (UserControlService, mockBackend) => {
      const mockResponse =   //mock for request data
         [
          { requestId: 0, pendingWith:"CSO"},
          { requestId: 1, pendingWith:"HR"}
       
        ];
  //connecting to mockBackend
      mockBackend.connections.subscribe((connection) => {
        connection.mockRespond(new Response(new ResponseOptions({
          body: JSON.stringify(mockResponse)
        })));
      });
      //expectations for RequestDetails spec
      UserControlService.getRequestInfoForEmployee().then((data) => {
        expect(data[0].requestId).toEqual(0);
       expect(data[1].pendingWith).toEqual("HR");
   });
  }));
  });

  //spec for checking service injection
it('can instantiate service when inject service',
inject([UserControlService], (service: UserControlService) => {
expect(service instanceof UserControlService).toBe(true);
}));

//spec for checking service instantiation
it('can instantiate service with "new"', inject([Http], (http: Http) => {
  expect(http).not.toBeNull('http should be provided');
  let service = new UserControlService(http);
  expect(service instanceof UserControlService).toBe(true, 'new service should be ok');
}));

//spec for checking if mockBackend is provided or not
it('can provide the mockBackend as XHRBackend',
//injecting dependencies 
  inject([XHRBackend], (backend: MockBackend) => {
    expect(backend).not.toBeNull('backend should be provided'); //checking whether backend is there or not
}));

});