import { HttpClient, HttpEventType, HttpParams } from '@angular/common/http';
import { Component,EventEmitter,OnInit,Output } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})

// "wwwroot/Files/Images\\Categories\\Movies.jpg"
export class UploadComponent implements OnInit {

  public message :string="";
  public progress : number=0;
  
 @Output() public onUploadFinished = new EventEmitter();

 constructor(private http:HttpClient ){}

  ngOnInit(){}

  public uploadFile = (files:any)=>{

     if(files.length === 0){return;}
  
     let fileToUpload = <File>files[0];
     const formData = new FormData();
     formData.append('file', fileToUpload, fileToUpload.name);
     console.log(formData);
    //  params: new HttpParams().set('folder', "Products")} 

     this.http.post( `${environment.APIURL}/Upload`, formData, {reportProgress:true, observe:'events'} )
              .subscribe(event=>{
                //Still uploading
                    if( event.type === HttpEventType.UploadProgress ){
                      if (event.total) {  
                        const total: number = event.total;  
                        this.progress = Math.round(100 * event.loaded /event.total); } 
                    }
                //Finished Uploading
                    else if(event.type === HttpEventType.Response){
                      this.message = 'Uploaded Succesfully';
                      this.onUploadFinished.emit(event.body);
                    }
     })
  }



}
