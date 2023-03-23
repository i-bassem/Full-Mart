import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsModule } from './Products/products.module';
import { CategoryModule } from './Category/category.module';
import { BrowserModule } from '@angular/platform-browser';
import { WishlistModule } from './wishlist/wishlist.module';
import { Router } from '@angular/router';
import { BrandModule } from './brand/brand.module';
import { UserModule } from './User/user.module';




@NgModule({
  declarations: [],
  imports: [
    CommonModule, ProductsModule, CategoryModule , WishlistModule
    , BrandModule, UserModule
  ],

})
export class FullMartModulesModule { }
