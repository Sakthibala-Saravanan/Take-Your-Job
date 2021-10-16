import { Component, OnInit } from '@angular/core';
import { InterviewerService } from '../InterviewerService/Interviewer.service';
import { Interviewer } from '../Models/Interviewer';
@Component({
    selector: 'app-GetInterviewer',
    templateUrl: './GetInterviewer.component.html',
})
export class GetInterviewerComponent implements OnInit {
    
    public Interviewers: any[] = [];
    item:any;
    editItem:boolean=false;
    constructor(private service: InterviewerService) { }

    ngOnInit(): void {
        this.service.get().subscribe(res => {
        this.Interviewers = res;
        })
    }
      reloadCurrentPage(){
            window.location.reload();
         }
     edit(interviewer:any){
           this.item=interviewer;
           this.editItem=true;
         }
     delete(id:any){
   this.service.delete(id).subscribe(
res=>{
     this.reloadCurrentPage();
     console.log('scuccess');
     },
err=>{
    console.log('error');
}
)
}
}
