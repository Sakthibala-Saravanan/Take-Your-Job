import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InterviewerModule } from './Interviewer/Interviewer.module';
import { ApplicantModule } from './Applicant/Applicant.module';
import {LoginModule} from './Login/Login.module';
const routes: Routes = [
    {
        path: '',
        redirectTo: 'Login',
        pathMatch: 'full'
    },
    {
        path: 'Login',
        loadChildren: () => LoginModule
    },
 {
        path: 'Interviewer',
        loadChildren: () => InterviewerModule
    },
 {
        path: 'Applicant',
        loadChildren: () => ApplicantModule
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
