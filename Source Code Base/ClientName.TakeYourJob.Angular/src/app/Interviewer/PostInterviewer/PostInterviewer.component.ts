import { Component, OnInit } from '@angular/core';
import { InterviewerService } from '../InterviewerService/Interviewer.service';
import { Interviewer } from '../Models/Interviewer';
import { CompanyType } from '../Models/CompanyType';
@Component({
    selector: 'app-PostInterviewer',
    templateUrl: './PostInterviewer.component.html',
})
export class PostInterviewerComponent implements OnInit {

 constructor(private service: InterviewerService) { }
     public interviewer:Interviewer = new Interviewer();
     types:CompanyType[];
     ngOnInit(): void {
          this.types=[
           {"typeName":"Service based Company"},
           {"typeName":"Product based Company"}
        ]
      }
      onSubmit()
      {
 this.service.post(this.interviewer).subscribe(
 res =>
      {
        console.log("Success");
      },
 err=>{
        console.log("error");
      });
}
}
