import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule,Routes }from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { NotFoundComponent } from './Not-found/not-found.component';
import { LibrariesComponent } from './Libraries/libraries.component';
import { CategoryListComponent } from './Full-mart-modules/Category/category-list/category-list.component';
import { CategoryAddComponent } from './Full-mart-modules/Category/category-add/category-add.component';
import { CategoryEditComponent } from './Full-mart-modules/Category/category-edit/category-edit.component';
import { CategoryDetailsComponent } from './Full-mart-modules/Category/category-details/category-details.component';
import { ProductAddComponent } from './Full-mart-modules/Products/product-add/product-add.component';
import { ProductEditComponent } from './Full-mart-modules/Products/product-edit/product-edit.component';
import { ProductDetailsComponent } from './Full-mart-modules/Products/product-details/product-details.component';
import { ProductListComponent } from './Full-mart-modules/Products/product-list/product-list.component';


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





  {path:"libraries", component:LibrariesComponent},
  {path:"", redirectTo:"/home", pathMatch:"full"},
  {path:"**", component:NotFoundComponent}
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
