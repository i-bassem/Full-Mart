import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import {IReview} from 'src/app/_models/IReview'
import { IReviewModified } from 'src/app/_models/IReviewModified';

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
  //https://localhost:7191/api/Review/CreatReview
  addProductToCart(review:IReviewModified):Observable<any>{
    
    return this.httpClient.post<IReviewModified>(`${environment.APIURL}/Review/CreatReview`,JSON.stringify(review),this.httpOption);
  }

  //https://localhost:7191/api/Review/GetReviewByProductId?productId=1
  getAllReviews(productID:number):Observable<IReview>{
    return this.httpClient.get<IReview>(`${environment.APIURL}/Review/GetReviewByProductId?productId=${productID}`)
  }

}


//post
// Comment
// NumberOfStar
// ProductId
// AppUserId