import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { OrdersAddComponent } from './orders-add/orders-add.component';



@NgModule({
  declarations: [
    OrdersListComponent,
    OrdersAddComponent
  ],
  imports: [
    CommonModule
  ]
})
export class OrdesModule { }
