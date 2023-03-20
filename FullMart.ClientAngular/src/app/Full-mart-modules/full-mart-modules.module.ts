import { SortingPipe } from './../Pipes/sorting.pipe';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsModule } from './Products/products.module';
import { CategoryModule } from './Category/category.module';



@NgModule({
  declarations: [
    SortingPipe
  ],
  imports: [
    CommonModule, ProductsModule, CategoryModule
  ],

})
export class FullMartModulesModule { }
