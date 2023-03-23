import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule,Routes }from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { LibrariesComponent } from './Libraries/libraries.component';
import { CategoryListComponent } from './Full-mart-modules/Category/category-list/category-list.component';
import { CategoryAddComponent } from './Full-mart-modules/Category/category-add/category-add.component';
import { CategoryEditComponent } from './Full-mart-modules/Category/category-edit/category-edit.component';
import { CategoryDetailsComponent } from './Full-mart-modules/Category/category-details/category-details.component';
import { ProductAddComponent } from './Full-mart-modules/Products/product-add/product-add.component';
import { ProductEditComponent } from './Full-mart-modules/Products/product-edit/product-edit.component';
import { ProductDetailsComponent } from './Full-mart-modules/Products/product-details/product-details.component';
import { ProductListComponent } from './Full-mart-modules/Products/product-list/product-list.component';
import { ErrorsComponent } from './errors/errors.component';
import { BrandListComponent } from './Full-mart-modules/brand/brand-list/brand-list.component';
import { UserRegisterComponent } from './Full-mart-modules/User/user-register/user-register.component';
import { UserAuthenticationComponent } from './Full-mart-modules/User/user-authentication/user-authentication.component';
import { IndexComponent } from './Cart/index/index.component';
import { AddProductToCartComponent } from './Cart/add-product-to-cart/add-product-to-cart.component';
import { OrdersListComponent } from './Full-mart-modules/ordes/orders-list/orders-list.component';



const routes:Routes=[

  {path:"home",component:HomeComponent},
  {path:"contactus",component:ContactUsComponent},
  {path:"aboutus",component:AboutUsComponent},
  //Categories
  {path:"category",component:CategoryListComponent},
  {path:"category/add",component:CategoryAddComponent},
  {path:"category/edit/:id",component:CategoryEditComponent},
  {path:"category/details/:id", component:CategoryDetailsComponent},
  //Products
  {path:"product",component:ProductListComponent},
  {path:"product/add",component:ProductAddComponent},
  {path:"product/edit/:id",component:ProductEditComponent},
  {path:"product/details/:id",component:ProductDetailsComponent},
  //brand
  {path:"Brand",component:BrandListComponent},
  //order
  {path:"order",component:OrdersListComponent},





  //Cart
  {path:"Cart",component:IndexComponent},
 




  //User
  {path:"userRegister", component:UserRegisterComponent},
  {path:"userLogin", component: UserAuthenticationComponent},
  // statics
  {path:"aboutus",component:AboutUsComponent},
  {path:"contact",component:ContactUsComponent},
  {path:"libraries", component:LibrariesComponent},
  {path:"", redirectTo:"/home", pathMatch:"full"},
  {path:"**", component:ErrorsComponent}

];
@NgModule({
  declarations: [],
  imports: [
    CommonModule,RouterModule.forRoot(routes)
  ],
  exports:[
      RouterModule
  ]
})
export class AppRoutingModule { }
