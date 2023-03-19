import { IProduct } from './../../_models/iproduct';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private httpClient : HttpClient) { }


//https://localhost:7191/api/Product/GetAllProduct
  getAllProduct():Observable<IProduct[]>
 {
   return this.httpClient.get<IProduct[]>(`${environment.APIURL}/Product/GetAllProduct`)
 }
getProductByID(prdId:number):Observable<IProduct>
{

  return this.httpClient.get<IProduct>(`${environment.APIURL}/Product/${prdId}`)
}
public getImageUrl(filename: string) {
  return `https://localhost:7191/api/Image/${filename}`;
}
}
