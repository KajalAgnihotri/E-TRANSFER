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
import { AssetControlService } from './asset-control.service';

//describe for AssetControlse
describe('AssetControlService', () => {
beforeEach(() => {
TestBed.configureTestingModule({            //importing necessary modules,injecting services
  imports: [HttpModule,RouterTestingModule],
  providers: [  
      AssetControlService,
    { provide: XHRBackend, useClass: MockBackend },
  ]
});
});
//describe for GetAssetList()
describe('GetAssetList()', () => {
  //spec for assetList
it('should return an Observable<Array<assetCode>',
    inject([AssetControlService, XHRBackend], (AssetControlService, mockBackend) => {
    const mockResponse =
       [
        { assetId: 0, assetCode: 4,description:'laptop',employeeCode:'8',quantity:'9',companyCode:'12',capitalisationDate:'21',
      location :'india', assetStatus :'pending'},
      { assetId: 1, assetCode: 4,description:'laptop',employeeCode:'8',quantity:'9',companyCode:'12',capitalisationDate:'21',
      location :'india', assetStatus :'approval'},
      { assetId: 2, assetCode: 4,description:'laptop',employeeCode:'8',quantity:'9',companyCode:'12',capitalisationDate:'21',
      location :'india', assetStatus :'approval'},
      { assetId: 3, assetCode: 4,description:'laptop',employeeCode:'8',quantity:'9',companyCode:'12',capitalisationDate:'21',
      location :'india', assetStatus :'pending'},
     
      ];
//connecting with mockBackend
    mockBackend.connections.subscribe((connection) => {
      connection.mockRespond(new Response(new ResponseOptions({
        body: JSON.stringify(mockResponse)
      })));
    });

    //expectation for AssetList
    AssetControlService.GetAssetList().subscribe((data) => {
      expect(data.length).toBe(4);
      expect(data[0].assetStatus).toEqual('pending');
      expect(data[1].assetStatus).toEqual('approval');
      expect(data[2].assetStatus).toEqual('approval');
      expect(data[3].assetStatus).toEqual('pending');
    });
}));
});

it('can instantiate service when inject service',
inject([AssetControlService], (service: AssetControlService) => {
expect(service instanceof AssetControlService).toBe(true);
}));

it('can instantiate service with "new"', inject([Http], (http: Http) => {
  expect(http).not.toBeNull('http should be provided');
  let service = new AssetControlService(http);
  expect(service instanceof AssetControlService).toBe(true, 'new service should be ok');
}));


it('can provide the mockBackend as XHRBackend',
  inject([XHRBackend], (backend: MockBackend) => {
    expect(backend).not.toBeNull('backend should be provided');
}));

});