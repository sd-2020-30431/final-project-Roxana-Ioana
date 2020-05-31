import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubcommandService {

  private baseUrl = 'https://localhost:44369/api/Subcommands';

  constructor(private http: HttpClient) { }

  addSubcommand(subcommand:Object):Observable<Object>{
    return this.http.post(`${this.baseUrl}`, subcommand);
  }

  getAllSubcommands(idCommand: number):Observable<any>{
    return this.http.get(`${this.baseUrl}/Command/${idCommand}`);
  }
}
