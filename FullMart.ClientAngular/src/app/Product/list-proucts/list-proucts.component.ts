import { IProduct } from './../../_models/iproduct';
import { ProductsService } from './../../_services/Products/products.service';
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-list-proucts',
  templateUrl: './list-proucts.component.html',
  styleUrls: ['./list-proucts.component.css']
})
export class ListProuctsComponent {

  constructor(private productservice: ProductsService){}
 
 prdList:IProduct[]=[];
 

 ngOnInit(): void {
  this.productservice.getAllProduct()
  .subscribe(prd=>this.prdList = prd );
  
 
  
}

  ngOnChage(): void {
    this.productservice.getAllProduct()
    .subscribe(prd=>this.prdList = prd);

 }

}
