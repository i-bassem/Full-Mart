import { Component, OnChanges, OnInit } from '@angular/core';
import { CartService } from 'src/app/_services/Cart/cart.service';
import { CartProducts } from 'src/app/_models/cart-products';
import { environment } from 'src/environments/environment.development';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnChanges   {

  constructor(private cartService:CartService){

  }
  cartProductList:CartProducts[]=[];
  serverImageFile:string=environment.ImgURL;
  
  ngOnInit(){
    const userId=localStorage.getItem("id");
    console.log(userId);
    if(userId!=null){
    this.cartService.getProductsFromCart(userId).subscribe(cartItem=>this.cartProductList=cartItem);
    }
  }
  ngOnChanges(){
    const userId=localStorage.getItem("id");
    console.log(userId);
    if(userId!=null){
    this.cartService.getProductsFromCart(userId).subscribe(cartItem=>this.cartProductList=cartItem);
    }
  }
  deleteFromCart(productId:number){
    const userId=localStorage.getItem("id");
    console.log(userId);
    if(userId!=null){
      
    this.cartService.deleteProductFromCart(productId,userId) .subscribe();
    window.location.reload();
    }
  }
   

}
