import { Component } from '@angular/core';
import { HostListener } from '@angular/core';
import { ProductListComponent } from 'src/app/Full-mart-modules/Products/product-list/product-list.component';
import { IProduct } from 'src/app/_models/IProduct';
import { ProductsService } from 'src/app/_services/Products/products.service';
import { UserAuthService } from 'src/app/_services/UserAuthentication/UserAuthService';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  public progress=0;
  public searchInput="";
  public productList:IProduct[]|null=null;

  @HostListener('window:scroll', ['$event'])
  onScrollEvent(){
  this.progress = (window.pageYOffset/ (document.body.scrollHeight-window.innerHeight) *100)
  }

  isUserLogged:boolean =false;
  numOfCartProduct:number=0;

  constructor(private userAuth : UserAuthService, private productService: ProductsService){}

  ngOnInit(){
   //User logged Status
    this.userAuth.getLoggedStatus().subscribe(status=>
      this.isUserLogged=status
      )

   //Search
   this.productService.getAllProducts().subscribe(product=>
    this.productList=product
   )



  }

  login(){

    console.log(this.isUserLogged)
  }

  logout(){

    this.userAuth.logout();
  }




  search(){

    //console.log(word);
    console.log(this.searchInput);

  }

}
