import { BrandService } from 'src/app/_services/Brand/Brands.service';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';
import { IBrandDTO } from 'src/app/_models/Ibranddto';
import { ICategory } from 'src/app/_models/ICategory';
import { ProductsService } from 'src/app/_services/Products/products.service';
import { IProduct } from 'src/app/_models/iproduct';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { IProductAdded } from 'src/app/_models/iproduct-added';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css'],
  providers:[MessageService]
})
export class ProductAddComponent {

  //database path
  public response!: { dbPath: ''; };

  product : IProductAdded = {} as IProductAdded;

  catList: ICategory[] = [];
  brandList: IBrandDTO[] = [];

   //Dependancy injection
   constructor(public productService:ProductsService,private categoryService: CategoriesService
    ,private brandServices:BrandService ,private router:Router, private messageService: MessageService){
    this.categoryService.getAllCategories().subscribe((catlist) => {
      this.catList = catlist;

   });
   this.brandServices.getBrands().subscribe((brandList) => {
    this.brandList = brandList;

 });
  }
   observer={
    next:(product:IProductAdded) => {
      this.messageService.add({severity:'success', summary:'Adding Product', detail:'Product Added Sccessfully'})},
    error:(err:Error)=>{console.log(err.message);}
   }

   //Image Upload Finished
 public uploadFinished(event:any){
  this.response = event;
  console.log(this.response);
}
addProduct(){
  //DB path for image
  this.product.imageUrl=this.response.dbPath;
   console.log(this.product);
  this.productService.addProduct(this.product).subscribe(this.observer)
  setTimeout(()=>this.router.navigateByUrl("/product"),1500)
}

}
