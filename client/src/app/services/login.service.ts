import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../Models/User';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

const AUTH_API = 'https://localhost:44348/api/Logins';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root',
})
export class LoginService{
  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;

  constructor(
      private http: HttpClient
  ) {
    this.userSubject = new BehaviorSubject<any>(localStorage.getItem('auth-token'));
      this.user = this.userSubject.asObservable();
  }

  public get userValue(): User {
      return this.userSubject.value;
  }
  login(username: string, password: string) {
    return this.http.post(AUTH_API, { username, password }).pipe(map((user:any) => {
      // store user details and jwt token in local storage to keep user logged in between page refreshes
      localStorage.setItem('auth-token', JSON.stringify(user));
      this.userSubject.next(user);
      return user;
  }));
  }
  getUserByUsername(username:string)
  {
    return this.http.get(AUTH_API+"/"+username);
  }
}
