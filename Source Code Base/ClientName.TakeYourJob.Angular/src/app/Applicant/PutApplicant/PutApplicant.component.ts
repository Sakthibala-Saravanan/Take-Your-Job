import { Component,Input, OnInit } from '@angular/core';
import {ApplicantService } from '../ApplicantService/Applicant.service';
import {Applicant } from '../Models/Applicant';
@Component({
    selector: 'app-PutApplicant',
    templateUrl: './PutApplicant.component.html',
})
export class PutApplicantComponent implements OnInit {
@Input('data') item:any;
 constructor(private service:ApplicantService) { }
   public obj:Applicant = new Applicant();
      ngOnInit(): void {
      this.obj.id=this.item.id;
this.obj.roleId=this.item.roleId;
this.obj.status=this.item.status;
this.obj.mobileNumber=this.item.mobileNumber;
this.obj.name=this.item.name;
this.obj.email=this.item.email;
this.obj.dateOfBirth=this.item.dateOfBirth;
this.obj.gender=this.item.gender;
this.obj.password=this.item.password;
this.obj.confirmPassword=this.item.confirmPassword;
this.obj.city=this.item.city;
this.obj.question=this.item.question;
this.obj.answer=this.item.answer;
this.obj.hscBoard=this.item.hscBoard;
this.obj.hscSpecialization=this.item.hscSpecialization;
this.obj.hscPassingYear=this.item.hscPassingYear;
this.obj.hscMedium=this.item.hscMedium;
this.obj.hscPercentage=this.item.hscPercentage;
this.obj.sslcBoard=this.item.sslcBoard;
this.obj.sslcPassingYear=this.item.sslcPassingYear;
this.obj.sslcMedium=this.item.sslcMedium;
this.obj.sslcPercentage=this.item.sslcPercentage;
this.obj.qualification=this.item.qualification;
this.obj.course=this.item.course;
this.obj.specialization=this.item.specialization;
this.obj.collegeName=this.item.collegeName;
this.obj.collegeType=this.item.collegeType;
this.obj.passingYear=this.item.passingYear;
this.obj.professionalBackground=this.item.professionalBackground;
this.obj.location=this.item.location;
this.obj.jobType=this.item.jobType;
this.obj.employmentType=this.item.employmentType;
this.obj.skills=this.item.skills;
this.obj.experience=this.item.experience;

 }
reloadCurrentPage(){
  window.location.reload();
}
      update()
      {
 this.service.put(this.obj).subscribe(
 res =>
      {
    this.reloadCurrentPage();
    console.log("Success");
      },
 err=>{
        console.log("error");
      });
}
}
