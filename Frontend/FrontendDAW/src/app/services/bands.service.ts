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

  public getBandById(id): Observable<any> {
    return this.http.get<any>(`${this.url}/Get/${id}`);
  }


  public deleteBand(id): Observable<any> {
    
    return this.http.delete<any>(`${this.url}/${id}` );
  }

  public addBand(band): Observable<any>{
    return this.http.post(`${this.url}/AddBand`, band);
  }

  public editband(band): Observable<any>{
    return this.http.put(this.url, band);
  }
}
