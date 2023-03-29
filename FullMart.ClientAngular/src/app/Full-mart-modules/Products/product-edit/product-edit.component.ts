import { IProductEdit } from './../../../_models/IProductEdit';
import { ProductsService } from 'src/app/_services/Products/products.service';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IProductAdded } from 'src/app/_models/iproduct-added';
import { environment } from 'src/environments/environment.development';
import { MessageService } from 'primeng/api';
import { ICategory } from 'src/app/_models/ICategory';
import { IBrandDTO } from 'src/app/_models/Ibranddto';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';
import { BrandService } from 'src/app/_services/Brand/Brands.service';
import { IProduct } from 'src/app/_models/iproduct';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent {

  
  //database path
  public response!: { dbPath: ''; };

  prdId : number =0;

  productAdded : IProductAdded = {} as IProductAdded;
  product : IProduct = {} as IProduct;
  productEdit:IProductEdit = {} as IProductEdit;

  // public  pName: string,
  // public pDescription: string,
  // public price: number,
  // public  rate: number,
  // public  quantity: number,
  // public  imageUrl: string,
  // public  categoryId: number,
  // public brandId: number

  productBrandId :number=1 ;
  productCategoryId :number=1 ;

  catList: ICategory[] = [];
  brandList: IBrandDTO[] = [];
  serverLink=environment.ImgURL;

   //Dependancy injection
   constructor(public productService:ProductsService,private ac:ActivatedRoute
    , private categoryService:CategoriesService,private brandServices:BrandService, private router:Router  ){
      //this.productBrandId = 3; this.productCategoryId = 1
    this.categoryService.getAllCategories().subscribe((catlist) => {
      this.catList = catlist;

   });
   this.brandServices.getBrands().subscribe((brandList) => {
    this.brandList = brandList;

 });

  }
  ngOnInit(){
    this.prdId = this.ac.snapshot.params["id"];
    console.log(this.prdId);
    this.productService.getProductByID(this.prdId)
                    .subscribe(prd=> this.product=prd);  
    console.log(this.product);        
    
    
}


   //Image Upload Finished
 public uploadFinished(event:any){
  this.response = event;
  console.log(this.response);
}

UpdateProduct(){

    this.productEdit = new IProductEdit(
      this.product.productName,
      this.product.productDescription,
      this.product.price,
      this.product.rate,
      this.product.quantity,
      this.response.dbPath,
      this.productCategoryId, 
      this.productBrandId
      );
      this.productService.editProduct(this.prdId, this.productEdit).subscribe((response:any)=>{

        this.router.navigateByUrl("/home")
        },
          (errors)=>{
            alert(errors);
         }
       
      );
      
}

}
