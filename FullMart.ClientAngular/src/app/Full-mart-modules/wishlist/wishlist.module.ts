import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WishlistproductsComponent } from './wishlistproducts/wishlistproducts.component';
import { Router, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { LibrariesimportModule } from 'src/app/Libraries/librariesimport.module';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSliderModule } from '@angular/material/slider';
import { RatingModule } from 'primeng/rating';



@NgModule({
  providers:[ RatingModule],
  declarations: [
    WishlistproductsComponent
  ],
  imports: [
    CommonModule,RouterModule,LibrariesimportModule, FormsModule
    , ReactiveFormsModule,MatCheckboxModule,MatSliderModule

  ],
  exports: [
    WishlistproductsComponent
  ]
})
export class WishlistModule { }
