import { Component, OnInit } from '@angular/core';
import { SupervisorService } from '../supervisor.service';
import{ Employee } from '../../../model/Employee';
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
    //On initilization of this component this method bring the employee list in this component
            this.supervisorService.getEmployeeListBySupervisorID()
                                  .subscribe(data => {this.employees = data;});
  }

  sendInfo(emp:Employee){
    //this will feed the employee data in the database
            let id=emp.employeeCode;
            this.supervisorService.filldetailofemployeewanttogeneraterequest(emp);
 
  }

}
