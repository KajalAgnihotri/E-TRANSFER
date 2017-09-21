import { Component, OnInit } from '@angular/core';
import { SupervisorService } from '../supervisor.service';
import { Request } from '../../../model/request';
import {Employee } from '../../../model/Employee';
import { ActivatedRoute, ParamMap } from '@angular/router';
import {DatePipe} from '@angular/common';

@Component({
  selector: 'app-update-rejected-list',
  templateUrl: './update-rejected-list.component.html',
  styleUrls: ['./update-rejected-list.component.css']
})
export class UpdateRejectedListComponent implements OnInit {
myrejectedrequest:Request;
updaterequestlist:Request;
MyList:string[]=["PA","PSA","OU","CC"];
category:string;
newpa:string="";
newpsa:string="";
newou:string="";
newcc:string="";

   constructor(private supervisorservice:SupervisorService, private route: ActivatedRoute) { }


   ngOnInit(){
    this.route.paramMap
    .switchMap((params:ParamMap)=>this.supervisorservice.getmyrejectrequestdetailupdate(params.get('id')))
    .subscribe (data =>{ this.myrejectedrequest = data; console.log(this.myrejectedrequest) });  
     }


     defaultvalue(){ 
      console.log(this.category);
      if(this.category == "PSA"){
            this.newpa = this.myrejectedrequest.newpacode;
            this.newpsa = "";
            this.newou = "";
            this.newcc = "";
          }
      else if(this.category == "OU"){
            this.newpa = this.myrejectedrequest.newpacode;
            this.newpsa = this.myrejectedrequest.newpsacode;
            this.newou  ="";
            this.newcc ="";
          }
      else if(this.category == "CC"){
          this.newpa = this.myrejectedrequest.newpacode;
          this.newpsa = this.myrejectedrequest.newpsacode;
          this.newou = this.myrejectedrequest.newOucode;
          this.newcc ="";
          }
      else if(this.category == "PA"){
            this.newpa ="";
            this.newpsa = "";
            this.newou ="";
            this.newcc ="";
          }
      else{
            this.newpa = this.myrejectedrequest.newpacode;
            this.newpsa = this.myrejectedrequest.newpsacode;
            this.newou = this.myrejectedrequest.newOucode;
            this.newcc =this.myrejectedrequest.newCcCode;
          }
      }

  update(){
    if(this.newpa != "" && this.newpsa!="" && this.newou !="" && this.newcc!="")
    {
       this.myrejectedrequest.newpacode=this.newpa;
       this.myrejectedrequest.newpsacode=this.newpsa;
       this.myrejectedrequest.newOucode=this.newou;
       this.myrejectedrequest.newCcCode=this.newcc;
       this.updaterequestlist=this.myrejectedrequest;
       this.supervisorservice.updatemyrejectedlist(this.updaterequestlist);
    }
    else{
      window.alert("fill all detail");
    }
  }
}
