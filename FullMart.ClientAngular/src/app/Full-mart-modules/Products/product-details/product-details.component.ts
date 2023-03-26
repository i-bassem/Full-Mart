import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IProduct } from 'src/app/_models/iproduct';
import { CartService } from 'src/app/_services/Cart/cart.service';
import { ProductsService } from 'src/app/_services/Products/products.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent {
  protected productID=0;
  // public product:IProduct=new IProduct(0,"","",0,0,0,"","",0,[],null)
  protected product:any
  protected serverURL = `${environment.ImgURL}`

  constructor(private ac: ActivatedRoute, private productService:ProductsService,private cartService:CartService) {
  }

  ngOnInit():void{
   this.productID =this.ac.snapshot.params["id"];
   console.log(this.productID);
   this.productService.getProductByID(this.productID).subscribe(data=> this.product = data);
  }

  addToCart(productId:number){
    const userId=localStorage.getItem("id");
    console.log(userId);
    if(userId!=null){
    this.cartService.addProductToCart(productId,userId) .subscribe();
    }
  }


}
