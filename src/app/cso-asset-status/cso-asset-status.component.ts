import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cso-asset-status',
  templateUrl: './cso-asset-status.component.html',
  styleUrls: ['./cso-asset-status.component.css']
})
export class CsoAssetStatusComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  List:any[]=[
    {AssetCode:"34673",CAP_Date:"10-12-2016",Description:"Laptop",CompanyCode:"876",Location:"Delhi",Quantity:"2",ReassignTo:"6500384",Status:"clear"},
    {AssetCode:"34673",CAP_Date:"10-12-2016",Description:"Laptop",CompanyCode:"876",Location:"Delhi",Quantity:"2",ReassignTo:"6500384",Status:"clear"},
    {AssetCode:"34673",CAP_Date:"10-12-2016",Description:"Laptop",CompanyCode:"876",Location:"Delhi",Quantity:"2",ReassignTo:"6500384",Status:"clear"}
  ];
}
