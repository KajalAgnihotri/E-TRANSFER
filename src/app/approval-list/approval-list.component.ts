import { Component, OnInit } from '@angular/core';
import { CsoService } from "../cso-control/cso.service";
import { Request } from '../request';
import { Employee } from "../Employee";
import {DatePipe , TitleCasePipe} from '@angular/common';

@Component({
  selector: 'app-approval-list',
  templateUrl: './approval-list.component.html',
  styleUrls: ['./approval-list.component.css']
})
export class ApprovalListComponent implements OnInit {
  myreqlist:Request[] ;
  myassetdetail : Request[]=[];
  value:number;
  constructor( private csoService : CsoService ) {   }
  ngOnInit() {
    this.csoService.getViewAllRequest()
    .subscribe(response => {console.log(response);this.myreqlist=response } );
    
  }
  getAssetDetails(assetcode : string)
  {
    this.csoService.getAssetDetailsByCode(assetcode)
    .subscribe(response => {console.log(response);this.myassetdetail = response});
  }
  approveUserRequest(myList )
  {
  //  myList.requestId=this.value;
    myList.requestStatus = "Cleared";
    myList.pendingWith = "Approved";
    console.log(myList);
    this.csoService.UpdateApprovalStatus(myList);

    const index=this.myreqlist.indexOf(myList);
    this.myreqlist.splice(index,1);
   
  }
}