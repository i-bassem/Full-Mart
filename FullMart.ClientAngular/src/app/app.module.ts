

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { StudentComponent } from './Student/student.componet';
import { DepartmentComponent } from './department/department.component';
import { FormsModule } from '@angular/forms';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { StudentModule } from './Student/student.module';
import { LibrariesComponent } from './libraries/libraries.component';
import { HomeComponent } from './home/home.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { AppRoutingModule } from './app-routing.module';
import { LibrariesimportModule } from './librariesimport.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CategoryModule } from './Category/category.module';
import { ProductModule } from './Product/product/product.module';



@NgModule({
  declarations: [
    AppComponent,StudentComponent,DepartmentComponent, LibrariesComponent, HomeComponent, ContactUsComponent, 
    AboutUsComponent, NotFoundComponent],
  imports: [
    BrowserModule,FormsModule,CoreModule,SharedModule,StudentModule,AppRoutingModule,
    LibrariesimportModule, BrowserAnimationsModule,CategoryModule , ProductModule
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
