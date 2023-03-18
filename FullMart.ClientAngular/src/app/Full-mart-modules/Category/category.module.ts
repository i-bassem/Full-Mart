import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryAddComponent } from './category-add/category-add.component';
import { CategoryDetailsComponent } from './category-details/category-details.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { UploadComponent } from '../../shared/upload/upload.component';
import { FormsModule, NgControl, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LibrariesimportModule } from '../../Libraries/librariesimport.module';
import { CategoryEditComponent } from './category-edit/category-edit.component';
import { RatingModule } from 'primeng/rating';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';




@NgModule({
  providers:[ RatingModule],
  declarations: [
            CategoryAddComponent,
            CategoryDetailsComponent,
            CategoryListComponent,
            CategoryEditComponent,
            UploadComponent,
                   
  ],
  exports:[
        CategoryAddComponent, CategoryDetailsComponent, CategoryListComponent,CategoryEditComponent
      ],
  imports: [
    CommonModule,RouterModule,LibrariesimportModule, FormsModule, ReactiveFormsModule

  ]
})
export class CategoryModule { }

