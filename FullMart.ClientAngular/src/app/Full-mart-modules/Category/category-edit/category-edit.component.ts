import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ICategory } from 'src/app/_models/ICategory';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css'],
  providers:[MessageService]
})
export class CategoryEditComponent {

  catID:number = 0;
  serverLink=environment.ImgURL;
  category: ICategory|null=null;
  // category : ICategory = new ICategory(0,"","");

  protected catName="";
  protected catImageUrl="";
  editedCategory:ICategory = new ICategory(0,"","");
  public response!: { dbPath: ''; };

  constructor(private catService: CategoriesService,private ac:ActivatedRoute, private router : Router, private messageService: MessageService){}

  // observer={
  //   next:(cat:ICategory) => {
  //     this.messageService.add({severity:'success', summary:'Editting Category', detail:'Category Edited Sccessfully'})},
  //   error:(err:Error)=>{console.log(err.message);}
  //  }

  ngOnInit(){
      this.catID = this.ac.snapshot.params["id"];
      console.log(this.catID);
      this.catService.getCategoryByID(this.catID)
                      .subscribe(cat=> this.category=cat);  
      console.log(this.category);                
  }

  public uploadFinished(event:any){
    this.response = event;
    console.log(this.response);// {dbPath: '/Files/Images/Categories\\adidas.jpg'}
  }
  
  update(catName:string){
      console.log('1');
      //New DB path for image
      this.editedCategory= new ICategory(this.catID,catName,this.response.dbPath)
      this.catService.editCategory(this.catID, this.editedCategory).subscribe(obs => {
        next:{
          this.messageService.add({severity:'success', summary:'Editting Category', detail:'Category Edited Sccessfully'}),
        Error;(err:Error)=>{console.log(err.message);}
       }})
     setTimeout(()=>this.router.navigateByUrl("/category"),1500) 
    }   

  

   




  


}
