import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate, CanActivateChild } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthGuardService{

  constructor(private router: Router) { }
}