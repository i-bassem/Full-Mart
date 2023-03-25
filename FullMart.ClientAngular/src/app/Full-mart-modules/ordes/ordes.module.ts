import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { OrdersAddComponent } from './orders-add/orders-add.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    OrdersListComponent,
    OrdersAddComponent,
  ],
  imports: [
    CommonModule,RouterModule
  ]
})
export class OrdesModule { }
