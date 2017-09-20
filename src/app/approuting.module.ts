import { NgModule } from '@angular/core';
import { RouterModule,Routes }   from '@angular/router';


import { AppComponent } from './app.component';
import { HomeControlComponent } from './home-control/home-control.component';
import { SupervisorComponent } from './supervisor/supervisor.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { RejectedListComponent } from './rejected-list/rejected-list.component';
import { RequestGenerateComponent} from './request-generate/request-generate.component';
import { ReassignmentListComponent} from './reassignment-list/reassignment-list.component';
import { RejectedRequestListComponent} from './rejected-request-list/rejected-request-list.component';
import { UpdateRejectedListComponent } from './update-rejected-list/update-rejected-list.component';

import{ HumanresourceComponent} from './humanresource/humanresource.component';
import{ HrViewrequestComponent} from './hr-viewrequest/hr-viewrequest.component';

import{ CsoControlComponent} from './cso-control/cso-control.component';
import{ ApprovalListComponent} from './approval-list/approval-list.component';

import{ GlobalUserviewComponent } from './global-userview/global-userview.component';

import{UserControlComponent} from './user-control/user-control.component';

import{AssetControlComponent}from './asset-control/asset-control.component';


const routes: Routes = [	{path:'',redirectTo:'home-control',pathMatch:'full'},
                {path:'home-control',component:HomeControlComponent},
                {path:'supervisor',component:SupervisorComponent,
                  children:[
                    {path:'',redirectTo:'employee-list',pathMatch:'full'},
                    {path:'employee-list',component:EmployeeListComponent},
                    {path:'rejected-request-list',component:RejectedRequestListComponent},
                    {path:'rejected-list',component:RejectedListComponent},
                    {path:'update-rejected-list/:id',component:UpdateRejectedListComponent},
                    {path:'request-generate/:id',component:RequestGenerateComponent,
                  children:[
                    {path:'reassignment-list',component:ReassignmentListComponent}
                    ]}]},
                {path:'humanresource',component:HumanresourceComponent,
                    children:[
                      {path:'hr-viewrequest',component:HrViewrequestComponent}
                    ]},
                {path:'cso-control',component:CsoControlComponent,
                    children:[
                      {path:'approval-list',component:ApprovalListComponent}
                    ]},
                {path:'global-user',component:GlobalUserviewComponent},
                {path:'user-control',component:UserControlComponent},
                {path:'asset-control',component:AssetControlComponent}
                

];
@NgModule({
 
  imports: [ RouterModule.forRoot(routes)],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
