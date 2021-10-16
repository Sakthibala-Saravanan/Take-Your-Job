import { Injectable } from '@angular/core';
import { ApiService } from '../../service/api.service';

@Injectable()

export class InterviewerService {

  constructor(private service: ApiService) { }

  public get() {
    return this.service.get('api/Interviewer');
  }
  public post(body:any) {
    return this.service.post('api/Interviewer/PostInterviewer',body);
  }
  public put(body: any) {
    return this.service.put('api/Interviewer', body);
  }
  public delete(id:string) {
    return this.service.delete('api/Interviewer/'+id);
  }
}
