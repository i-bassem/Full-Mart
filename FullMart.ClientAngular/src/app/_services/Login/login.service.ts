import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { ILogin } from 'src/app/_models/ILogin';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private httpClient:HttpClient ) { }

 
  Login(email:string,password:string):Observable<ILogin>
  {
    
    return this.httpClient.post<ILogin>(`${environment.APIURL}/Auth/Login`,new ILogin(email,password));
  }

}
