import { Component } from '@angular/core';
import { HostListener } from '@angular/core';
import { ProductListComponent } from 'src/app/Full-mart-modules/Products/product-list/product-list.component';
import { IProduct } from 'src/app/_models/iproduct';
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
  public userName:string|null;
  @HostListener('window:scroll', ['$event'])
  onScrollEvent(){
  this.progress = (window.pageYOffset/ (document.body.scrollHeight-window.innerHeight) *100)
  } 
  
  isUserLogged:boolean =false;
  numOfCartProduct:number=0;
  userRole:string="";
  adminRole:boolean=false;
  constructor(private userAuth : UserAuthService, private productService: ProductsService,){
    this.userName = localStorage.getItem('username')
  }
  // isuserlogged =this.userAuth.isUserLogged
  ngOnInit(){
   //User logged Status
    this.userAuth.getLoggedStatus().subscribe(status=>
      this.isUserLogged=status 
    ) 

      //console.log(this.adminRole); 

    this.userAuth.getUserRole().subscribe(role=> {
      
      console.log(role);

      this.userRole = role

      //console.log('role='+this.userRole)

      if(this.userRole == "Admin"){
        this.adminRole=true;
        console.log('admin');
      }else{this.adminRole=false}
    }
    )
 
    
   //Search
   this.productService.getAllProducts().subscribe(product=>
    this.productList=product
   )



  }

  login(){

    //console.log(this.isUserLogged)
  }

  logout(){
    
    this.userAuth.logout();
  }




  search(){

 

    
    localStorage.setItem('search', this.searchInput)

  }

}
