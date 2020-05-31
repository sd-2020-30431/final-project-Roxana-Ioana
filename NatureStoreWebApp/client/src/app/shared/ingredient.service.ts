import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {

  private baseUrl = 'https://localhost:44369/api/Ingredients';

  constructor(private http: HttpClient) { }

  addIngredient(product:Object):Observable<Object>{
    return this.http.post(`${this.baseUrl}`, product);
  }

  deleteIngredient(idProduct:number):Observable<any>{
    return this.http.delete(`${this.baseUrl}/${idProduct}`);
  }

  getAllIngredients():Observable<any>{
    return this.http.get(`${this.baseUrl}`);
  }  
}
