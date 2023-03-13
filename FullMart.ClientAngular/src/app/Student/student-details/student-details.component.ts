import { Component, Input, OnInit,OnChanges, SimpleChange } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { timeInterval } from 'rxjs';
import { student } from 'src/app/_models/student';
import { StudentService } from 'src/app/_services/student.service';







@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})

export class StudentDetailsComponent implements OnInit, OnChanges{

  // @Input() id:number=0;

  student:student|null = new student("NA",0,0);

  idd=0;

  constructor (public stdser:StudentService, private ac:ActivatedRoute){
  }

  ngOnChanges(){
    //Works for input parameter from parent only....... 

    // s:SimpleChange in the parameter of ngonchange
    // s.currentValue
    // this.student = this.stdser.getById(this.id);
  }

  ngOnInit(){
   
     this.ac.params.subscribe(a=>{
        this.idd = a['id']
        this.student=this.stdser.getById(this.idd);
     })
   

    //snapshot take a only one snap can't change
    // this.idd = this.ac.snapshot.params["id"];
    // this.student=this.stdser.getById(this.idd);
  }

}
