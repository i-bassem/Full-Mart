import { Component } from '@angular/core';
import { department } from '../_models/department';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent {
  departments:department[]=[
    new department("SD",10,"omar"),
    new department("PHP",20,"sayed"),
    new department(".NET",30,"mohsen"),
   ]
  d1:department = new department("Mern",40,"noha");

  //ADDING new department
  add(){
    this.departments.push(new department(this.d1.deptname,this.d1.deptid,this.d1.deptinstructor));
  }
  delete(idd:number){
    //  console.log(this.departments.find(d=>d.deptid==idd));
    //  let d =this.departments.find(d=>d.deptid==idd)

    //  this.departments.forEach((element,index)=>{
    //   if(element.deptid==idd) delete this.departments[index];
    // });
      let dep = this.departments.findIndex(x=>x.deptid == idd);
      this.departments.splice(dep,1);
 
  }
}
