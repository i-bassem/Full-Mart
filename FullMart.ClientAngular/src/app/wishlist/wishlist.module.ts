import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WishlistproductsComponent } from './wishlistproducts/wishlistproducts.component';
import { Router, RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    WishlistproductsComponent
  ],
  imports: [
    CommonModule , RouterModule
  ],
  exports: [
    WishlistproductsComponent
  ]
})
export class WishlistModule { }
