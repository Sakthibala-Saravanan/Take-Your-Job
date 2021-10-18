import { Injectable } from '@angular/core';
import { ApiService } from '../../service/api.service';

@Injectable()

export class ApplicantService {

  constructor(private service: ApiService) { }

  public get() {
    return this.service.get('api/Applicant');
  }
  public post(body:any) {
    return this.service.post('api/Applicant/PostApplicant',body);
  }
  public put(body: any) {
    return this.service.put('api/Applicant', body);
  }
 public delete(id:string) {
    return this.service.delete('api/Applicant/'+id);
  }
}
