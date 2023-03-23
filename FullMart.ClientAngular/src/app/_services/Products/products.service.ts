


import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { IProduct } from 'src/app/_models/IProduct';
import { IProductAdded } from 'src/app/_models/iproduct-added';

import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  httpOption;
  constructor(public productService : HttpClient) { 
    this.httpOption = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        //  Authorization :'my-auth-token'
      }),
    };
  }

  //https://localhost:7191/api/Product/2
  
  public getProductByID(id:number):Observable<IProduct>{

    return this.productService.get<IProduct>(`${environment.APIURL}/Product/${id}`)
  }


  public getProductByBrandName(brandName:string){
    //https://localhost:7191/api/Product/GetProductByBrandName?name=Nike
  
    return this.productService.get<IProduct[]>(`${environment.APIURL}/Product/GetProductByBrandName?name=${brandName}`)

  }
  //https://localhost:7191/api/Product/GetProductByCategoryId?id=1

  public getProductByCategoryId(id:number){
   
  
    return this.productService.get<IProduct[]>(`${environment.APIURL}/Product/GetProductByCategoryId?id=${id}`)

  }

  //https://localhost:7191/api/Product/GetAllProduct
  public getAllProducts(){
    return this.productService.get<IProduct[]>(`${environment.APIURL}/Product/GetAllProduct`);
  }

  //https://localhost:7191/api/Product/GetProductsByRating?rate=1
  public getProductByRating(rate:number|null){
   
  
    return this.productService.get<IProduct[]>(`${environment.APIURL}/Product/GetProductsByRating?rate=${rate}`)

  }

   //https://localhost:7191/api/Product
   addProduct(newPrd: IProductAdded):Observable<IProductAdded> {
    return this.productService.post<IProductAdded>( `${environment.APIURL}/Product`, JSON.stringify(newPrd), this.httpOption)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  //https://localhost:7191/api/Product/400

  editCategory(prdId:number, product:IProductAdded){
    
    return this.productService.put(`${environment.APIURL}/Product/${prdId}`, JSON.stringify(product), this.httpOption)
  }


   //https://localhost:7191/api/Product/50
   public deleteProduct(prdId:number){
    return this.productService.delete(`${environment.APIURL}/Product/${prdId}`)    }


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

}
