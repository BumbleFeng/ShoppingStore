import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import * as $ from 'jquery';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from '../shared/services/user.service';
import { ItemService } from '../shared/services/item.service';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public username: string;
  private subscription: Subscription;

  constructor(private router: Router, private userService: UserService ) {
    this.subscription = this.userService.getUsername().subscribe(msg => {
      this.username = msg;
    })
  }

  logout() {
    localStorage.clear();
    this.userService.clearUsername();
    this.router.navigate(['/login']);
  }

  error(){
    throw new Error('error');
  }

  ngOnInit() {
    this.scrolldown("header ul .app", ".ma");
    this.scrolldown(".tab-nav>li", ".nav-down")
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  scrolldown(a, b) {
    $(a).hover(function () {
      $(this).addClass("on");
      $(this).find(b).stop().slideDown();
    }, function () {
      $(this).removeClass("on");
      $(this).find(b).stop().slideUp();
    })
  }

}
