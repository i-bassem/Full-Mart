import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductAddComponent } from './product-add/product-add.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductListComponent } from './product-list/product-list.component';



@NgModule({
  declarations: [
    ProductAddComponent,
    ProductDetailsComponent,
    ProductEditComponent,
    ProductListComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ProductsModule { }
