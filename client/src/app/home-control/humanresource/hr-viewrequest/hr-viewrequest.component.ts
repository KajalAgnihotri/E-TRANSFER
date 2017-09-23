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
  requestList:Request[]=[];
  comment:string;
  id:number;
    constructor(private hrViewRequestService : HrViewRequestService) { } 
  //HrViewRequestService will provide services of connectivity to API 

  ngOnInit() {
        //This method will get all the pending request via calling HrViewRequstService
        this.hrViewRequestService.getmypendingrequestList()
                                 .then(response =>{this.requestList = response;} );
  }
 
  updateStatus(employee){
    //This method will update the status via calling HrViewRequstService
    let id = employee.requestId;
    console.log(id);
    employee.pendingWith = "Cso";
   
    this.hrViewRequestService.updateStatus(id, employee).then(data =>{
    const index= this.requestList.indexOf(employee);
    console.log(index);
    this.requestList.splice(index,1);
    });
  }

  rejectRequest(employee:Request){
    //This mathod will be called when cancelled button is clicked
    this.data=employee;
  }

  sendBack(){
    //This method will send back request to supervisor via calling HrViewRequstService
    console.log(this.comment);
    console.log(this.data);
    this.data.pendingWith = "Supervisor";
    this.hrViewRequestService.sendBack(this.comment,this.data).then(data => {
      const index= this.requestList.indexOf(this.data);
      console.log(index);
      this.requestList.splice(index,1);
    })   
  }
}
