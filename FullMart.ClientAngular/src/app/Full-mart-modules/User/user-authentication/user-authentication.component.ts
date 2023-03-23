import { Component } from '@angular/core';
import { UserAuthService } from 'src/app/_services/UserAuthentication/UserAuthService';

@Component({
  selector: 'app-user-authentication',
  templateUrl: './user-authentication.component.html',
  styleUrls: ['./user-authentication.component.css']
})
export class UserAuthenticationComponent {

 email="";
 password="";
 userAuth:any;

 constructor( private userAuthenticationService: UserAuthService ){ 
 }

  login(){
   
   this.userAuth= (
    {
    email :this.email,
    password : this.password
    })

   this.userAuthenticationService.login(this.userAuth).subscribe( (response:any)=>
     (
     localStorage.setItem("token", response?.token),
     localStorage.setItem("id", response?.id),
     console.log(response)
     

     
     )
    );
  }
   


  
}

//response 
// email: "abc@abc.com"
// expiresOn:"2023-03-21T12:55:29Z"
// isAuthenticated: true
// message: null
// refreshToken: "P7GOUOAhaNzxbbl7yVTSbi671A4AVcAQlTJg05g3T30="
// refreshTokenExpiration: "2023-03-31T11:05:47.252155"
// roles: ['User']
// token:"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI3YW1hZGEiLCJqdGkiOiJmNjQyYTQ1Ni0xZWJhLTQ1MWYtYjdiYy0xNDg4NDlmY2ExMjYiLCJlbWFpbCI6ImFiY0BhYmMuY29tIiwidWlkIjoiMDMxOThjNmQtZWQ0ZC00MTlmLTkwNTAtNmFhNmE2YmJhNjUzIiwicm9sZXMiOiJVc2VyIiwiZXhwIjoxNjc5NDAzMzI5LCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VyIn0.ZYAzlBxOCIWX8aOYlnDRb3pf5otdCr-NX913YP0t3sw"
// username:"7amada"

//refreshToken(cookies)
// P7GOUOAhaNzxbbl7yVTSbi671A4AVcAQlTJg05g3T30%3D
//UserID
//03198c6d-ed4d-419f-9050-6aa6a6bba653

//if not found 400
// Email or Password Is Incorrect