import { Component, OnInit } from '@angular/core';
import { ApplicantService } from '../ApplicantService/Applicant.service';

@Component({
    selector: 'app-GetApplicant',
    templateUrl: './GetApplicant.component.html',
})
export class GetApplicantComponent implements OnInit {
    
    public Applicants: any[] = [];
    applicant:any;
    constructor(private service: ApplicantService) { }

    ngOnInit(): void {
        this.service.get().subscribe(res => {
        this.Applicants = res;
        console.log(res);

        })
    }
    
}
