import { Component, OnInit } from '@angular/core';
import { User } from '../shared/models/user';
import { Router } from '@angular/router';
import { UserService } from '../shared/services/user.service';
import { isString } from 'util';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public user: User = new User();
  
  constructor(private router: Router, private userService: UserService) { }

  ngOnInit() {
  }

  register() {
    console.log(this.user);
    this.userService.register(this.user)
      .subscribe(id => {
        if (isString(id)) {
          this.router.navigate(['/login']);
        }
      });
  }
}
