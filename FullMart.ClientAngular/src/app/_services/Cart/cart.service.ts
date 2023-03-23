import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CartProducts } from 'src/app/_models/cart-products';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { INewCartProduct } from 'src/app/_models/INewCartProduct';
import { ICatProduct } from 'src/app/_models/ICatProduct';
@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private httpClient:HttpClient ) { }
  
  newCartProduct:INewCartProduct|null=null;
  getProductsFromCart(userId:string):Observable<CartProducts[]>
  {
    
    return this.httpClient.get<CartProducts[]>(`${environment.APIURL}/CartProducts/${userId}`);

  }
  addProductToCart(productId:number,userId:string):Observable<any>{
    
    this.newCartProduct=new INewCartProduct(productId,userId);
   // https://localhost:7191/api/CartProducts?userId=f800e43f-bf66-4473-a80f-9a28476fbfd9&productId=3
   console.log(productId);
    return this.httpClient.post(`${environment.APIURL}/CartProducts?userId=${userId}&productId=${productId}`,JSON.stringify(this.newCartProduct));
  }
  //ttps://localhost:7191/api/CartProducts?userId=f800e43f-bf66-4473-a80f-9a28476fbfd9&productId=3
  deleteProductFromCart(productId:number,userId:string){
    return this.httpClient.delete(`${environment.APIURL}/CartProducts?userId=${userId}&productId=${productId}`) ;                    
  }
}
