import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Headers, Http } from '@angular/http';
import { AssetsData} from '../../model/asset';
import {Employee} from '../../model/Employee';
import {Request} from '../../model/request';

import 'rxjs/add/operator/map';

@Injectable()
export class GlobalUserService {

	constructor(private http: Http) { }
	
	// here this method will get all the list of the employee list which is associated with the supervisor and having request pending.
	getMyPendingRequest(empid:number):Observable<AssetsData[]> {
		return this.http.get('http://localhost:56622/api/AssetAssignedUser/'+empid)
		                     .map(response => response.json());
  }	
		
	// here this method will get asset id and asset data when called by component, for updating the asset status in database.
  approve(id:number , reassignment:AssetsData){
    return this.http.put('http://localhost:56622/api/AssetAssignedUser/'+id,reassignment,
                         {headers: new Headers({'Content-Type':'application/json'})});                        
	}
	
	// here this method will get asset id and asset data when called by component, for updating the asset status in database. 
  reject(id:number , reassignment:AssetsData){                  
    return this.http.put('http://localhost:56622/api/AssetAssignedUser/'+id,reassignment,
                         {headers: new Headers({'Content-Type':'application/json'})});          
  }
}