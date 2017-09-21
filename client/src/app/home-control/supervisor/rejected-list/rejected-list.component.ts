import { Component, OnInit } from '@angular/core';
import {SupervisorService} from '../supervisor.service';
import {AssetsData} from '../../../model/asset';
import {Employee} from '../../../model/Employee';


@Component({
  selector: 'app-rejected-list',
  templateUrl: './rejected-list.component.html',
  styleUrls: ['./rejected-list.component.css']
})
export class RejectedListComponent implements OnInit {
myrejectedassetlist:AssetsData[];
myrelatedemployees:string[]=[];
myemployee:Employee[]=[];
  constructor(private supersearch:SupervisorService) { }
  
    ngOnInit() {
      console.log("employeeelist.........");
      this.supersearch.getmyrelatedemployee()
      .then(data =>{ this.myemployee = data;
        this.myemployee.filter((object) => {
         this.myrelatedemployees.push(object.employeeCode);
        });
        this.getDetails(this.myrelatedemployees);
      });

          // this.getDetails();
    }
    getDetails(myemp:string[]){
        this.supersearch.getRejectAssetDetails(myemp)
        .then(data => {this.myrejectedassetlist = data});
    }
  
    reassign(updatedlist:AssetsData){
      this.supersearch.reassignAssetReallocation(updatedlist);
    }
  
  
}
