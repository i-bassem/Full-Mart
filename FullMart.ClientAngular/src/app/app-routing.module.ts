import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule,Routes }from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { StudentListComponent } from './Student/student-list/student-list.component';
import { StudentDetailsComponent } from './Student/student-details/student-details.component';
import { StudentAddComponent } from './Student/student-add/student-add.component';
import { LibrariesComponent } from './libraries/libraries.component';
import { StudentEditComponent } from './Student/student-edit/student-edit.component';
import { CategoryListComponent } from './Category/category-list/category-list.component';
import { WishlistproductsComponent } from './wishlist/wishlistproducts/wishlistproducts.component';


const routes:Routes=[

  {path:"home",component:HomeComponent},
  {path:"contactus",component:ContactUsComponent},
  {path:"aboutus",component:AboutUsComponent},
  {path:"student", component:StudentListComponent,
    children:[
            {path:"details/:id", component:StudentDetailsComponent}
     ]
  },
  // {path:"student/details/:id", component:StudentDetailsComponent },
  {path:"student/add",component:StudentAddComponent},
  {path:"student/edit/:id",component:StudentEditComponent},

  {path:"category",component:CategoryListComponent},

  {path:"libraries", component:LibrariesComponent},

  {path:"", redirectTo:"/home", pathMatch:"full"},

  {path:"wishlist" , component:WishlistproductsComponent},





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
