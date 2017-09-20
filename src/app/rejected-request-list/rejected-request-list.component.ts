import { Component, OnInit } from '@angular/core';
import { Request } from '../request';
import { SupervisorService } from '../supervisor/supervisor.service';
import { Employee } from '../Employee';
import { Router } from '@angular/router';
import{DatePipe} from '@angular/common';
 
@Component({
  selector: 'app-rejected-request-list',
  templateUrl: './rejected-request-list.component.html',
  styleUrls: ['./rejected-request-list.component.css']
})
export class RejectedRequestListComponent implements OnInit {
  myrejectedrequest: Request[];

  constructor(private supervisorservice: SupervisorService, private router: Router) { }


  ngOnInit() {  
    this.supervisorservice.getrejectemployeesbyhr().subscribe((response)=> {this.myrejectedrequest=response;console.log(this.myrejectedrequest+"received.....")});
  }

  remove(employeecode: string) {
    console.log(employeecode);
    this.supervisorservice.removemyrequest(employeecode);
  }

  update(id: string) {
    this.router.navigate(['/supervisor/update-rejected-list',id]);
  }
}
