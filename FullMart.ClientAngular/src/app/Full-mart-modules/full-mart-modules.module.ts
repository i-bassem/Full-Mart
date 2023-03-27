import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryModule } from './Category/category.module';
import { BrowserModule } from '@angular/platform-browser';
import { WishlistModule } from './wishlist/wishlist.module';
import { Router } from '@angular/router';
import { BrandModule } from './brand/brand.module';
import { UserModule } from './User/user.module';
import { OrdesModule } from './ordes/ordes.module';
import { ProductsModule } from './Products/products.module';
import { CategoryListComponent } from './Category/category-list/category-list.component';
import { SearchModule } from './Search/search.module';





@NgModule({
  declarations: [
   
  ],
  
  imports: [
    CommonModule, CategoryModule , WishlistModule, BrandModule, UserModule, OrdesModule, ProductsModule, SearchModule
  ],
  exports:[
    CategoryListComponent
  ]

})
export class FullMartModulesModule { }
