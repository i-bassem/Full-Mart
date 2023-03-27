import { Component } from '@angular/core';
import { IProduct } from 'src/app/_models/iproduct';
import { CartService } from 'src/app/_services/Cart/cart.service';
import { ProductsService } from 'src/app/_services/Products/products.service';
import { WishlistProductService } from 'src/app/_services/Wishlist/wishlist-product.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  
  protected products:IProduct[] = []
  protected serverURL = `${environment.ImgURL}`
  protected searchedProducts:IProduct[] = []
  protected searchedProduct = localStorage.getItem('search')?.toUpperCase()


  constructor(private productService : ProductsService, private cartService:CartService, private wishlistserv:WishlistProductService){}


  ngOnInit():void{
   
   this.productService.getAllProducts().subscribe(allProducts=>{   
    this.products = allProducts
  
    console.log(this.searchedProduct);
    console.log(this.products);
 
    if(this.searchedProduct){
    for(let i =0 ; i<this.products.length;i++){
     if(this.products[i].productName.toUpperCase().includes(this.searchedProduct)){
       this.searchedProducts.push(this.products[i])   
       }
      }
     }
    }
   )
  }

  ngOnchanges(): void{

    this.productService.getAllProducts().subscribe(allProducts=>{   
      this.products = allProducts
    
      console.log(this.searchedProduct);
      console.log(this.products);
   
      if(this.searchedProduct){
      for(let i =0 ; i<this.products.length;i++){
       if(this.products[i].productName.toUpperCase().includes(this.searchedProduct)){
         this.searchedProducts.push(this.products[i])   
         }
        }
       }
      }
     )

    



    //  addToCart(id){
    //   const userId=localStorage.getItem("id");
    //   console.log(userId);
    //   if(userId!=null){
    //   this.cartService.addProductToCart(id,userId) .subscribe();
    //   }
    //  }
    
    // addTowishlist(productID : number){
    //   const userID = localStorage.getItem("id");
    //   console.log(userID + "from wishlist");
    //   if(userID != null){
    //     this.wishlistserv.AddProductToWishlist(productID , userID).subscribe( p => {
    //       alert("product added successfully to your list")
    //     })
    //   }
    // }
  }


   
  


 
}
