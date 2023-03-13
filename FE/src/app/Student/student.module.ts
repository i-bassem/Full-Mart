import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { StudentAddComponent } from './student-add/student-add.component';
import { StudentListComponent } from './student-list/student-list.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { StudentEditComponent } from './student-edit/student-edit.component';
import { LibrariesimportModule } from '../librariesimport.module';




@NgModule({
  declarations: [
    StudentDetailsComponent,
    StudentAddComponent,
    StudentListComponent,
    StudentEditComponent, 
  ],
  exports:[
    StudentListComponent,StudentAddComponent,StudentDetailsComponent
  ],
  imports: [
    CommonModule,FormsModule,RouterModule,LibrariesimportModule
  ]
})
export class StudentModule { }
