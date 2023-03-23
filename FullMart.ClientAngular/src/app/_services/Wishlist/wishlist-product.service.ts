import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { IWishlist } from 'src/app/_models/iwishlist';
import { Iwishlistproducts } from 'src/app/_models/iwishlistproducts';

@Injectable({
  providedIn: 'root'
})
export class WishlistProductService {

GetProductByUserID (userID : string):Observable<Iwishlistproducts[]>{
  return this.http.get<Iwishlistproducts[]>(`${environment.APIURL}/WishList/GetProductByUserID?UserId=${userID}`);
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


//https://localhost:7191/api/WishList/DeleteByProductId?UserId=1&ProductId=1

  constructor(public http:HttpClient) { }
}
