
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

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    if(this.userId!=null)
    {console.log(this.userId)
    this.orderService.getOrdersByUserId(this.userId)
      .subscribe(orders => this.orders = orders);}
  }
}

