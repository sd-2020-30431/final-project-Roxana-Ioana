import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Command } from '../model/command';

@Injectable({
  providedIn: 'root'
})
export class CommandService {

  private baseUrl = 'https://localhost:44369/api/Commands';

  constructor(private http: HttpClient) { }

  addCommand(command:Object):Observable<Object>{
    return this.http.post(`${this.baseUrl}`, command);
  }

  setTotalPrice(command:Command):Observable<Object>{
    return this.http.put(`${this.baseUrl}/${command.id_command}`, command);
  }
}
