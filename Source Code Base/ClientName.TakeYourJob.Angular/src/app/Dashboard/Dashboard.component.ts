import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-Dashboard',
  templateUrl: './Dashboard.component.html',
 })
export class DashboardComponent implements OnInit {
exports=[TeacherDashboardComponent];
declarations=[TeacherDashboardComponent];
  constructor(private router:Router) { }
rolename:any;
roleNo:number;
  ngOnInit(): void {
       this.rolename=localStorage.getItem(roleName);
       if(this.rolename=='Recruiter')
       {
         this.roleNo=1;
       }
       else(this.rolename=='Applicant')
       {
         this.roleNo=2;
       }
    }
  onLogout()
  {
    localStorage.removeItem('token');
    this.router.navigate(['/Login']);
  }
}
