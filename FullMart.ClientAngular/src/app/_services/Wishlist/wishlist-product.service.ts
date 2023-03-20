import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { IWishlist } from 'src/app/_models/iwishlist';

@Injectable({
  providedIn: 'root'
})
export class WishlistProductService {

// baseurl = "https://localhost:7191/api/WishList/";

GetProductByUserID (userID : string):Observable<IWishlist[]>{
  return this.http.get<IWishlist[]>(`${environment.APIURL}/WishList/GetProductByUserID?id=${userID}`);
}


getProductsCount(userID : string):Observable<number>{
  return this.http.get<number>(`${environment.APIURL}/WishList/GetProductCount?UserId=${userID}`);
}

// AddProductToCart(product : product){
//   return this.http.post(`${environment.APIURL}
//   AddProductToWishlist?UserId=${userID}&ProductId=${product.Id}`,product);
// }

DeleteProductById(userID : string , productId : number){
  return this.http.delete(`${environment.APIURL}/WishList/DeleteByProductId?UserId=${userID}&ProductId=${productId}`);
}
  constructor(public http:HttpClient) { }
}
