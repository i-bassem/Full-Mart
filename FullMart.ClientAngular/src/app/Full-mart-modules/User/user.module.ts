import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserAuthenticationComponent } from './user-authentication/user-authentication.component';
import { UserRegisterComponent } from './user-register/user-register.component';



@NgModule({
  declarations: [
    UserRegisterComponent,
    UserAuthenticationComponent
  ],
  imports: [
    CommonModule, ReactiveFormsModule, FormsModule
  ]
})
export class UserModule { }
