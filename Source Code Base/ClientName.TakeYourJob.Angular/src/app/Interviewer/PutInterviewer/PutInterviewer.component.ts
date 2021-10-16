import { Component,Input, OnInit } from '@angular/core';
import { InterviewerService } from '../InterviewerService/Interviewer.service';
import { CompanyType } from '../Models/CompanyType';
import { Interviewer } from '../Models/Interviewer';
@Component({
    selector: 'app-PutInterviewer',
    templateUrl: './PutInterviewer.component.html',
})
export class PutInterviewerComponent implements OnInit {
@Input('data') item:any;
 constructor(private service: InterviewerService) { }
   public obj:Interviewer = new Interviewer();
      ngOnInit(): void {
      this.obj.id=this.item.id;
this.obj.roleId=this.item.roleId;
this.obj.status=this.item.status;
this.obj.name=this.item.name;
this.obj.email=this.item.email;
this.obj.password=this.item.password;
this.obj.confirmPassword=this.item.confirmPassword;
      this.obj.companyName=this.item.companyName;
      this.obj.mobileNumber=this.item.mobileNumber;
      this.obj.companyAddress=this.item.companyAddress;
      this.obj.companyType=this.item.companyType;
      this.obj.pincode=this.item.pincode;
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
