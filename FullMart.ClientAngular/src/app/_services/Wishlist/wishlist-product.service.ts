import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { IWishlist } from 'src/app/_models/iwishlist';
import { Iwishlistproducts } from 'src/app/_models/iwishlistproducts';
import { InewWishlistProduct } from 'src/app/_models/inew-wishlist-product';

@Injectable({
  providedIn: 'root'
})
export class WishlistProductService {

  newWishlistprd! : InewWishlistProduct;
GetProductByUserID (userID : string):Observable<Iwishlistproducts[]>{
  return this.http.get<Iwishlistproducts[]>(`${environment.APIURL}/WishList/GetProductByUserID?UserId=${userID}`);
}


getProductsCount(userID : string):Observable<number>{
  return this.http.get<number>(`${environment.APIURL}/WishList/GetProductCount?UserId=${userID}`);
}

AddProductToWishlist(productId : number , userID : string) : Observable<any>{
this.newWishlistprd = {productID :productId , userId:userID }
console.log(this.newWishlistprd.productID)
  return this.http.post(`${environment.APIURL}/WishList/AddProductToWishlist?UserId=${userID}&ProductId=${productId}`,JSON.stringify(this.newWishlistprd));
}
//https://localhost:7191/api/WishList/AddProductToWishlist?UserId=1&ProductId=1

DeleteProductById(userID : string , productId : number){
  return this.http.delete(`${environment.APIURL}/WishList/DeleteByProductId?UserId=${userID}&ProductId=${productId}`);
}


//https://localhost:7191/api/WishList/DeleteByProductId?UserId=1&ProductId=1

  constructor(public http:HttpClient) { }
}
