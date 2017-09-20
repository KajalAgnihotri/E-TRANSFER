import { Injectable } from '@angular/core';
import {Headers, Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Employee } from '../Employee';
import { Request } from '../Request';
import 'rxjs/add/operator/map';

@Injectable()
export class UserControlService{
   constructor(private http:Http){}
   getEmployeeDetail(id:number):Promise<Employee>{
       console.log(id);
       return this.http.get("http://localhost:56622/api/user/GetEmployee/"+id)
       .toPromise().then(response => response.json());
   }
   getRequestInfoForEmployee(id:number):Promise<Request>{
       return this.http.get("http://localhost:56622/api/User/GetRequest/"+id)
       .toPromise().then(response => response.json());
   }
}