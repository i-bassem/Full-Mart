import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IProduct } from 'src/app/_models/iproduct';
import { IReviewModified } from 'src/app/_models/IReviewModified';
import { CartService } from 'src/app/_services/Cart/cart.service';
import { ProductsService } from 'src/app/_services/Products/products.service';
import { ReviewService } from 'src/app/_services/Review/review.service';
import { UserAuthService } from 'src/app/_services/UserAuthentication/UserAuthService';
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
  public comment:string='';
  public numOfStars:number=1;
  isUserLogged:boolean =false;
  
  constructor(private ac: ActivatedRoute, private productService:ProductsService,private reviewService:ReviewService, 
    private cartService:CartService, private userAuth: UserAuthService) {
  }

  ngOnInit():void{
   //Get Product by ID
   this.productID =this.ac.snapshot.params["id"];
   console.log(this.productID);
   this.productService.getProductByID(this.productID).subscribe(data=> this.product = data);
   //User logged Status
   this.userAuth.getLoggedStatus().subscribe(status=>
   this.isUserLogged=status)
  }
  addReview(){
    const userID = localStorage.getItem("id");
    this.productID =this.ac.snapshot.params["id"];
    console.log(userID );
    console.log(this.productID);
    console.log(this.comment);
    console.log(this.numOfStars);
    if(userID != null){
      const newReview = new IReviewModified (this.comment, this.numOfStars, this.productID, userID);
      console.log(newReview);
      this.reviewService.addProductToCart(newReview).subscribe( p => {
        alert("review added successfully")
      })
    }
    //window.location.reload();
  }
  // addToCart(productId:number){
  //   const userId=localStorage.getItem("id");
  //   console.log(userId);
  //   if(userId!=null){
  //   this.cartService.addProductToCart(productId,userId) .subscribe();
  //   }
  // }
  
  



}
