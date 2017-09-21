import { BrowserModule } from '@angular/platform-browser';
import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {NgxPaginationModule} from 'ngx-pagination';   
import { AppRoutingModule }     from './approuting.module';
import {HttpModule} from '@angular/http';
import {CommonModule} from '@angular/common';

import { AppComponent } from './app.component';

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


///my service
import { SupervisorService } from './home-control/supervisor/supervisor.service';
import { CsoService } from './home-control/cso-control/cso.service';
import { HrViewRequestService } from './home-control/humanresource/hr-viewrequest/hr-viewrequest.service';
import { UserControlService} from './home-control/user-control/user-control.service';
import {GlobalUserService} from './home-control/global-userview/globaluser.service';
import { AssetControlService} from './home-control/asset-control/asset-control.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeControlComponent,
    SupervisorComponent,
    EmployeeListComponent,
    RequestGenerateComponent,
    RejectedListComponent,
    ReassignmentListComponent,
    UpdateRejectedListComponent,
    HumanresourceComponent,
    HrViewrequestComponent,
    CsoControlComponent,
    ApprovalListComponent,
    GlobalUserviewComponent,
    UserControlComponent,
    AssetControlComponent,
    RejectedRequestListComponent
  ],
  imports: [
    BrowserModule,
    NgxPaginationModule,
    AppRoutingModule,
    HttpModule,
    FormsModule,
    CommonModule
  ],
  providers: [SupervisorService, CsoService, HrViewRequestService, UserControlService,GlobalUserService,AssetControlService],
  bootstrap: [AppComponent],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
