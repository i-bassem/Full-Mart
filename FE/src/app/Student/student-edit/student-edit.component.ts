import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { student } from 'src/app/_models/student';
import { StudentService } from 'src/app/_services/student.service';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css']
})

export class StudentEditComponent implements OnInit {

  id=0;
  st:student|null = new student("",0,0);
  protected name="";
  protected age=0;
  edstd:student =new student("",0,0);

  constructor( public stdser:StudentService,private ac:ActivatedRoute){
  }
 
  ngOnInit(){
    this.id = this.ac.snapshot.params["id"];
    this.st = this.stdser.getById(this.id);
  }
  update(nm:string,ag:number){
    
    // std:student=this.stdser.getById(this.id);
    // this.st?.stdage==ag;
    // this.st?.stdname==nm;
    
    this.edstd = new student(nm,this.id,ag);

    this.stdser.edit(this.st,this.edstd)
  
  }


}
