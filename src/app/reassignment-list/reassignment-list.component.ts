import { Component, OnInit,Input } from '@angular/core';
import { SupervisorService } from '../supervisor/supervisor.service';
import { HttpClient } from '@angular/common/http';
import {Request} from '../request';
import {AssetsData} from '../asset';
import { Employee} from '../Employee';
import { Observable }        from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';

@Component({
  selector: 'app-reassignment-list',
  templateUrl: './reassignment-list.component.html',
  styleUrls: ['./reassignment-list.component.css']
})
export class ReassignmentListComponent implements OnInit {
@Input() request:Request;

assetList:AssetsData[];
demolist:AssetsData[]=[];
myassetList:AssetsData[];
employees:Employee[];
myemployeedetail:Employee;
mysimilaremployeecode:string[]=[];
mylistofemployee:string[]=[];



  constructor(private assetService:SupervisorService) { }

  ngOnInit() {
    console.log(this.request);
    this.assetService.getAsset()
    .subscribe(asset=>{  this.myassetList=asset;
    console.log(this.myassetList);this.getmyspecificassetlist(this.myassetList)});

    this.assetService.getEmployeeListBySupervisorID()
    .subscribe(data => 
      {this.employees = data; 
      this.assetService.getmyemployeehere(this.request.employeeCode)
                       .then(data =>{ this.myemployeedetail=data;console.log(this.myemployeedetail);
                      this.getmystringarrayofemployee()})});

   
  }

 getmyspecificassetlist(assetlist:AssetsData[]){


  assetlist.forEach(dhiru => {console.log(dhiru); 
        console.log(this.request.employeeCode);
        console.log(dhiru.employeeCode );
        if(dhiru.employeeCode == this.request.employeeCode)
        {
          this.demolist.push(dhiru);
          console.log("succcccc");
        }
        this.assetList=this.demolist;
      }); 
 }



  getmystringarrayofemployee(){
      this.employees.forEach(element => {
        if(element.companyCode == this.myemployeedetail.companyCode){
          this.mysimilaremployeecode.push(element.employeeCode+element.employeeName)
        }
      });
      console.log(this.mysimilaremployeecode);
  }
 search(finding){
    this.mylistofemployee=[];
        this.mysimilaremployeecode.forEach((myvalue)=>{ if(myvalue.startsWith(finding))
        {this.mylistofemployee.push(myvalue);}
      } )       
 }
 gotoDetail(hero){

 }
  Assign(assignedasset:AssetsData)
       {
         this.assetService.assetReallocation(assignedasset);       
      }
      GenrateRequest(){
    this.assetService.generatenewrequest(this.assetList,this.request);
  }

}

