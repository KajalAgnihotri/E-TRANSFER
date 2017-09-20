import { Component, OnInit } from '@angular/core';
import { GlobalUserService } from "./globaluser.service";
import { AssetsData } from '../asset';

@Component({
  selector: 'app-global-userview',
  templateUrl: './global-userview.component.html',
  styleUrls: ['./global-userview.component.css']
})
export class GlobalUserviewComponent implements OnInit {
mypendingassetrequest:AssetsData[]=[];
dummyid:number = 193503;
  constructor(private globalUser : GlobalUserService) { }

  ngOnInit() {
    this.globalUser.getmypendingrequest(this.dummyid).subscribe(data =>
       {
         this.mypendingassetrequest=data
         console.log(this.mypendingassetrequest);
    } );
  }

  accept(data){

    console.log("data...."+data);
    let id = data.assetId;
    console.log(id);
    data.assetstatus = 1;
      this.globalUser.approve(id,data).then(resp => {
        const index= this.mypendingassetrequest.indexOf(data);
        console.log(index);
        this.mypendingassetrequest.splice(index,1);
      })

    
      
  }
  reject(data){
    let id = data.assetId;
    console.log(id);
    data.assetstatus = 2;
    this.globalUser.reject(id,data).then(resp => {
      const index= this.mypendingassetrequest.indexOf(data);
      console.log(index);
      this.mypendingassetrequest.splice(index,1);
    })

   
  
  }

}
