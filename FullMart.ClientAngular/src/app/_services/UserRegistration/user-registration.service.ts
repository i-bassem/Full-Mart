import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { IUser } from 'src/app/_models/IUser';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class UserRegistrationService {

  httpOption;
  
  constructor(private userRegisterService : HttpClient) {

    this.httpOption = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        //  Authorization :'my-auth-token'
      }),
    };
   }

   //#region Function for handling errors
  //Function for handling errors
  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `,
        error.error
      );
    }
    // Return an observable with a user-facing error message.
    return throwError(
      () => new Error('Something bad happened; please try again later.')
    );
  }
  //#endregion




  //https://localhost:7191/api/Auth/Register
  registerUser(newUser:IUser):Observable<IUser>{
    return this.userRegisterService.post<IUser>(`${environment.APIURL}/Auth/Register`, JSON.stringify(newUser), this.httpOption)
      .pipe(
         catchError( this.handleError)
        )
  }







  
}
