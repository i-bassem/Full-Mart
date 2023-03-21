import { Component } from '@angular/core';
import { LoginService } from 'src/app/_services/Login/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private loginService:LoginService){

  }
  Email:string="";
  Password:string="";
  loginAction():void{
    this.loginService.Login(this.Email,this.Password);
  }

}
