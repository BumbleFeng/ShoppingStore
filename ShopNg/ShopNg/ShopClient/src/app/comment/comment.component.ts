import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    this.comment();
  }

  comment() {
    var con = $(".show-box ul li:lt(3)").clone();
    var $ul = $(".show-box ul");
    $ul.append(con);
    var $li = $(".show-box ul li");
    var length = $li.length;
    $ul.css("width", 367 * length + "px");
    var n = 0;
    $(".show .next").click(function () {
      n++;
      if (n > length - 3) {
        n = 1;
        $ul.css("left", 0)
      };
      $ul.stop().animate({ "left": -n * 367 + "px" }, 600)
    })
    $(".show .prev").click(function () {
      n--;
      if (n < 0) {
        n = length - 4;
        $ul.css("left", -(length - 3) * 367 + "px")
      };
      $ul.stop().animate({ "left": -n * 367 + "px" }, 600)
    })

    var timer;
    function play() {
      timer = setTimeout(function () {
        play();
        $(".show .next").click();
      }, 2000)
    }

    play();

    $(".show").hover(function () {
      clearInterval(timer);
    }, function () {
      play();
    })

  }

}
