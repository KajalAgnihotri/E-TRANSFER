import { Injectable } from '@angular/core';
import {Headers, Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Employee } from '../../model/Employee';
import { Request } from '../../model/Request';
import 'rxjs/add/operator/map';

@Injectable()
export class UserControlService{
   constructor(private http:Http){}

   /*this will return employee details from web api*/
   getEmployeeDetail(id:number):Promise<Employee>{
       console.log(id);
       return this.http.get("http://localhost:56622/api/user/GetEmployee/"+id)
       .toPromise().then(response => response.json());
   }
   /*this will return request details from web api*/
   getRequestInfoForEmployee(id:number):Promise<Request>{
       return this.http.get("http://localhost:56622/api/User/GetRequest/"+id)
       .toPromise().then(response => response.json());
   }
}