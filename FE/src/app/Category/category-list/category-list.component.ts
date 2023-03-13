import { Component } from '@angular/core';
import { ICategory } from 'src/app/_models/ICategory';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent {

 constructor(private catservice: CategoriesService){}
 
 catList:ICategory[]=[];

 ngOnInit(): void {
  this.catservice.getAllCategories()
  .subscribe(cat=>this.catList = cat )  
}

  ngOnChage(): void {
    this.catservice.getAllCategories()
    .subscribe(cat=>this.catList = cat )  
 }



}
