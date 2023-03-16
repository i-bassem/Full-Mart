import { Component, Input, OnInit } from '@angular/core';
import { student } from 'src/app/_models/student';
import { StudentService } from 'src/app/_services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {

  //component life cycle after constructor
  //Construcor
  //ngonchanges life cycle hook
  //ngoninit (run once)
  //ngdocheck
  //------
  //ngondestroy

    students:student[]=[];

    // stdser:StudentService = new StudentService();
    //Dependancy Injection
     constructor(public stdser:StudentService)
     {
      // this.students = this.stdser.getAll();
     }
     //any intialization talking to service it 's better to do it here
   

     detailsid:number=0;

     ngOnInit(): void {
      this.students = this.stdser.getAll();
    }
;


    //DISPLAYNG LIST OF STUDENTS
      // students:student []=[
      //   new student("7amada",1,23),
      //   new student("mayada",2,23),
      //   new student("twfik",3,23),
      //   new student("kamal",4,23),
      // ]
    //ADDING STUDENT
    // addStd(std:student){
    //   this.students.push(std);
    // }

    //Delete
    delete(id:number)
    {
      let std = this.students.findIndex(x=>x.stdid == id);
      this.students.splice(std,1);
    }

    //Details sort of
     public studname:string ="NA";
     public studid  = 0;
     public studage = 0;
    details(id:number)
    {
       let std = this.students.find(x=>x.stdid == id);
       if(std != null){
          this.studname = std.stdname;
          this.studid   = std.stdid;
          this.studage  = std.stdage;
         }
    }

}
