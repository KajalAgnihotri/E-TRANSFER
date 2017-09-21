import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Request } from '../../model/request';
import { Employee } from '../../model/Employee';

@Injectable()
export class CsoService {
	request: Request;
    constructor(private http: Http) { }
    getViewAllRequest() {
        return this.http.get("http://localhost:56622/api/Cso/GetPendingCsoRequest")
            .map(response => response.json());
            
    }
    UpdateApprovalStatus(request) {
        let id = request.requestId;
       
        this.http.put("http://localhost:56622/api/cso/"+id, request, { headers: new Headers({ 'Content-Type': 'application/json' }) })
            .subscribe();
   }  
   
getAssetDetailsByCode(empcode : string) : Observable<Request[]>
   {
      return this.http.get("http://localhost:56622/api/cso/GetAssetDetail/" + empcode)
       .map(response => response.json());
   }
   
}
