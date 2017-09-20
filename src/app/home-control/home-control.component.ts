import { Component, OnInit } from '@angular/core';
import {RouterModule,Router} from '@angular/router';

@Component({
  selector: 'app-home-control',
  templateUrl: './home-control.component.html',
  styleUrls: ['./home-control.component.css']
})
export class HomeControlComponent {

  constructor(private route:Router) { }


  Validation(email,password){
    
            if(email=="supervisor@123" && password=="supervisor")
                { 
                    console.log("supervisorcalled");
                    this.route.navigate(['/supervisor']);    
                }
    
            else if(email=="hr@123" && password=="hr")
                {
                    this.route.navigate(['/humanresource'])
                }  
            else if(email=="user@123" && password=="user")
                {
                    this.route.navigate(['/user-control'])
                } 
            else if(email=="cso@123" && password=="cso")
                {
                    this.route.navigate(['/cso-control'])
                } 
            else if(email=="asset@123" && password=="asset")
                {
                    this.route.navigate(['/asset-control'])
                } 
                    
        }
}
