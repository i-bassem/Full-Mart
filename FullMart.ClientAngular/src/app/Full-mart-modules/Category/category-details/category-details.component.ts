import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBrandDTO } from 'src/app/_models/Ibranddto';
import { ICategory } from 'src/app/_models/ICategory';
import { BrandService } from 'src/app/_services/Brand/Brands.service';
import { CartService } from 'src/app/_services/Cart/cart.service';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';
import { environment } from 'src/environments/environment.development';
import { WishlistProductService } from 'src/app/_services/Wishlist/wishlist-product.service';



@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.css'],
})

export class CategoryDetailsComponent {
  protected catID:number=0;
  protected category:ICategory|null=null;
  // protected products:ICatProduct[]= [];
  protected serverURL = `${environment.ImgURL}`
  catList: ICategory[] = [];
  categorys: ICategory|null=null;
  brands: IBrandDTO[] = [];


constructor( private catservice: CategoriesService, private b :BrandService, private ac:ActivatedRoute,private cartService:CartService , private wishlistserv : WishlistProductService){}

ngOnInit():void{
  this.catID=this.ac.snapshot.params["id"];
  this.catservice.getCategoryByID(this.catID).subscribe(cat=>this.category=cat);
  this.catservice.getAllCategories()
                  .subscribe((cat) => (this.catList = cat));
                  this.b.getBrands()
                  .subscribe((cat) => (this.brands = cat));


}

ngOnChanges(): void {
   this.catservice.getAllCategories()
                  .subscribe((cat) => (this.catList = cat));

}
addToCart(productId:number){
  const userId=localStorage.getItem("id");
  console.log(userId);
  if(userId!=null){
  this.cartService.addProductToCart(productId,userId) .subscribe();
  }
}


addTowishlist(productID : number){
  const userID = localStorage.getItem("id");
  console.log(userID + "from wishlist");
  if(userID != null){
    this.wishlistserv.AddProductToWishlist(productID , userID).subscribe( p => {
      alert("product added successfully to your list")
    })
  }
}



}
