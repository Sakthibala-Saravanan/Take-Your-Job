import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    private apiURL = "http://localhost:53184/";
    constructor(private http: HttpClient) { }

    public Login(relativeURL: string): Observable<any> {
        //let headers = this.initializeHeader();
        //let options = { headers: headers };
        return this.http.get(this.apiURL + relativeURL,{responseType: 'text'});
    }
   public get(relativeURL: string): Observable<any> {
        //let headers = this.initializeHeader();
        //let options = { headers: headers };
        return this.http.get(this.apiURL + relativeURL);
    }
    public post(relativeURL: string, body: any): Observable<any> {
        //let headers = this.initializeHeader();
        //let options = { headers: headers };
        return this.http.post(this.apiURL + relativeURL, body);
    }
    public put(relativeURL: string, body: any): Observable<any> {
        //let headers = this.initializeHeader();
        //let options = { headers: headers };
        return this.http.put(this.apiURL + relativeURL, body);
    }
  public delete(relativeURL: string): Observable<any> {
        //let headers = this.initializeHeader();
        //let options = { headers: headers };
        return this.http.delete(this.apiURL + relativeURL);
    }
}
