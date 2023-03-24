import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { passwordMatch } from 'src/app/CustomValidator/PasswordMatch.Validator';
import { IUser } from 'src/app/_models/IUser';
import { UserRegistrationService } from 'src/app/_services/UserRegistration/user-registration.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent {
   

  validationErrors:any;
  userRegistrationForm;

  constructor(private formBuilder:FormBuilder, private userService:UserRegistrationService, private router:Router ){
   
    this.userRegistrationForm = formBuilder.group(
      {
        firstName:["", Validators.required],
        lastName: ["", Validators.required],
        username: ["", Validators.required],
        email:    ["", [Validators.required, Validators.email]],
        password: ["", [Validators.required, Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$')]],
        confirmPassword: ["", Validators.required],
        imageUrl: [""],
      },{validators: passwordMatch() });
     
  }
  //Errors
  //get=> Readonly Property not a function 
  get firstName(){
    return this.userRegistrationForm.get('firstName')
  }
  get lastName(){
    return this.userRegistrationForm.get('lastName')
  }
  get username(){
    return this.userRegistrationForm.get('username')
  }
  get email(){
    return this.userRegistrationForm.get('email')
  }
  get password(){
    return this.userRegistrationForm.get('password')
  }
  get confirmPassword(){
    return this.userRegistrationForm.get('confirmPassword')
  }



  submit(){
 
    let newUser = this.userRegistrationForm.value as IUser;
    console.log(newUser);
    //Send User Data to API
    this.userService.registerUser(newUser).subscribe((response:any)=>{
     
      console.log(response)
      this.router.navigateByUrl("/userLogin")
      },
        (errors)=>{
         // if(error instanceof HttpErrorResponse){
         //   if(error.status==400){
        this.validationErrors = errors}
       //  console.log(this.validationErrors);
    )}






}


 // <!-- Passwords must be at least 6 characters.,
      // Passwords must have at least one non alphanumeric character.,
      // Passwords must have at least one lowercase ('a'-'z').,
      // Passwords must have at least one uppercase ('A'-'Z')., -->

 // ['(A-Za-z){3,}']
      ///^(?=(?:\D*\d){2})(?=(?:[^a-z]*[a-z]){2})(?=[^A-Z]*[A-Z])(?=(?:\w*\W){2}).*/gm
      // ^ (?=.*[a-z]) (?=.*[A-Z]) (?=.*\d|\W) (?=.*[\w\S]).{6,}$
     
      // [$@^!%*?&]

// ^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$

// This regular expression checks for the following conditions:

// ^: Start of the string
// (?=.*[a-z]): At least one lowercase letter
// (?=.*[A-Z]): At least one uppercase letter
// (?=.*\d): At least one digit
// (?=.*[@$!%*?&]): At least one non-alphanumeric character
// [A-Za-z\d@$!%*?&]{6,}: 6 or more characters from the allowed character set
// $: End of the string
// You can use this regular expression in the form builder in Angular to validate passwords 
// that meet the given criteria. For example, you can use the Validators.pattern() 
// method to specify this regular expression as the validation pattern for a password input field.

// const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)(?=.*[\w\S]).{6,}$/;
// const password = "Your_password_123!";
// const isValidPassword = passwordRegex.test(password); // true