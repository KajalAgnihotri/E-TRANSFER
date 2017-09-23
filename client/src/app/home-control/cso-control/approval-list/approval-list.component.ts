import { Component, OnInit } from '@angular/core';
import { CsoService } from "../cso.service";
import { Request } from '../../../model/request';
import { Employee } from '../../../model/Employee';
import {DatePipe , TitleCasePipe} from '@angular/common';

@Component({
  selector: 'app-approval-list',
  templateUrl: './approval-list.component.html',
  styleUrls: ['./approval-list.component.css']
})
export class ApprovalListComponent implements OnInit {
  myReqList:Request[] ;
  myAssetDetail : Request[]=[];
  value:number;
  constructor( private csoService : CsoService ) {   } //CsoService will be used to connect with the API
  ngOnInit() {
    //getting data from API to Angular Application when the page is executed for the first time
    //calling servive from here
    this.csoService.getViewAllRequest()
                   .subscribe(response => {this.myReqList=response } ); 
  }
  getAssetDetails(assetCode : string)
  {
    //getting data from service when button of get asset list pressed
    this.csoService.getAssetDetailsByCode(assetCode)
                   .subscribe(response => {this.myAssetDetail = response});
  }
  approveUserRequest(myList)
  {
    //This method is called when CSO accepts Approve the Request
    //This will call service
    myList.requestStatus = "Cleared";
    myList.pendingWith = "Approved";
    this.csoService.updateApprovalStatus(myList);

    //Removing the row immediately when CSO accept the request
    const index=this.myReqList.indexOf(myList);
    this.myReqList.splice(index,1); 
  }
}