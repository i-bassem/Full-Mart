import { Component, OnChanges, OnInit } from '@angular/core';
import { CartService } from 'src/app/_services/Cart/cart.service';
import { CartProducts } from 'src/app/_models/cart-products';
import { environment } from 'src/environments/environment.development';
import { OrderService } from 'src/app/_services/order/order.service';
import { OrderCreateDTO, OrderProductCreateDTO } from 'src/app/_models/ordercraete';
import { OrderProductDTO } from 'src/app/_models/Iorder';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnChanges   {

  constructor(private cartService:CartService , private orderService: OrderService){

  }
  cartProductList:CartProducts[]=[];
  totalPrice:number=0;
  serverImageFile:string=environment.ImgURL;
  orderDTO: OrderCreateDTO = {
    orderProducts: []
  };
  
  
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
  createOrder(): void {
    const userId = localStorage.getItem('id');
    const orderProductDTOs: OrderProductCreateDTO[] = [];
  
    // Loop through the cart products and create an order product DTO for each one
    for (const cartProduct of this.cartProductList) {
      const orderProductDTO: OrderProductCreateDTO = {
        productId: cartProduct.id,
      };
      orderProductDTOs.push(orderProductDTO);
  
      // Delete the product from the cart
      if(userId!= null)
      this.cartService.deleteProductFromCart(cartProduct.id, userId)
        .subscribe(() => {
          console.log('Product deleted from cart:', cartProduct);
        });
    }
  
    // Create the order DTO with the order product DTOs array
    const orderDTO: OrderCreateDTO = {
      orderProducts: orderProductDTOs
    };
  
    // Call the createOrder() method of your OrderService with the userId and orderDTO
    if (userId != null) {
      this.orderService.createOrder(userId, orderDTO)
        .subscribe(order => {
          console.log('Order created:', order);
          // Clear the cart after successfully creating the order
          this.cartProductList = [];
        });
    }
  }
  getTotalPrice():number{
    this.totalPrice=0;
    this.cartProductList.forEach(element => {
      this.totalPrice=this.totalPrice+element.price;
    });
    return this.totalPrice;
  }
   

}
