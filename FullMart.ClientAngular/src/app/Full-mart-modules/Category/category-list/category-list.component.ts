import { Component, OnChanges, OnInit } from '@angular/core';
import { ICategory } from 'src/app/_models/ICategory';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';
import { environment } from 'src/environments/environment.development';
import { Router, RouterModule } from '@angular/router';
import { UserAuthService } from 'src/app/_services/UserAuthentication/UserAuthService';



@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
})
export class CategoryListComponent implements OnInit, OnChanges{

  catList: ICategory[] = [];
  category: ICategory|null=null;
  isUserLogged:boolean =false;
 
  constructor(private catservice: CategoriesService, public router :Router , private userAuth: UserAuthService ) {

  }

 
  

  ngOnInit(): void {
                    this.catservice.getAllCategories()
                                    .subscribe((cat) => (this.catList = cat));   
                                    
                                      //User logged Status
                   this.userAuth.getLoggedStatus().subscribe(status=>
                                this.isUserLogged=status)
                                                    
  }

  ngOnChanges(): void {
                     this.catservice.getAllCategories()
                                    .subscribe((cat) => (this.catList = cat));
               
  }

  createImagepath(serverPath: string){
    return `${environment.ImgURL+serverPath}`
  }

delete(catID:number){
    this.catservice.deleteCategory(catID).subscribe(data=>console.log(data));;
    // setTimeout(()=>this.router.navigateByUrl("/category"),1500)   
    window.location.reload();
    
 }


}
