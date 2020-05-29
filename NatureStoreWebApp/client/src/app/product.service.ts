import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private baseUrl = 'https://localhost:44399/api/Products';

  constructor(private http: HttpClient) { }

  addProduct(product:Object):Observable<Object>{
    return this.http.post(`${this.baseUrl}`, product);
  }

  deleteProduct(idProduct:number):Observable<any>{
    return this.http.delete(`${this.baseUrl}/${idProduct}`);
  }

  getAllProducts():Observable<any>{
    return this.http.get(`${this.baseUrl}`);
  }
}
















