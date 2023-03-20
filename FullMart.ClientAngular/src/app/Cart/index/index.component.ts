import { Component, OnChanges, OnInit } from '@angular/core';
import { CartService } from 'src/app/_services/Cart/cart.service';
import { CartProducts } from 'src/app/_models/cart-products';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent  {

  constructor(private cartService:CartService){

  }
  cartProductList:CartProducts[]=[];
  ngOnInit(){
    this.cartService.getProductsFromCart().subscribe(cartItem=>this.cartProductList=cartItem)
  }

}
