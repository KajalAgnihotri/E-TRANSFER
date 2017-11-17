import { Component, OnInit } from '@angular/core';
import { UserControlService } from './user.control.service';
import { Employee } from '../../model/employee';
import { Request } from '../../model/request';
import { DatePipe } from '@angular/common'
@Component({
  selector: 'app-user-control',
  templateUrl: './user.control.component.html',
  styleUrls: ['./user.control.component.css']
})
export class UserControlComponent implements OnInit {
  employee: Employee;
  request;
  requestStatus: string = "0%";
  statusStyle;
  constructor(private userControlService: UserControlService) { }

  /*this will be initiated on loading of this component*/
  ngOnInit() {
    this.userControlService.getEmployeeDetail(12156955)
      /*this will return employee details*/
      .then(data => {
        this.employee = data;
         this.userControlService.getRequestInfoForEmployee(12156955) /*this will return request details of particular employee*/
          .then(data => {
            this.request = data;
            this.progressBarLogic(); /* this will will return progress of request*/
          });
      });
  }

  /*logic of progress bar*/
  progressBarLogic() {
    if (this.request.pendingWith == "Supervisor") {

      this.requestStatus = "20%";
      this.request.pendingWith = "Pending with " + this.request.pendingWith;
    }
    else if (this.request.pendingWith == "HR") {
      this.requestStatus = "40%";
      this.request.pendingWith = "Pending with " + this.request.pendingWith;
    }
    else if (this.request.pendingWith == "User") {
      this.requestStatus = "60%";
      this.request.pendingWith = "Pending with " + this.request.pendingWith;
    }
    else if (this.request.pendingWith == "CSO") {
      this.requestStatus = "80%";
      this.request.pendingWith = "Pending with " + this.request.pendingWith;
    }
    else if (this.request.pendingWith == "Approved") {
      this.requestStatus = "100%";
    }

    this.statusStyle = { 'width': this.requestStatus };

  }

}