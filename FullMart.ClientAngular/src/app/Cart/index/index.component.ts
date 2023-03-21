import { Component, OnChanges, OnInit } from '@angular/core';
import { CartService } from 'src/app/_services/Cart/cart.service';
import { CartProducts } from 'src/app/_models/cart-products';
import { environment } from 'src/environments/environment.development';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent  {

  constructor(private cartService:CartService){

  }
  cartProductList:CartProducts[]=[];
  serverImageFile:string=environment.ImgURL;
  
  ngOnInit(){
    this.cartService.getProductsFromCart().subscribe(cartItem=>this.cartProductList=cartItem)
  }

}
