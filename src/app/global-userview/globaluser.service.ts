import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Headers, Http } from '@angular/http';
import { AssetsData} from '../asset';
import {Employee} from '../Employee';
import {Request} from '../request';

import 'rxjs/add/operator/map';

@Injectable()
export class GlobalUserService {
	constructor(private http: Http) { }

	getmypendingrequest(empid:number):Observable<AssetsData[]>{
		// here this method will get all the list of the employee list which is associated with the supervisor
		return this.http.get('http://localhost:56622/api/AssetAssignedUser/'+empid)
		.map(response => response.json())
    }	
    
    approve(id:number , reassignment:AssetsData):Promise<any>{
        
                return this.http.put('http://localhost:56622/api/AssetAssignedUser/'+id,reassignment,
                        {headers: new Headers({'Content-Type':'application/json'})
                     }).toPromise();
                }

    reject(id:number , reassignment:AssetsData):Promise<any>{
                    
        return this.http.put('http://localhost:56622/api/AssetAssignedUser/'+id,reassignment,
             {headers: new Headers({'Content-Type':'application/json'})
             }).toPromise();
     }
}