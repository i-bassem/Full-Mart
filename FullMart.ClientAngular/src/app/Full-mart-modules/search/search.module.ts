import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { LibrariesimportModule } from 'src/app/Libraries/librariesimport.module';
import { MatSliderModule } from '@angular/material/slider';
import { ChartModule } from 'primeng/chart';
import { WishlistModule } from '../wishlist/wishlist.module';
import { SearchComponent } from './search.component';




@NgModule({
  declarations: [ 
    SearchComponent
  ],
  imports: [
    CommonModule,RouterModule,LibrariesimportModule, FormsModule, ReactiveFormsModule, MatCheckboxModule, MatSliderModule,
    ChartModule, WishlistModule
  ],
  exports:[
    SearchComponent
  ]
})
export class SearchModule { }
