import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Headers, Http } from '@angular/http';
import { AssetsData} from '../asset';
import {Employee} from '../Employee';
import {Request} from '../request';
import{ Router } from '@angular/router';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class SupervisorService {
	constructor(private http: Http,private router:Router) { }

	getEmployeeListBySupervisorID(){
		// here this method will get all the list of the employee list which is associated with the supervisor
		return this.http.get('./assets/data/employee.json').
		map(response => response.json());
	}	
	
	getmyrelatedemployee():Promise<any>
	{
		return this.http.get('./assets/data/employee.json').
		toPromise().then(response => response.json());
	}

    filldetailofemployeewanttogeneraterequest(employee:Employee):Promise<any>{
	return	this.http.post("http://localhost:56622/api/Employee",employee,
		{
			headers: new Headers({ 'Content-Type': 'application/json' })
		}).toPromise().then(data => { if(data["_body"] == "already exist")
		{ window.alert("the employee deatail is already exist in queue") } 
		else
		{this.router.navigate(['/supervisor/request-generate/',employee.employeeCode])}});
			
	}

    getmyemployeehere(id:string):Promise<Employee>{
		console.log(id);
		return this.http.get("http://localhost:56622/api/Employee/"+id)
		.toPromise().then(response => response.json() as Employee )
	}

////////////////////////////////////////////////////////////////////////////////////////////////////////
     ///insert assetlist first
	generatenewrequest(assetdetail:AssetsData[],myrequest:Request):Promise<any> {
	
		console.log(myrequest);
	    return	this.http.post("http://localhost:56622/api/Supervisor/PostRequest",myrequest,
		{
			headers: new Headers({ 'Content-Type': 'application/json' })
		}).toPromise().then(data =>{ 
			if(data["_body"] == "already exist")
			{ window.alert("the request is already exist in queue") } 
			else
			{this.insertmyassetlist(assetdetail)}});
		
	}

	///insert request
	insertmyassetlist(assetdetail:AssetsData[]):Promise<any>{
		console.log(assetdetail);
	    return this.http.post("http://localhost:56622/api/Supervisor/PostAsset",assetdetail,
			{
				headers: new Headers({ 'Content-Type': 'application/json' })
			}).toPromise().then(data =>{ this.router.navigate(['/supervisor'])});
	}




	getAsset()
	{		
		return this.http.get("./assets/data/asset.json")
		.map(response => response.json());
	}
	assetReallocation(newasset:AssetsData) {
		this.http.post("http://localhost:51526/api/values",newasset,
			{
				headers: new Headers({ 'Content-Type': 'application/json' })
			}).subscribe();
	}
////////////////////////////////////////////////////////////////////////////////////////
	reassignAssetReallocation(reassignment:AssetsData){

		return this.http.put('http://localhost:56622/api/Supervisor/PutAssets',reassignment,
				{headers: new Headers({'Content-Type':'application/json'})
			 }).subscribe();
		}
		getRejectAssetDetails(myemployeelist:string[]):Promise<any> {
			return this.http.post('http://localhost:56622/api/Supervisor/GetRejectedAssetList',myemployeelist,
			{headers: new Headers({ 'Content-Type': 'application/json' })}
		).toPromise().then(result => JSON.parse(result["_body"]) as AssetsData[] );


		}///rejected reassignment list




///////////////////////////////////////////////////////////////////////////////////////////

   getrejectemployeesbyhr(){
	   return this.http.get("http://localhost:56622/api/Supervisor/GetRequest").map(result =>result.json());
   }
  removemyrequest(id:string){
		console.log(id);
		this.http
			 .delete("http://localhost:56622/api/Employee/"+id,{headers: new Headers({'Content-Type':'application/json'})}).subscribe();
			 console.log("deleted my request");
	}


////////////////////////////////////////////////////////////////////////////////////////////////
getmyrejectrequestdetailupdate(id:string):Promise<Request>{
	console.log(id);
	return this.http.get("http://localhost:56622/api/Supervisor/GetRequestById/"+id)
				.toPromise().then(data =>data.json());
					
		}

updatemyrejectedlist(updatedlist:Request):Promise<boolean>{
	let id:string=updatedlist.requestId;
	console.log(updatedlist);
	return this.http.put('http://localhost:56622/api/Supervisor/PutRequest/'+id,updatedlist,
	{headers: new Headers({'Content-Type':'application/json'})})
	.toPromise().then(data => this.router.navigate(['/supervisor/rejected-request-list']));
}

////////////////////////////////////////////////////////////////////////////////////////////////
}