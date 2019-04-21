import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.scss']
})
export class CarouselComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    this.carousel();
  }

  carousel() {
    var arr1 = [1, 2, 3, 4, 5];
    $("#ad .list li a").each(function (i) {
      $(this).css("background", "url(../../assets/img/" + arr1[i] + ".jpg) no-repeat top center");
    })
    var timer;
    var n = 0;
    var len = $("#ad .list li").length;
    $("#next").click(function () {
      n++;
      if (n > len - 1) {
        n = 0;
      }
      move();

    })
    $("#prev").click(function () {
      n--;
      if (n < 0) {
        n = len - 1;
      }
      move();
    })

    function move() {
      $("#ad .list li").eq(n).fadeIn("slow").siblings().fadeOut("slow");
      $("#ad .icos li").eq(n).addClass("on").siblings().removeClass("on");
    }

    $("#ad .icos li").click(function () {
      var $index = $(this).index();
      $(this).addClass("on").siblings().removeClass("on");
      $("#ad .list li").eq($index).fadeIn("slow").siblings().fadeOut("slow");
      n = $index;
    })

    function play() {
      timer = setTimeout(function () {
        play();
        $("#next").click();
      }, 2500)
    }

    play();

    $('#ad').hover(function () {
      clearInterval(timer);
    }, function () {
      play();
    })
  }
}
