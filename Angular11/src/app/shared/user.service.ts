import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './user.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';




@Injectable({
  providedIn: 'root'
})
export class UserService {
formUser?:User;
readonly URL='http://localhost:59970/api/Users/'

public userId?:any;

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  
  UserData = this.fb.group({
    userId:[0],
    username: [''],
    password: [''],
    isAdmin: [0]
  });
  

  register() {
    var body = {
      userId: 0,
      username: this.UserData.value.username,
      password: this.UserData.value.password,
      isAdmin: 0
    };
    return this.http.post(this.URL + 'Register', body);
  }

  login(formData:any) {
    
    return this.http.post(this.URL + 'Login', formData);
  }

  //login(formData:any): Observable<any> {
   // const headers = { 'content-type': 'application/json'}  
    //const body=JSON.stringify(formData);
    //console.log(body)
    //return this.http.post(this.URL + 'Login', body,{'headers':headers})
  //}

  getUserProfile() {
    return this.http.get(this.URL + 'UserProfile');
  }

}


