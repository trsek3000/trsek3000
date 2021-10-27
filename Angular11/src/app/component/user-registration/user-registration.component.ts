import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-user-registeration',
  templateUrl: './user-registration.component.html',
  styles: [
  ]
})
export class UserRegisterationComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService, private router:Router) { }

  ngOnInit(): void {
    
  }


  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
      
        this.service.UserData.reset();
          this.toastr.success('New user created!', 'Registration successful.');
          this.router.navigateByUrl('user-login')
          console.log('here');
      }
    );
  }


}
