import { Component, Input } from '@angular/core';
import { WishlistProductService } from 'src/app/_services/Wishlist/wishlist-product.service';

@Component({
  selector: 'app-add-to-wishlist',
  templateUrl: './add-to-wishlist.component.html',
  styleUrls: ['./add-to-wishlist.component.css']
})
export class AddToWishlistComponent {

@Input() productID=0
constructor(protected wishlistservice: WishlistProductService){}


  addTowishlist(){
    const userID = localStorage.getItem("id");
    console.log(userID + "from wishlist");
    if(userID != null){
      this.wishlistservice.AddProductToWishlist(this.productID , userID).subscribe( p => {
        alert("product added successfully to your list")
      })
    }
  }

}
