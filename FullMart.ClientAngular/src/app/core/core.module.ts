import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';
import { LibrariesimportModule } from '../Libraries/librariesimport.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { ProductsModule } from '../Full-mart-modules/Products/products.module';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent
  ],
  exports:[
    HeaderComponent, FooterComponent
  ],
  imports: [
    FormsModule, CommonModule,RouterModule,LibrariesimportModule,MatFormFieldModule,MatInputModule,MatButtonModule,
    ProductsModule
  ]
})
export class CoreModule { }
