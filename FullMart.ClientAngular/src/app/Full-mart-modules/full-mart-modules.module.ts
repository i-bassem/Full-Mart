import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsModule } from './Products/products.module';
import { CategoryModule } from './Category/category.module';
import { BrowserModule } from '@angular/platform-browser';
import { WishlistModule } from './wishlist/wishlist.module';
import { Router } from '@angular/router';

@NgModule({
  declarations: [],
  imports: [
    CommonModule, ProductsModule, CategoryModule , WishlistModule
  ],

})
export class FullMartModulesModule { }
