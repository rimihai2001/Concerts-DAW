import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BandsService {
  public url = 'https://localhost:44314/api/bands';
  constructor(public http: HttpClient) {}

  public getBands(): Observable<any> {
    return this.http.get(`${this.url}/Get-select`);
  }

  // public getStudentById(id): Observable<Band> {
  //   return this.http.get<any>(`${this.url}/byId/${id}`);
  // }
}
