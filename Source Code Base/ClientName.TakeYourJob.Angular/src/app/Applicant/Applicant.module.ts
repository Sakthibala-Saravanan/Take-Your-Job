import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostApplicantComponent } from './PostApplicant/PostApplicant.component';
import { PutApplicantComponent } from './PutApplicant/PutApplicant.component';
import { ApplicantRoutingModule } from './Applicant-routing.module';
import { GetApplicantComponent } from './GetApplicant/GetApplicant.component';
import { ApplicantService } from './ApplicantService/Applicant.service';
import { ApiService } from '../service/api.service';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    GetApplicantComponent,
    PostApplicantComponent,
    PutApplicantComponent
  
  ],
  imports: [
    CommonModule,
    ApplicantRoutingModule,
    FormsModule
  ],
  providers: [ApplicantService, ApiService]
})
export class ApplicantModule { }
