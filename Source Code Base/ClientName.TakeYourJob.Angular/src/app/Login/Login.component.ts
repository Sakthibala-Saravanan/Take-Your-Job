import { Component, OnInit } from '@angular/core';
import { LoginService } from './LoginService/Login.service';

@Component({
    selector: 'app-Login',
    templateUrl: './Login.component.html',
    styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {
   
    constructor(private service: LoginService) { }
     details:any;
     formModel = {
        Email: '',
        Password: ''
  }

    ngOnInit(): void {
        localStorage.removeItem('token');
     }
  onSubmit(){
this.service.login(this.formModel.Email,this.formModel.Password).subscribe(
(res:any)=>{
  this.details=res;
  localStorage.setItem('token',this.details.token);
  localStorage.setItem('userId',JSON.stringify(this.details.userId));
  
  console.log(this.details);
   },
err=>{
  if(err.status==400)
  {
    console.log('Incorrect UserName or Password','Login Failed');
  }
  else{
    console.log(err);
  }
}
);
}
}
