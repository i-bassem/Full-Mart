import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryAddComponent } from './category-add/category-add.component';
import { CategoryDetailsComponent } from './category-details/category-details.component';
import { CategoryListComponent } from './category-list/category-list.component';



@NgModule({
  declarations: [
    CategoryAddComponent,
    CategoryDetailsComponent,
    CategoryListComponent
  ],
  exports: [
    CategoryAddComponent, CategoryDetailsComponent, CategoryListComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CategoryModule { }

