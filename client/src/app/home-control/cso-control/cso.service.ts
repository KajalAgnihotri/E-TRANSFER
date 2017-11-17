import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Request } from '../../model/request';
import { Employee } from '../../model/Employee';

@Injectable()
export class CsoService {
	request: Request;
    constructor(private http: Http) { }
    getViewAllRequest(){
      //this method is used to get data from API to get pending requests
        return this.http.get("http://localhost:56622/api/Cso/GetPendingCsoRequest")
                        .map(response => response.json());
            
    }
    updateApprovalStatus(request) {
      //this method is used to execute the approval request from CSO
        let id = request.requestId;
        this.http.put("http://localhost:56622/api/cso/"+id, request, { headers: new Headers({ 'Content-Type': 'application/json' }) })
                 .subscribe();
   }  
   
getAssetDetailsByCode(empCode : string) : Observable<Request[]>
   {
     //this method is used to get the asset list 
      return this.http.get("http://localhost:56622/api/cso/GetAssetDetail/" + empCode)
                      .map(response => response.json());
   }
   
}
