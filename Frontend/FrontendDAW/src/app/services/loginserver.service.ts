import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginserverService {
  public url="https://localhost:44334/api/Auth"
  constructor(private http:HttpClient) { 
  }
  public login (utilizator):Observable<any>{
    return this.http.post(`${this.url}/Login`,utilizator);
  }
  public register (utilizator):Observable<any>{
    return this.http.post(`${this.url}/Register`,utilizator);
  }
}