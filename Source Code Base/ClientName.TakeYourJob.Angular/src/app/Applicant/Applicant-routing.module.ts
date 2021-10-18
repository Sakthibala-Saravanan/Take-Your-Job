import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PostApplicantComponent } from './PostApplicant/PostApplicant.component';
import { GetApplicantComponent } from './GetApplicant/GetApplicant.component';
import { PutApplicantComponent } from './PutApplicant/PutApplicant.component';
const routes: Routes = [{
path: 'GetApplicant', component: GetApplicantComponent
},
{
path: 'PostApplicant', component: PostApplicantComponent
},
{
path: 'PutApplicant', component: PutApplicantComponent
}
];
@NgModule({
imports: [RouterModule.forChild(routes)],
exports: [RouterModule]
})
export class ApplicantRoutingModule { }
