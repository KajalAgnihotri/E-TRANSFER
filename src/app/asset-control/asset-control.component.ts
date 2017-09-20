import { Component, OnInit } from '@angular/core';
import { AssetsData} from '../asset';
import { AssetControlService } from './asset-control.service';

@Component({
  selector: 'app-asset-control',
  templateUrl: './asset-control.component.html',
  styleUrls: ['./asset-control.component.css']
})
export class AssetControlComponent implements OnInit {

  constructor(private assetservice:AssetControlService) { }
  List:AssetsData[];

  ngOnInit() {
    console.log("calllllleddddddd...");
   this.assetservice.GetAssetList()
       .then(assetList => { this.List=assetList;
      console.log(this.List)})
  }
}




