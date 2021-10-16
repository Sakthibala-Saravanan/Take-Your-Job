import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from '../service/api.service';
import { FormsModule } from '@angular/forms';
import {LoginComponent} from './Login.component';
import {LoginRoutingModule} from './Login-routing.module';
import {LoginService} from './LoginService/Login.service';

@NgModule({
  declarations: [
   LoginComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    FormsModule
  ],
  providers: [LoginService, ApiService]
})
export class LoginModule { }
