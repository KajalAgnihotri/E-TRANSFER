import { Component, OnInit } from '@angular/core';
import { AssetsData} from '../../model/asset';
import { AssetControlService } from './asset-control.service';

@Component({
  selector: 'app-asset-control',
  templateUrl: './asset-control.component.html',
  styleUrls: ['./asset-control.component.css']
})
export class AssetControlComponent implements OnInit {

  constructor(private assetservice:AssetControlService) { } //instance of assetservice
  List:AssetsData[]; //array for storing asset data

  /*excutes at the time of component loading*/
  ngOnInit() {
    this.assetservice.GetAssetList()  //calls the service method to return assets list
   .toPromise().then(response => response.json()) //convert the observable returned by service to promise
       .then(assetList => { this.List=assetList;}) // put the value returned into list
  }
}




