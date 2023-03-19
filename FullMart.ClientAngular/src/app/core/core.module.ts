import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';
import { LibrariesimportModule } from '../Libraries/librariesimport.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent
  ],
  exports:[
    HeaderComponent,FooterComponent
  ],
  imports: [
    CommonModule,RouterModule,LibrariesimportModule,MatFormFieldModule,MatInputModule,MatButtonModule
  ]
})
export class CoreModule { }
