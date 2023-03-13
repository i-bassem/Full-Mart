import { Injectable } from '@angular/core';
import { student } from '../_models/student';

@Injectable({
  providedIn: 'root'
})

export class StudentService {

  private students:student []=[
    new student("7amada",1,23),
    new student("mayada",2,23),
    new student("twfik",3,23),
    new student("kamal",4,23),
  ];

  getAll(){
    return this.students;
  }

  showflag=true;

  getById(id:number):student|null {
    for (let index = 0; index < this.students.length; index++) {
      if(this.students[index].stdid == id )
      return this.students[index] 
    }
    
    return null;

    //
    // let std = this.students.find(st => st.stdid == id);
    // return std? std : null ;
  }
  
  add(std:student){
    this.students.push(new student(std.stdname,std.stdid,std.stdage))
  }
  edit(s1:student|null, s2:student){

    let index = this.students.findIndex(st=>st.stdid == s1?.stdid);
    this.students.splice(index,1,s2);
    
  }
  constructor() { }
}
