

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from 'src/app/_models/IProduct';

import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  constructor(public productService : HttpClient) { }

  //https://localhost:7191/api/Product/2
  
  public getProductByID(id:number){

    return this.productService.get(`${environment.APIURL}/Product/${id}`)
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

}
