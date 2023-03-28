import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductAddComponent } from './product-add/product-add.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductListComponent } from './product-list/product-list.component';
import { RatingModule } from 'primeng/rating';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { LibrariesimportModule } from 'src/app/Libraries/librariesimport.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSliderModule } from '@angular/material/slider';
import { UploadComponent } from 'src/app/shared/upload/upload.component';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  providers:[ RatingModule],
  declarations: [
    ProductAddComponent,
    ProductDetailsComponent,
    ProductEditComponent,
    ProductListComponent,
    UploadComponent,
    
  ],
  exports:[
    ProductAddComponent,
     ProductDetailsComponent, 
     ProductEditComponent,
     ProductListComponent
  ],
 
  imports: [
    CommonModule,RouterModule,LibrariesimportModule, FormsModule, ReactiveFormsModule
    ,MatCheckboxModule,MatSliderModule, SharedModule
  ]
})
export class ProductsModule { }
