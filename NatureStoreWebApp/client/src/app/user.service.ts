import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl = 'https://localhost:44399/api/ApplicationUser/Register';
  
  formModel = this.fb.group({
      UserName:['', Validators.required],
      Email:['', Validators.email],
      FullName:[''],

      Passwords:this.fb.group({
        Password:['', [Validators.required, Validators.minLength(4)]],
        ConfirmPassword:['', Validators.required]
      },{validator:this.comparePasswords})
     
  });

  comparePasswords(fb:FormGroup)
  {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');

    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl.setErrors(null);
    }

  }

  constructor(private http: HttpClient, private fb:FormBuilder) { }


  register():Observable<Object>{
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    };

    return this.http.post(`${this.baseUrl}`, body);
  }
}
