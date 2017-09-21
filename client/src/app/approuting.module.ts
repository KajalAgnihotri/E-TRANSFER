import { NgModule } from '@angular/core';
import { RouterModule,Routes }   from '@angular/router';

import { HomeControlComponent } from './home-control/home-control.component';
import { SupervisorComponent } from './home-control/supervisor/supervisor.component';
import { EmployeeListComponent } from './home-control/supervisor/employee-list/employee-list.component';
import { RejectedListComponent } from './home-control/supervisor/rejected-list/rejected-list.component';
import { RequestGenerateComponent} from './home-control/supervisor/request-generate/request-generate.component';
import { ReassignmentListComponent} from './home-control/supervisor/reassignment-list/reassignment-list.component';
import { RejectedRequestListComponent} from './home-control/supervisor/rejected-request-list/rejected-request-list.component';
import { UpdateRejectedListComponent } from './home-control/supervisor/update-rejected-list/update-rejected-list.component';

import{ HumanresourceComponent} from './home-control/humanresource/humanresource.component';
import{ HrViewrequestComponent} from './home-control/humanresource/hr-viewrequest/hr-viewrequest.component';

import{ CsoControlComponent} from './home-control/cso-control/cso-control.component';
import{ ApprovalListComponent} from './home-control/cso-control/approval-list/approval-list.component';

import{ GlobalUserviewComponent } from './home-control/global-userview/global-userview.component';

import{UserControlComponent} from './home-control/user-control/user-control.component';

import{AssetControlComponent}from './home-control/asset-control/asset-control.component';


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
