import { Component, EventEmitter, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { IProduct } from 'src/app/_models/IProduct';
import { IWishlist } from 'src/app/_models/iwishlist';
import { Iwishlistproducts } from 'src/app/_models/iwishlistproducts';
import { WishlistProductService } from 'src/app/_services/Wishlist/wishlist-product.service';
import { environment } from 'src/environments/environment.development';


@Component({
  selector: 'app-wishlistproducts',
  templateUrl: './wishlistproducts.component.html',
  styleUrls: ['./wishlistproducts.component.css']
})
export class WishlistproductsComponent implements OnChanges , OnInit{

 @Output() TotalProductsCount :EventEmitter<number>;
 productCount! :number;
 userID="4bb78fc2-e42e-4dbf-845d-ab15fd3580d0";
 products! : Iwishlistproducts[];
 prdid :number= 5 ;

constructor(public wishlistservice : WishlistProductService , public router:Router){
  this.TotalProductsCount = new EventEmitter<number>();
}
  ngOnInit(): void {

      this.wishlistservice.GetProductByUserID(this.userID).subscribe(p => {
        this.products = p;
      }, er => alert(er.message))

      this.wishlistservice.getProductsCount(this.userID).subscribe(c => {
        this.productCount = c;
      })
    }

  ngOnChanges(): void {
    // this.wishlistservice.DeleteProductById(this.userID , this.prdid).subscribe(p => {
    //   console.log(p);
    //   this.router.navigate(["wishlist"]);
    // })
  }

// getProductsCount(userID : string){
// this.wishlistservice.getProductsCount(this.userID).subscribe(c => {
//   this.productCount = c ;
// })
// this.TotalProductsCount.emit(this.productCount);
// }

removeprd(productID : number){
  if(confirm("Are you sure you want to remove this product from your wishlist ?"))
  this.wishlistservice.DeleteProductById(this.userID,productID).subscribe(p => {
    console.log(p);
    this.router.navigate(["wishlist"])
  })
}
createImagepath(serverPath: string){
  return `${environment.ImgURL+serverPath}`
}

}
