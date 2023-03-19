import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { APIResponseViewModel } from 'src/app/_models/api-response-view-model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})

export class GenericAPIHandlerService {

  httpOption;

  constructor(private httpClient : HttpClient) { 
    this.httpOption = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        //  Authorization :'my-auth-token'
      }),
    };
  }
  //For Authentication (Access Token in header)
  private setHeaders(key:string, value:string){
    this.httpOption.headers.set(key,value);
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
   
  getAll(APIRoute:string):Observable<APIResponseViewModel>
  {
      return this.httpClient.get<APIResponseViewModel>(`${environment.APIURL}/${APIRoute}`)
      .pipe(
          retry(2),
          catchError(this.handleError))
      
  }





}
