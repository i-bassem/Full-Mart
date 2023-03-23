import { ProductsService } from 'src/app/_services/Products/products.service';
import { IProduct } from 'src/app/_models/IProduct';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  productList: IProduct[] = [];

  constructor(private productsService: ProductsService, public router :Router){}
  ngOnInit(): void {
    this.productsService.getAllProducts()
                    .subscribe((prd) => (this.productList = prd));                    
}
ngOnChanges(): void {
  this.productsService.getAllProducts()
  .subscribe((prd) => (this.productList = prd));  

}

createImagepath(serverPath: string){
  return `${environment.ImgURL+serverPath}`
}

delete(prdId:number){
  this.productsService.deleteProduct(prdId).subscribe(data=>console.log(data));;
   
  window.location.reload();
  
}
}
