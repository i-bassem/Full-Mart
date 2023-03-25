
// import { Component, OnInit } from '@angular/core';
// import { OrderService } from 'src/app/_services/order/order.service';

// import { Iorder } from 'src/app/_models/Iorder';

// @Component({
//   selector: 'app-orders-list',
//   templateUrl: './orders-list.component.html',
//   styleUrls: ['./orders-list.component.css']
// })

// export class OrdersListComponent implements OnInit {

//   userId = localStorage.getItem('id');
//   orders: Iorder[] | undefined;

//   // orders: Order[] = [...]; // Your list of orders

  
//   constructor(private orderService: OrderService) { }
//   calculateTotalPrice(order: any): number {
//     let totalPrice = 0;
//     for (let orderProduct of order.orderProductDTOs) {
//       totalPrice += orderProduct.price;
//     }
//     return totalPrice;
//   }
//   getAllOrders(): void {
//     if(this.userId!=null)

//     this.orderService.getOrdersByUserId(this.userId)
//       .subscribe(orders => this.orders = orders);
//   }

  
//   ngOnInit(): void {
//     if(this.userId!=null)
//     {console.log(this.userId)
//     this.orderService.getOrdersByUserId(this.userId)
//       .subscribe(orders => this.orders = orders);}
//   }

  
// }


import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/_services/order/order.service';

import { Iorder } from 'src/app/_models/Iorder';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})

export class OrdersListComponent implements OnInit {

  userId = localStorage.getItem('id');
  orders: Iorder[] | undefined;

  // orders: Order[] = [...]; // Your list of orders

  
  constructor(private orderService: OrderService) { }
  calculateTotalPrice(order: any): number {
    let totalPrice = 0;
    for (let orderProduct of order.orderProductDTOs) {
      totalPrice += orderProduct.price;
    }
    return totalPrice;
  }
  getAllOrders(): void {
       if(this.userId!=null)
    
        this.orderService.getOrdersByUserId(this.userId)
         .subscribe(orders => this.orders = orders);
     }

  
  ngOnInit(): void {
    if (this.userId != null) {
      console.log(this.userId)
      this.orderService.getOrdersByUserId(this.userId)
        .subscribe(orders => {
          this.orders = orders;
          this.orders = [this.orders[this.orders.length - 1]]; // Get the last order
        });
    } }

  
}

