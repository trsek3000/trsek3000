import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrModule, ToastrService } from 'ngx-toastr';

import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styles: [
  ]
})
export class UserLoginComponent implements OnInit {
  formModel = {
    username: '',
    password: ''
  }

  public UserId : any;
  constructor(private service: UserService, private router: Router, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
     this.service.login(form.value).subscribe(
      (res: any) => {
        this.toastr.success('Welcome.', 'Authentication Passed.');
        this.service.userId = res.userId
       
        
        this.router.navigateByUrl('/products');

      },
      err => {
        if (err.status == 400)
          this.toastr.error('Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
      }
    );
   
  }

}
