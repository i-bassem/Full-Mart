

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

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


}
