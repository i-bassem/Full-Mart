import { Component, EventEmitter, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
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

productCount! :number;

products! : Iwishlistproducts[];
prdid :number= 5 ;

constructor(public wishlistservice : WishlistProductService , public router:Router){
}
  ngOnInit(): void {
      const userID :any=localStorage.getItem('id');
      this.wishlistservice.GetProductByUserID(userID).subscribe(products => {
        this.products = products;
      }, er => alert(er.message))

      this.wishlistservice.getProductsCount(userID).subscribe(count => {
        this.productCount = count;
      })
    }

  ngOnChanges(): void {
    const userID :any=localStorage.getItem('id');
    this.wishlistservice.GetProductByUserID(userID).subscribe(products => {
      this.products = products;
    }, er => alert(er.message))

    this.wishlistservice.getProductsCount(userID).subscribe(count => {
      this.productCount = count;
    })
  }

removeprd(productID : number){
  const userID :any=localStorage.getItem('id');
  if(confirm("Are you sure you want to remove this product from your wishlist ?")){
  this.wishlistservice.DeleteProductById(userID,productID).subscribe( product => {
    this.router.navigate(["wishlist"]);
  });
   window.location.reload();
  }
}
createImagepath(serverPath: string){
  return `${environment.ImgURL+serverPath}`
}

}
