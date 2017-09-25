import { Component, OnInit,Input } from '@angular/core';
import{ Employee } from '../../../model/Employee';
import { SupervisorService } from '../supervisor.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Request } from '../../../model/request';


import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-request-generate',
  templateUrl: './request-generate.component.html',
  styleUrls: ['./request-generate.component.css'],

})
export class RequestGenerateComponent implements OnInit {
 myemployee:Employee;
 mynewrequest:Request;
 newpa:string="";
 newpsa:string="";
 newou:string="";
 newcc:string="";
 data:Request;
 category:string;
 mypendingrequest:string;
 MyList:string[]=["PA","PSA","OU","CC"];

  constructor(private supervisorService: SupervisorService, private route: ActivatedRoute) { }

  ngOnInit() {
    
    this.route.paramMap
              .switchMap((params:ParamMap)=>this.supervisorService.getmyemployeehere(params.get('id')))
              .subscribe (data =>{ this.myemployee = data;console.log(this.myemployee);});      
}
defaultvalue(){ 
console.log(this.category);
if(this.category == "PSA"){
  this.newpa= this.myemployee.pacode;
  this.newpsa= "";
  this.newou="";
  this.newcc=""
}
if(this.category == "OU"){
  this.newpa= this.myemployee.pacode;
  this.newpsa= this.myemployee.psacode;
  this.newou="";
  this.newcc=""
}
else if(this.category == "CC"){
 this.newpa= this.myemployee.pacode;
 this.newpsa= this.myemployee.psacode;
 this.newou= this.myemployee.oucode;
 this.newcc=""
}
else if(this.category == "PA"){
  this.newpa="";
  this.newpsa= "";
  this.newou="";
  this.newcc=""
}
else{
  this.newpa= this.myemployee.pacode;
  this.newpsa= this.myemployee.psacode;
  this.newou= this.myemployee.oucode;
  this.newcc=this.myemployee.ccCode;
}
}

assignasset(){

     if(this.newpa == this.myemployee.pacode &&  this.newpsa == this.myemployee.psacode && this.newou == this.myemployee.oucode
     &&  this.newcc ==this.myemployee.ccCode){

        window.alert("oopss already in this deparment, try with other code !!!!!");
    }
     else{
            this.data =new Request(this.myemployee.employeeCode,this.myemployee.supervisor,
                                    this.category,this.newpa,this.newpsa,this.newou,this.newcc,
                                    "pending","HR");
    }
}
}
