import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse, HttpStatusCode } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, map, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class UserAuthService {

  httpOption;
  isloggedsubject : BehaviorSubject<boolean> ;

  constructor(private userAuthService:HttpClient) {

    this.httpOption = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      //  Authorization :'my-auth-token'
      }),
    };  

    this.isloggedsubject= new BehaviorSubject<boolean>(false);
 }


   //#region Function for handling errors
  //Function for handling errors
  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } 
    else if(error.status === 400){
        console.log("400");
    return throwError( () => new Error('Username or Password is incorrect '))
    } 
    else  {
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

  // https://localhost:7191/api/Auth/Login
  login(userAuth:any){

    return this.userAuthService.post(`${environment.APIURL}/Auth/Login`, JSON.stringify(userAuth), this.httpOption)
            .pipe( 
                    map((res) => 
                    {
                      this.isloggedsubject.next(true)
                      //console.log(res)
                      //Change logged Status
                      return res
                    }),
                   catchError(this.handleError),
                )
            // this.isloggedsubject.next(true)        
  }

  logout(){

    localStorage.removeItem("token");
    localStorage.removeItem("id");
    //Change logged Status
    this.isloggedsubject.next(false);
  }

  get isUserLogged(){

    return (localStorage.getItem("token"))? true : false
  }
  
  getLoggedStatus(): Observable<boolean>{

    return this.isloggedsubject.asObservable();
  }

}
