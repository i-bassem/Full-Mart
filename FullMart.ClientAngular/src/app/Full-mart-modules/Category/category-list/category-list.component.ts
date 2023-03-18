import { Component, OnChanges, OnInit } from '@angular/core';
import { ICategory } from 'src/app/_models/ICategory';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';
import { environment } from 'src/environments/environment.development';
import { Router, RouterModule } from '@angular/router';



@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
})
export class CategoryListComponent implements OnInit, OnChanges{
 
  constructor(private catservice: CategoriesService, public router :Router ) {}

  catList: ICategory[] = [];
  category: ICategory|null=null;
  

  ngOnInit(): void {
                    this.catservice.getAllCategories()
                                    .subscribe((cat) => (this.catList = cat));                    
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
