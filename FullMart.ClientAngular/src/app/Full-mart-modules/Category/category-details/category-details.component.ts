
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBrandDTO } from 'src/app/_models/Ibranddto';
import { ICategory } from 'src/app/_models/ICategory';
import { IProduct } from 'src/app/_models/iproduct';
import { BrandService } from 'src/app/_services/Brand/Brands.service';
import { CartService } from 'src/app/_services/Cart/cart.service';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';
import { ProductsService } from 'src/app/_services/Products/products.service';
import { environment } from 'src/environments/environment.development';
import { WishlistProductService } from 'src/app/_services/Wishlist/wishlist-product.service';
import { ReviewService } from 'src/app/_services/Review/review.service';



@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.css'],
})

export class CategoryDetailsComponent {
  protected catID:number=0;
  protected category:ICategory|null=null;
  protected products:IProduct[] = []
  protected serverURL = `${environment.ImgURL}`
  catList: ICategory[] = [];
  categorys: ICategory|null=null;
  brands: IBrandDTO[] = [];
  selectedSortOption: string;




  constructor(private catservice: CategoriesService,private cartService:CartService,private productServices: ProductsService,
    private b: BrandService,private ac: ActivatedRoute ,private wishlistserv : WishlistProductService) {
    this.selectedSortOption = "Random";
  }


  ngOnInit(): void {

  this.catID=this.ac.snapshot.params["id"];
  this.catservice.getCategoryByID(this.catID).subscribe(cat=>this.category=cat);
  this.catservice.getAllCategories()
                  .subscribe((cat) => (this.catList = cat));
                  this.b.getBrands()
                  .subscribe((cat) => (this.brands = cat));



       this.productServices.getProductByCategoryId(this.catID)
       .subscribe((res:IProduct[])=>{
          this.products = res;
       });
    // this.getBrands();

  }


  ngOnChanges(): void {
    this.catservice.getAllCategories()
                  .subscribe((cat) => (this.catList = cat));



  }
  getBrands() {
    this.b.getBrands().subscribe( (res: any) => {
        console.log(res);

        this.brands = res;
      },
      (error) => {
        console.log(error.message);
      }
    );
  }

  getProductsByBrandName(event:any, brandName?: string) {

    let val = event.target.value; //Nike

    if (val == 'All') {
      this.productServices.getProductByCategoryId(this.catID)
        .subscribe((cat: any) => (this.products = cat));
    } else {
      this.productServices.getProductByBrandName(val).subscribe((res: any) => {
            this.products = res;
         });
    }
  }

  
  sortProducts() {

    if (this.selectedSortOption === 'random') {
      this.productServices.getProductByCategoryId(this.catID)
        .subscribe((cat: any) => (this.products = cat));
    }
    else if (this.selectedSortOption === 'priceAsc') {
      this.products.sort((a, b) => a.price - b.price);
    } else if (this.selectedSortOption === 'priceDesc') {
      this.products.sort((a, b) => b.price - a.price);
    } else if (this.selectedSortOption === 'nameAsc') {
      this.products.sort((a, b) => a.productName.localeCompare(b.productName));
    } else if (this.selectedSortOption === 'nameDesc') {
      this.products.sort((a, b) => b.productName.localeCompare(a.productName));
    }
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
