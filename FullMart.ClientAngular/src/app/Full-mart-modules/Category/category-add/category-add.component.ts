import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ICategory } from 'src/app/_models/ICategory';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';


@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html',
  styleUrls: ['./category-add.component.css'],
  providers:[MessageService]
})

export class CategoryAddComponent {
  //database path
  public response!: { dbPath: ''; };

  cat:ICategory = new ICategory(0,"","");
  //Dependancy injection
  constructor(public categoryService:CategoriesService ,private router:Router, private messageService: MessageService){
  }
observer={
  next:(cat:ICategory) => {
    this.messageService.add({severity:'success', summary:'Adding Category', detail:'Category Added Sccessfully'})},
  error:(err:Error)=>{console.log(err.message);}
 }

//Image Upload Finished
 public uploadFinished(event:any){
  this.response = event;
  console.log(this.response); 
}
 //ADDING new Category
 add(){
  //DB path for image
  this.cat.imageUrl=this.response.dbPath;
  // console.log(this.cat);
  this.categoryService.addCategory(this.cat).subscribe(this.observer)  
  setTimeout(()=>this.router.navigateByUrl("/category"),1500) 
}


}

  //MSG Success popup
  // addSingle() {
  //   this.messageService.add({severity:'success', summary:'Adding Student', detail:'Student Added Sccessfully'});
  // }