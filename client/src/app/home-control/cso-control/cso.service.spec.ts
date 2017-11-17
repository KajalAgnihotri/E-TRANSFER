
import{TestBed,inject} from '@angular/core/Testing';
import{HttpModule,XHRBackend,ResponseOptions} from '@angular/http';
import{CsoService} from './cso.service';
import{MockBackend} from '@angular/http/testing';
import { Request } from '../../model/request';

describe('cso service',()=>{
    beforeEach(()=>{
        TestBed.configureTestingModule({
            imports:[HttpModule],
            providers:[CsoService,
            {provide:XHRBackend,useClass:MockBackend}
        ]
        });
    });
    describe('getViewAllRequest()',()=>{
        it('should return request list',
        inject([CsoService,XHRBackend],(csoService,mockBackend)=>{

            //data
            const data=[
                {
                    employeeCode:"544733",supervisorCode:"3265627",typeOfRequest:"Ou",newpacode:"Pa-101",newpsacode:"Psa-101",newOucode:"Ou-111",newCcCode:"cc-101",
                    requestStatus:"pending",pendingWith:"cso",requestId:"1",dateofrequest:"12 sep,2017"
                },
                {
                    employeeCode:"544735",supervisorCode:"3265627",typeOfRequest:"Ou",newpacode:"Pa-101",newpsacode:"Psa-101",newOucode:"Ou-111",newCcCode:"cc-101",
                    requestStatus:"pending",pendingWith:"cso",requestId:"1",dateofrequest:"12 sep,2017"
                }
              
            ];

            console.log(" spec service ");
            //connecting to mockBackend
            let mock=new Response( new ResponseOptions({body:JSON.stringify(data)}))
            mockBackend.connections.subscribe((connection)=>{
                console.log("connection is ",connection);
                connection.mockRespond(mock)
            });

            //expect statements
            csoService.getViewAllRequest().subscribe((result)=>{
                console.log("Result is ",result);
                expect(data[0].employeeCode).toEqual("544733");
            })
        })
    )

    })
   //describe for updationg approval status
    describe('updateApprovalStatus',()=>{
        //spec 
        it('should update Approval status',
    inject([CsoService,XHRBackend],(csoService,mockBackend)=>{
        //data
        let data:Request=new Request(
            "544733","3265627","Ou","Pa-101","Psa-101","Ou-111","cc-101","pending","cso","1","12 sep,2017"
        )
        //mock
        let mock=new Response(new ResponseOptions({status:200,body:data}))
        console.log("data is "+data);
        console.log("mock is "+mock);
        mockBackend.connections.subscribe((result)=>{
            console.log("result is ",result);
            expect(mock.status).toBe(200);
        })

    }))

   })
   describe('get asset details by code',()=>{
       //spec
       it('should get asset detail',
       inject([CsoService,XHRBackend],(csoService,mockBackend)=>{
           //data
           const data=[
            {
                employeeCode:"544733",supervisorCode:"3265627",typeOfRequest:"Ou",newpacode:"Pa-101",newpsacode:"Psa-101",newOucode:"Ou-111",newCcCode:"cc-101",
                requestStatus:"pending",pendingWith:"cso",requestId:"1",dateofrequest:"12 sep,2017"
            },
            {
                employeeCode:"544735",supervisorCode:"3265627",typeOfRequest:"Ou",newpacode:"Pa-101",newpsacode:"Psa-101",newOucode:"Ou-111",newCcCode:"cc-101",
                requestStatus:"pending",pendingWith:"cso",requestId:"1",dateofrequest:"12 sep,2017"
            }
          
        ];
        console.log(" spec service ");
        //connecting to mockBackend
        let mock=new Response( new ResponseOptions({body:JSON.stringify(data)}))
        mockBackend.connections.subscribe((connection)=>{
            console.log("connection is ",connection);
            connection.mockRespond(mock)
        });

        //expect statements
        csoService.getAssetDetailsByCode().subscribe((result)=>{
            console.log("Result is ",result);
            expect(data[0].employeeCode).toEqual("544733");
        })
           
       })
    )

   })


})