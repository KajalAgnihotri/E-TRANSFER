import { Component, OnInit } from '@angular/core';
import { SupervisorService } from '../supervisor/supervisor.service';
import{ Employee } from '../Employee';
import{ Router } from '@angular/router';
import { DatePipe,TitleCasePipe } from '@angular/common';


@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  employees:Employee[];
  employee:Employee;
  constructor(private supervisorService: SupervisorService,private router:Router) { }

  ngOnInit() {
    console.log("employeeelist.........");
    this.supervisorService.getEmployeeListBySupervisorID()
    .subscribe(data => {
      this.employees = data;
    });
  }

  sendInfo(emp:Employee){
      let id=emp.employeeCode;
      this.supervisorService.filldetailofemployeewanttogeneraterequest(emp);
      console.log(id+"id sent !!!!!!");
  }

}
