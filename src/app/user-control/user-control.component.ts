import { Component, OnInit } from '@angular/core';
import { UserControlService } from './user-control.service';
import { Employee } from '../employee';
import { Request } from '../request';
import {DatePipe} from '@angular/common'
@Component({
 selector: 'app-user-control',
 templateUrl: './user-control.component.html',
 styleUrls: ['./user-control.component.css']
})
export class UserControlComponent implements OnInit {
 employee:Employee;
 emp_id:number;
 request;
 requestStatus:string="0%";
 StatusStyle;
 constructor(private userControlService: UserControlService) { }


 ngOnInit() {
   this.userControlService.getEmployeeDetail(12156908)
   .then(data => {
     this.employee = data; this.userControlService.getRequestInfoForEmployee(12156908)
     .then(data=>{
       this.request=data;
       this.progressbarLogic();
     console.log(this.request);
     console.log(this.request.pendingWith);
     console.log(data);
   });
 });
 }

 progressbarLogic(){
   if(this.request.pendingWith=="Supervisor"){

     this.requestStatus="20%";
     this.request.pendingWith="Pending with "+this.request.pendingWith;
    }  
   else if(this.request.pendingWith=="HR"){
      this.requestStatus="40%";
      this.request.pendingWith="Pending with "+this.request.pendingWith;
     }
     else if(this.request.pendingWith=="User"){
      this.requestStatus="60%";
      this.request.pendingWith="Pending with "+this.request.pendingWith;
     }
     else if(this.request.pendingWith=="CSO"){
      this.requestStatus="80%";
      this.request.pendingWith="Pending with "+this.request.pendingWith;
     }
     else if(this.request.pendingWith=="Approved"){
      this.requestStatus="100%";
     }  
     console.log(this.requestStatus);
     this.StatusStyle={'width':this.requestStatus};
     console.log(this.StatusStyle);
   }
   
}