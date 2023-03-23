import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddProductToCartComponent } from '../add-product-to-cart/add-product-to-cart.component';
import { RemoveProductFromCartComponent } from '../remove-product-from-cart/remove-product-from-cart.component';
import { IndexComponent } from '../index/index.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    AddProductToCartComponent,
    RemoveProductFromCartComponent,
    IndexComponent
  ],
  exports:[
    AddProductToCartComponent,
    RemoveProductFromCartComponent,
    IndexComponent
  ],
  imports: [
    CommonModule,RouterModule
  ]
})
export class CartModule { }
