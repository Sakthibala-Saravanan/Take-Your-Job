import { Component, OnInit } from '@angular/core';
import { ApplicantService } from '../ApplicantService/Applicant.service';
import { Applicant } from '../Models/Applicant';
@Component({
    selector: 'app-PostApplicant',
    templateUrl: './PostApplicant.component.html',
})
export class PostApplicantComponent implements OnInit {

 constructor(private service: ApplicantService) { }
     public applicant:Applicant = new Applicant();
    
     ngOnInit(): void {
        
      }
      onSubmit()
      {
 this.service.post(this.applicant).subscribe(
 res =>
      {
        console.log("Success");
      },
 err=>{
        console.log("error");
      });
}
}
