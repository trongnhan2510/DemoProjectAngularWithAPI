import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const AUTH_API = 'https://localhost:44348/api/Logins';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private http: HttpClient) {
   }
  login(username: string, password: string) {
    return this.http.post(AUTH_API, { username, password }, httpOptions);
  }
  getUserByUsername(username:string)
  {
    return this.http.get(AUTH_API+"/"+username);
  }
}
