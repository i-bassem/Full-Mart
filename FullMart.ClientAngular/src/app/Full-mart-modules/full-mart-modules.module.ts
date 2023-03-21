import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsModule } from './Products/products.module';
import { CategoryModule } from './Category/category.module';
import { BrandModule } from './brand/brand.module';
import { UserModule } from './User/user.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule, ProductsModule, CategoryModule, BrandModule, UserModule
  ],

})
export class FullMartModulesModule { }
