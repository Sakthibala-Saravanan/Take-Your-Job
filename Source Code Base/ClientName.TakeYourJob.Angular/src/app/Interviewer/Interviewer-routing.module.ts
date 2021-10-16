import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PostInterviewerComponent } from './PostInterviewer/PostInterviewer.component';
import { GetInterviewerComponent } from './GetInterviewer/GetInterviewer.component';
import { PutInterviewerComponent } from './PutInterviewer/PutInterviewer.component';

const routes: Routes = [{
path: 'GetInterviewer', component: GetInterviewerComponent
},
{
path: 'PostInterviewer', component: PostInterviewerComponent
},

];
@NgModule({
imports: [RouterModule.forChild(routes)],
exports: [RouterModule]
})
export class InterviewerRoutingModule { }
