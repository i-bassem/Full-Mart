

//Cross-Field custom validator

import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

//Higher Order Function that Returns a function
export function passwordMatch(): ValidatorFn{

    return (control:AbstractControl ) : ValidationErrors|null=>{ 
        
        let password = control.get('password');
        let confirmPassword = control.get('confirmPassword');

        if(!password || !confirmPassword || !password.value || !confirmPassword.value){return null}

        let ValidationErrors={'UnmatchedPassword' : {'pass':password?.value , 'cofirmPass':confirmPassword?.value}}
        return (password?.value==confirmPassword?.value)? null : ValidationErrors 
        
        }
}


