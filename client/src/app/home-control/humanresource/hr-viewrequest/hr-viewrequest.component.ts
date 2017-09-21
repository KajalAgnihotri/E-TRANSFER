import { Component, OnInit } from '@angular/core';
import { HrViewRequestService } from './hr-viewrequest.service'; 
import { Employee } from '../../../model/employee';
import { Request } from '../../../model/request';
import {DatePipe} from '@angular/common';

@Component({
  selector: 'app-hr-viewrequest',
  templateUrl: './hr-viewrequest.component.html',
  styleUrls: ['./hr-viewrequest.component.css']
})
export class HrViewrequestComponent implements OnInit {
  data;
  requestlist:Request[]=[];
  comment:string;
  id:number;
  ele:Request;
  constructor(private hrViewRequestService : HrViewRequestService) { }

  ngOnInit() {
        this.hrViewRequestService.getmypendingrequestlist().then(response =>{this.requestlist = response;console.log(this.requestlist);} );
  }
 
  updateStatus(employee){
    let id = employee.requestId;
    console.log(id);
    employee.pendingWith = "Cso";
   
    this.hrViewRequestService.updateStatus(id, employee).then(data =>{
    const index= this.requestlist.indexOf(employee);
    console.log(index);
    this.requestlist.splice(index,1);
    });

   

  }

  rejectRequest(employee:Request){
    this.data=employee;
  }

  sendBack(){
    console.log(this.comment);
    console.log(this.data);
    this.data.pendingWith = "Supervisor";
    this.hrViewRequestService.sendBack(this.comment,this.data).then(data => {
      const index= this.requestlist.indexOf(this.data);
      console.log(index);
      this.requestlist.splice(index,1);
    })

   
  }
}
