import { Component, Input } from '@angular/core';
import { CartService } from 'src/app/_services/Cart/cart.service';

@Component({
  selector: 'app-add-to-cart',
  templateUrl: './add-to-cart.component.html',
  styleUrls: ['./add-to-cart.component.css']
})
export class AddToCartComponent {
  @Input() productId=0; 
  statusMessage:string='';
  constructor(private cartService:CartService){

  }
  addToCart(){
    const userId=localStorage.getItem("id");
    console.log(userId);
    console.log(this.productId);
    if(userId!=null){
      this.cartService.addProductToCart(this.productId,userId).subscribe();
    }


  }

}
