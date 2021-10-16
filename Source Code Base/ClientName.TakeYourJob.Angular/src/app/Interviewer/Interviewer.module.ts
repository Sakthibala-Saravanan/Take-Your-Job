import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostInterviewerComponent } from './PostInterviewer/PostInterviewer.component';
import { InterviewerRoutingModule } from './Interviewer-routing.module';
import { PutInterviewerComponent } from './PutInterviewer/PutInterviewer.component';
import { GetInterviewerComponent } from './GetInterviewer/GetInterviewer.component';
import { InterviewerService } from './InterviewerService/Interviewer.service';
import { ApiService } from '../service/api.service';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    GetInterviewerComponent,
    PostInterviewerComponent,
    PutInterviewerComponent
  ],
  imports: [
    CommonModule,
    InterviewerRoutingModule,
    FormsModule
  ],
  providers: [InterviewerService, ApiService]
})
export class InterviewerModule { }
