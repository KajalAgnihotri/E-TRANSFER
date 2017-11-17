import { Component, OnInit } from '@angular/core';
import { GlobalUserService } from "./globaluser.service";
import { AssetsData } from '../../model/asset';

@Component({
  selector: 'app-global-userview',
  templateUrl: './global-userview.component.html',
  styleUrls: ['./global-userview.component.css']
})

export class GlobalUserviewComponent implements OnInit {
  myPendingAssetRequest:AssetsData[]=[];
  dummyId:number = 193503;

  constructor(private globalUser : GlobalUserService) { }

  //On loading of component,this method will automatically run which gets all the pending requests from the service.
  ngOnInit() {
    this.globalUser.getMyPendingRequest(this.dummyId).subscribe(data => {
      this.myPendingAssetRequest=data
    });
  }

  //here this method will get asset id and asset data from html form, for updating the asset status in database and removing the row from html page.
  accept(data) {
    let id = data.assetId;
    data.assetStatus = 1;

    this.globalUser.approve(id,data).toPromise().then(response => response.json()).then(resp => {
      const index= this.myPendingAssetRequest.indexOf(data);
      this.myPendingAssetRequest.splice(index,1);
    })      
  }

  //here this method will get asset id and asset data from html form, for updating the asset status in database and removing the row from html page.
  reject(data) {
    let id = data.assetId;
    data.assetStatus = 2;

    this.globalUser.reject(id,data).toPromise().then(response => response.json()).then(resp => {
      const index= this.myPendingAssetRequest.indexOf(data);
      this.myPendingAssetRequest.splice(index,1);
    })
  }
}
