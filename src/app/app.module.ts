import { BrowserModule } from '@angular/platform-browser';
import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {NgxPaginationModule} from 'ngx-pagination';   
import { AppRoutingModule }     from './approuting.module';
import {HttpModule} from '@angular/http';
import {CommonModule} from '@angular/common';

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


///my service
import { SupervisorService } from './supervisor/supervisor.service';
import { CsoService } from './cso-control/cso.service';
import { HrViewRequestService } from './hr-viewrequest/hr-viewrequest.service';
import { UserControlService} from './user-control/user-control.service';
import {GlobalUserService} from './global-userview/globaluser.service';
import { AssetControlService} from './asset-control/asset-control.service';


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
