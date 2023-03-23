
import { Component } from '@angular/core';
import { OrderService } from 'src/app/_services/order/order.service';
import { OrderCreateDTO } from 'src/app/_models/ordercraete';
@Component({
  selector: 'app-orders-add',
  templateUrl: './orders-add.component.html',
  styleUrls: ['./orders-add.component.css']
})

export class OrdersAddComponent  {
  userId = localStorage.getItem('id');
  orderDTO: OrderCreateDTO = {
    orderProducts: []
  };
  constructor(private orderService: OrderService) { }
  createOrder(userId: string): void {
    this.orderService.createOrder(userId, this.orderDTO)
      .subscribe(order => {
        console.log('Order created:', order);
      });
  }
}
