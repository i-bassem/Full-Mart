import { ListProuctsComponent } from './../list-proucts/list-proucts.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [
    ListProuctsComponent
  ],
  exports:[
    ListProuctsComponent
  ],
  imports: [
    CommonModule
   
  ]
})
export class ProductModule { }
