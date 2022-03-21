import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from '../../services/token-storage.service';
import { LoginService } from 'src/app/services/login.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: any = {
    username: null,
    password: null
  };
  constructor(private loginService: LoginService, private tokenStorage: TokenStorageService) { }
  ngOnInit(): void {
  }
  onSubmit(): void {
    const { username, password } = this.form;
    this.loginService.login(username,password).subscribe((data:any)=>{
        this.tokenStorage.saveToken(data);
        this.loginService.getUserByUsername(username).subscribe((data:any)=>{
          this.tokenStorage.saveUser(data);
        });
        alert('Success');
        window.location.href = "";
    });
  }
}
