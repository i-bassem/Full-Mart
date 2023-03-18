import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ICategory } from 'src/app/_models/ICategory';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';
import { environment } from 'src/environments/environment.development';




@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.css'],
})

export class CategoryDetailsComponent {
  protected catID:number=0;
  protected category:ICategory|null=null;
  // protected products:ICatProduct[]= [];
  protected serverURL = `${environment.ImgURL}`
 

constructor( private catservice: CategoriesService, private ac:ActivatedRoute){}

ngOnInit():void{
  this.catID=this.ac.snapshot.params["id"];
  this.catservice.getCategoryByID(this.catID).subscribe(cat=>this.category=cat);

  
    
}
 



}
