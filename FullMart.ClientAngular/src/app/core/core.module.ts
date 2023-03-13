import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';
import { LibrariesimportModule } from '../librariesimport.module';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent
  ],
  exports:[
    HeaderComponent,FooterComponent
  ],
  imports: [
    CommonModule,RouterModule,LibrariesimportModule
  ]
})
export class CoreModule { }
