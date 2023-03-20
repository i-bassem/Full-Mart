import { Component, EventEmitter, OnChanges, Output, SimpleChanges } from '@angular/core';
import { IWishlist } from 'src/app/_models/iwishlist';
import { WishlistProductService } from 'src/app/_services/Wishlist/wishlist-product.service';


@Component({
  selector: 'app-wishlistproducts',
  templateUrl: './wishlistproducts.component.html',
  styleUrls: ['./wishlistproducts.component.css']
})
export class WishlistproductsComponent implements OnChanges {

 @Output() TotalProductsCount :EventEmitter<number>;
 productCount :number = 5;

constructor(public wishlistservice : WishlistProductService){
  this.TotalProductsCount = new EventEmitter<number>();

}
  ngOnChanges(): void {

  }

products! : IWishlist[];
getproduct(userID : string){
  this.wishlistservice.GetProductByUserID(userID).subscribe(p => {
    this.products = p;
  }, er => alert(er.message))
}

getProductsCount(userID : string){
this.wishlistservice.getProductsCount(userID).subscribe(c => {
  this.productCount = c ;
})
this.TotalProductsCount.emit(this.productCount);
}




}
