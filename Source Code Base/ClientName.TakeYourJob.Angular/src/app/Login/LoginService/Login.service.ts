import { Injectable } from '@angular/core';
import { ApiService } from '../../service/api.service';

@Injectable()

export class LoginService {

  constructor(private service: ApiService) { }

  public login(Email:string,Password:string) {

    return this.service.Login('api/Login/Token?Email='+Email +'&Password='+Password);
  }
 
}
