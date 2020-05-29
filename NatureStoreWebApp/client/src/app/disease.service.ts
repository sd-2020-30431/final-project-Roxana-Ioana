import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DiseaseService {

  private baseUrl = 'https://localhost:44399/api/Diseases';

  constructor(private http: HttpClient) { }

  addDisease(product:Object):Observable<Object>{
    return this.http.post(`${this.baseUrl}`, product);
  }

  deleteDisease(idProduct:number):Observable<any>{
    return this.http.delete(`${this.baseUrl}/${idProduct}`);
  }

  getAllDiseases():Observable<any>{
    return this.http.get(`${this.baseUrl}`);
  }  
}
