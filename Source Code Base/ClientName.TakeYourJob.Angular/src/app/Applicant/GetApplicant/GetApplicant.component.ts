import { Component, OnInit } from '@angular/core';
import { ApplicantService } from '../ApplicantService/Applicant.service';

@Component({
    selector: 'app-GetApplicant',
    templateUrl: './GetApplicant.component.html',
})
export class GetApplicantComponent implements OnInit {
    
    public Applicants: any[] = [];
    item:any;
    editItem:boolean=false;
    
    constructor(private service: ApplicantService) { }

    ngOnInit(): void {
        this.service.get().subscribe(res => {
        this.Applicants = res;
        console.log(res);

        })
    }
     reloadCurrentPage(){
            window.location.reload();
         }
     edit(applicant:any){
           this.item=applicant;
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
