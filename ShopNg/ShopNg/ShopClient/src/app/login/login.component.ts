import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { User } from '../shared/models/user';
import { Router } from '@angular/router';
import { isString } from 'util';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public user: User = new User();

  constructor(private router: Router, private userService: UserService) { }

  ngOnInit() {
  }

  login() {
    this.userService.login(this.user)
      .subscribe(token => {
        if (isString(token)) {
          localStorage.setItem('token', token.toString());
          this.router.navigate(['/home']);
        }else{
          this.user = new User();
        }
      });
  }

}
