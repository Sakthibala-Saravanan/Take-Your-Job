import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostApplicantComponent } from './PostApplicant/PostApplicant.component';
import { ApplicantRoutingModule } from './Applicant-routing.module';
import { GetApplicantComponent } from './GetApplicant/GetApplicant.component';
import { ApplicantService } from './ApplicantService/Applicant.service';
import { ApiService } from '../service/api.service';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    GetApplicantComponent,
    PostApplicantComponent
  
  ],
  imports: [
    CommonModule,
    ApplicantRoutingModule,
    FormsModule
  ],
  providers: [ApplicantService, ApiService]
})
export class ApplicantModule { }
