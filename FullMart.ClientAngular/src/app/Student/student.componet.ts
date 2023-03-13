import { SelectorContext } from "@angular/compiler";
import { Component } from "@angular/core";
import { student } from "../_models/student";


@Component({
    selector:"app-student",
    // template:`<h1>student works</h1>`
    templateUrl: "./student.component.html",
    styleUrls:["./student.component.css"]
})
export class StudentComponent{

   students:student[]=[
    new student("7amada",1,23),
    new student("mayada",2,23),
    new student("twfik",3,23),
    new student("kamal",4,23),
   ]
  s1:student = new student("7amada",1,23);

  //ADDING new student
  add(){
    this.students.push(new student(this.s1.stdname,this.s1.stdid,this.s1.stdage));
  }
  //DELETING Student by id 
  delete(idd:number){
    console.log(this.students[idd]);

      let std = this.students.findIndex(x=>x.stdid == idd);
      this.students.splice(std,1);

       // delete this.students[idd];
    //   this.students.forEach((element,index)=>{
    //   if(element.stdid==idd) delete this.students[index];
    // });
  }
}