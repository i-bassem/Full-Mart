import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddToCartComponent } from './add-to-cart/add-to-cart.component';
import { AddToWishlistComponent } from './add-to-wishlist/add-to-wishlist.component';
import { UploadComponent } from './upload/upload.component';
import { LibrariesimportModule } from '../Libraries/librariesimport.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSliderModule } from '@angular/material/slider';



@NgModule({
  declarations: [
    AddToCartComponent,
    AddToWishlistComponent,
    //UploadComponent
  ],
  imports: [
    CommonModule,LibrariesimportModule, FormsModule, ReactiveFormsModule,MatCheckboxModule,MatSliderModule
  ],
  exports: [
    AddToCartComponent,
    AddToWishlistComponent,
    //UploadComponent
  ]
})
export class SharedModule { }
