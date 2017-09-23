import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Headers, Http } from '@angular/http';
import { Request} from '../../model/request';
import { Employee } from '../../model/Employee';
import {AssetsData} from '../../model/asset';
import{ Router } from '@angular/router';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class SupervisorService {
	constructor(private http: Http,private router:Router) { }
    //this function is used for bringing the employee list from our json
	getEmployeeListBySupervisorID(){
		
		return this.http.get('./assets/data/employee.json')
		                .map(response => response.json());
	}	
	//this function is used to bring the employee list from json but with the promise
	getmyrelatedemployee():Promise<any>
	{
		return this.http.get('./assets/data/employee.json')
						.toPromise()
						.then(response => response.json());
	}
	//this function is used to bring the detail from the temporary employee list to the form
    filldetailofemployeewanttogeneraterequest(employee:Employee):Promise<any>{

		return	this.http.post("http://localhost:56622/api/Employee",employee,{headers: new Headers({ 'Content-Type': 'application/json' })})
						 .toPromise()
						 .then(data => { if(data["_body"] == "already exist")
											{ window.alert("the employee deatail is already exist in queue") } 
										 else
											{this.router.navigate(['/supervisor/request-generate/',employee.employeeCode])}});
			
	}
	//this function is used to fetch the detail of particular employee
    getmyemployeehere(id:string):Promise<Employee>{


		return this.http.get("http://localhost:56622/api/Employee/"+id)
						.toPromise()
						.then(response => response.json() as Employee )
	}

    //this function is used to post the request detail of particular employee  followed by insert RELATED asset details
	generatenewrequest(assetdetail:AssetsData[],myrequest:Request):Promise<any> {
	
	    return	this.http.post("http://localhost:56622/api/Supervisor/PostRequest",myrequest,{headers: new Headers({ 'Content-Type': 'application/json' })})
						 .toPromise()
						 .then(data =>{ if(data["_body"] == "already exist")
											{ window.alert("the request is already exist in queue") } 
										else
											{this.insertmyassetlist(assetdetail)}});
		
	}

    //this function is used for inserting the the related asset detail
	insertmyassetlist(assetdetail:AssetsData[]):Promise<any>{

		return this.http.post("http://localhost:56622/api/Supervisor/PostAsset",assetdetail,{headers: new Headers({ 'Content-Type': 'application/json' })})
						.toPromise()
						.then(data =>{ this.router.navigate(['/supervisor'])});
	}

	//this function is used to bring the assets related to the employee
	getAsset()
	{		
		return this.http.get("./assets/data/asset.json")
						.map(response => response.json());
	}
	//this function is used for the reassignment of the asset to any other person
	reassignAssetReallocation(reassignment:AssetsData){

		return this.http.put('http://localhost:56622/api/Supervisor/PutAssets',reassignment,{headers: new Headers({'Content-Type':'application/json'})})
						.subscribe();
	}
	//this will get all the rejected asset detail of the particular employee
	getRejectAssetDetails(myemployeelist:string[]):Promise<any> {
			
		return this.http.post('http://localhost:56622/api/Supervisor/GetRejectedAssetList',myemployeelist,{headers: new Headers({ 'Content-Type': 'application/json' })})
						.toPromise()
						.then(result => JSON.parse(result["_body"]) as AssetsData[] );
	}
	//this function will get the rejected list by the employee
	getrejectemployeesbyhr(){
		return this.http.get("http://localhost:56622/api/Supervisor/GetRequest").map(result =>result.json());
	}
	//this function is used to remove the request if supervisor want
	removemyrequest(id:string){

		this.http.delete("http://localhost:56622/api/Employee/"+id,{headers: new Headers({'Content-Type':'application/json'})})
				 .subscribe();
			
	}
    //it will bring the data to update form in supervisor view
	getmyrejectrequestdetailupdate(id:string):Promise<Request>{

		return this.http.get("http://localhost:56622/api/Supervisor/GetRequestById/"+id)
						.toPromise()
						.then(data =>data.json());
						
	}
    //it will post the updated data in the table
	updatemyrejectedlist(updatedlist:Request):Promise<boolean>{
		let id:string=updatedlist.requestId;
		return this.http.put('http://localhost:56622/api/Supervisor/PutRequest/'+id,updatedlist,{headers: new Headers({'Content-Type':'application/json'})})
						.toPromise()
						.then(data => this.router.navigate(['/supervisor/rejected-request-list']));
	}


}