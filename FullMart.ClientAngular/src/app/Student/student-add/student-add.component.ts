import { Component, Output ,EventEmitter} from '@angular/core';
import { Router } from '@angular/router';
import { student } from 'src/app/_models/student';
import { StudentService } from 'src/app/_services/student.service';
import {MessageService} from 'primeng/api';

@Component({
  selector: 'app-student-add',
  templateUrl: './student-add.component.html',
  styleUrls: ['./student-add.component.css'],
  //(VIP) NOT WORKING WITHOUT IT
  providers:[MessageService]
})
export class StudentAddComponent {

// @Output() onStudentAdd:EventEmitter<student> = new EventEmitter<student>();

  s1:student = new student("",0,0);
  //Dependancy injection
  constructor(public stdser:StudentService ,private router:Router, private messageService: MessageService){

  }
  //ADDING new student
  add(){
    this.stdser.add(this.s1);
    setTimeout(()=>this.router.navigateByUrl("/student"),1500)
    
    // this.onStudentAdd.emit(new student(this.s1.stdname,this.s1.stdid,this.s1.stdage));
  }
  //MSG Success popup
  addSingle() {
    this.messageService.add({severity:'success', summary:'Adding Student', detail:'Student Added Sccessfully'});
  }

}
