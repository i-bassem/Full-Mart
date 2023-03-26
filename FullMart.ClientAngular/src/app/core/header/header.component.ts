import { Component } from '@angular/core';
import { HostListener } from '@angular/core';
import { UserAuthService } from 'src/app/_services/UserAuthentication/UserAuthService';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
   
  public progress=0;
   
  @HostListener('window:scroll', ['$event'])
  onScrollEvent(){
  this.progress = (window.pageYOffset/ (document.body.scrollHeight-window.innerHeight) *100)
  } 
  
  isUserLogged:boolean =false;
  numOfCartProduct:number=0;

  constructor(private userAuth : UserAuthService){}
  
  ngOnInit(){

    this.userAuth.getLoggedStatus().subscribe(status=>
      this.isUserLogged=status
      )

      
  }

  login(){
    console.log(this.isUserLogged)
  }

  logout(){
    
    this.userAuth.logout();
  }

}
