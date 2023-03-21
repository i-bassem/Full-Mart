import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class UserAuthService {

  httpOption;
  constructor(private userAuthService:HttpClient) {
    this.httpOption = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      //  Authorization :'my-auth-token'
      }),
    }; 
    
    
 }


  // https://localhost:7191/api/Auth/Login
  login(userAuth:any){
   
   return this.userAuthService.post(`${environment.APIURL}/Auth/Login`, JSON.stringify(userAuth), this.httpOption)
  //  .pipe(
  //   map((res:Iresponse)=>{return res.token}   ))

   
// pipe(
//     tap((receivedData: Foo) => console.log(receivedData)),
//     map((receivedData: Foo) => {
//         return new RegularUser(
//             receivedData.uid, 
//             receivedData.first_name, 
//             receivedData.last_name, 
//             receivedData.token);
//     })
// );
  }


}
