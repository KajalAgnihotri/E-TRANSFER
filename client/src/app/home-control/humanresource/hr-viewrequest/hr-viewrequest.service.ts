import { Injectable } from '@angular/core';
import {Headers, Http } from '@angular/http';
import { Employee } from '../../../model/employee';
import { Observable } from 'rxjs/Observable';
import { Request } from '../../../model/request';
import 'rxjs/add/operator/map';

@Injectable()
export class HrViewRequestService{
    constructor(private http:Http){}

    updateStatus(id:number ,employee:Request ):Promise<any>{
        //This method is used to update the status of request via calling API
        return this.http.put("http://localhost:56622/api/HR/PutAcceptRequest/"+id,employee, { headers: new Headers({ 'Content-type': 'application/json' }) })
                        .toPromise();
    }

    sendBack(comment:string,employee:Request):Promise<any>{
        //This method is used to send back the request to supervisor
        return this.http.put("http://localhost:56622/api/HR/PutRejectRequest/"+comment, employee, { headers: new Headers({ 'Content-type': 'application/json' }) })
                        .toPromise();
    }

    getmypendingrequestlist():Promise<Request[]>{
        //This method is used to get the pending request from API
        return this.http.get('http://localhost:56622/api/HR')
                        .toPromise()
                        .then(response => response.json());
        
    }
}