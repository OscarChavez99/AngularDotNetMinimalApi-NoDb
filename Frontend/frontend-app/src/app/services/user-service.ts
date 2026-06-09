import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../interfaces/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  
  constructor (private httpClient: HttpClient) {}

  apiUrl: string = "https";
  apiName: string = "users";

  getUsers(): Observable<User[]>{
    return this.httpClient.get<User[]>(`${this.apiUrl}${this.apiName}`);
  }

  addUser(user: User): Observable<User> {
    return this.httpClient.post<User>(`${this.apiUrl}${this.apiName}`, user);
  }
}
