import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrandListComponent } from './brand-list/brand-list.component';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    BrandListComponent
  ],
  exports:[
    BrandListComponent
  ],
  imports: [
    CommonModule,FormsModule
  ]
})
export class BrandModule { }
