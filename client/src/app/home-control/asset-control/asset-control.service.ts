import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { AssetsData } from '../../model/asset';


@Injectable()
export class AssetControlService {
    constructor(private http: Http) { }

    //To Get The List Of All The Assets from web api.
    GetAssetList() {
        return this.http.get("http://localhost:56622/api/Asset").map(response=>response.json());
    }
}
