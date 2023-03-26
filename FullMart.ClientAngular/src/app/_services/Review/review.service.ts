import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {IReview} from 'src/app/_models/IReview'

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  httpOption;
  constructor(private httpClient:HttpClient ) { 
    this.httpOption = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        //  Authorization :'my-auth-token'
      }),
    };
  }
  addProductToCart(review:IReview):Observable<any>{
    

    return this.httpClient.post<IReview>(`${environment.APIURL}/Review/CreatReview`,JSON.stringify(review),this.httpOption);
  }

}
