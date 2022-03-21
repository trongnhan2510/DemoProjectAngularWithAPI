import { Component } from '@angular/core';
import { TokenStorageService } from './services/token-storage.service';
import { User } from './Models/User';
import { Role } from './Models/Role';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isLoggedIn = false;
  username!: string;
  user!:User;
  role:any;
  constructor(private tokenStorageService: TokenStorageService) { }
  ngOnInit(): void {
    this.isLoggedIn = !!this.tokenStorageService.getToken();
    this.user = this.tokenStorageService.getUser();
    this.username = this.user.username;
    this.role = this.user.role;

  }
  get isAdmin() {
    return this.user && this.user.role === Role.Admin;
}
  logout(): void {
    if (confirm('Bạn có muốn đăng xuất không?')) {
      this.tokenStorageService.signOut();
      window.location.href ="/login";
    }
  }
}
