import { TestBed, async, inject } from '@angular/core/testing';
import {
HttpModule,
Http,
Response,
ResponseOptions,
XHRBackend,
RequestMethod
} from '@angular/http';

import { RouterTestingModule } from '@angular/router/testing';
import { MockBackend } from '@angular/http/testing';
import { GlobalUserService } from './globaluser.service';
import { AssetsData} from '../../model/asset'


//describe for Global User Service
describe('GlobalUserService',()=>{
    //spec for Global User Service
    beforeEach(()=>{
    TestBed.configureTestingModule({
        imports:[HttpModule],
        providers:[
            GlobalUserService,
            {provide:XHRBackend,useClass:MockBackend}
        ]
    });
    });

    //describe for method getMyPendingRequest()
    describe('getMyPendingRequest()',()=>{
        //spec for pending request
        it('should return list of pending requests',
    inject([GlobalUserService,XHRBackend],(globalUserService,mockBackend)=>{
           const mockResponse=[
               {
                   assetId:1,assetCode:1234,description:"Laptop",employeeCode:50043456,quantity:1
               },
               {
                assetId:2,assetCode:1235,description:"Mouse",employeeCode:50043453,quantity:1
               }

           ];
           //connecting to mockBackend
           mockBackend.connections.subscribe((connection)=>{
               connection.mockRespond(new Response(new ResponseOptions({
                   body:JSON.stringify(mockResponse)
               })))
              globalUserService.getMyPendingRequest().subscribe((data)=>{
                  expect(data[0].assetCode).toEqual(1234);
                  expect(data[1].assetCode).toEqual(1235);
              }
            )
           })
        }))
    //spec for approving request 
   it('should approve request and update asset status ',
    inject([GlobalUserService,XHRBackend],(globalUserService,mockBackend)=>{
        //data 
    let dat:AssetsData=new  AssetsData("1","345",
   "3456","3456","Laptop","1",
    "Greater Noida","1 may 2017","pending with hr","2527848","abc@niit-tech.com")
    //connecting to mockBackend
    let mock=new Response(new ResponseOptions({status:200,body:{dat}}));
    console.log("mock is ",mock);
    console.log("data is ",dat);
    mockBackend.connections.subscribe((connection)=>{
        connection.mockRespond(mock)
    });
    //expect statement
    globalUserService.approve(dat.assetId,dat).subscribe((result)=>{
        console.log("result is ",result);
        expect(mock.status).toBe(200);
    })
    }));
    
    //spec for rejection
    it('should reject the request',
    inject([GlobalUserService,XHRBackend],(globalUserService,mockBackend)=>{
       //data
        let data:AssetsData=new AssetsData("1","345",
        "3456","3456","Laptop","1",
         "Greater Noida","1 may 2017","pending with hr","2527848","abc@niit-tech.com")

        //connecting to mockBackend
         let mock=new Response(new ResponseOptions({status:200,body:{data}}));
         console.log("mock is ",mock);
         console.log("data is ",data);
         mockBackend.connections.subscribe((connection)=>{
             connection.mockRespond(mock);
         });
         //expect statements
         globalUserService.reject(data.assetId,data).subscribe((result)=>{
             console.log("result is ",result);
             expect(mock.status).toBe(200);
         })
    }))

    //spec for service injection
    it('can instantiate service when inject service',
       inject([GlobalUserService],(service:GlobalUserService)=>{
           expect(service instanceof(GlobalUserService)).toBe(true);
       })
    
    )
    //spec for service instantiation
    it('can instantiate with new keyword',
       inject([Http],(http:Http)=>{
           expect(http).not.toBeNull("http should be provided");
           let service=new GlobalUserService(http);
           expect(service instanceof GlobalUserService).toBe(true);
       }))
    
       //spec for checking mockBackend
       it('can provide the mockBackend as XHRBackend',
       inject([XHRBackend], (backend: MockBackend) => {
         expect(backend).not.toBeNull('backend should be provided');
      }));

})
});
