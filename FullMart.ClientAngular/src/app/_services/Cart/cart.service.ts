import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CartProducts } from 'src/app/_models/cart-products';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private httpClient:HttpClient ) { }
  getProductsFromCart():Observable<CartProducts[]>
  {
    return this.httpClient.get<CartProducts[]>(`${environment.APIURL}/CartProducts/0f37a869-3c0d-407f-bd8d-5fa476a45593`);
  }
}
