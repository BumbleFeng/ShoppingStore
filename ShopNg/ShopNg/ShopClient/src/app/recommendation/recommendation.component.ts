import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-recommendation',
  templateUrl: './recommendation.component.html',
  styleUrls: ['./recommendation.component.scss']
})
export class RecommendationComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    this.tab();
  }

  tab() {
    $(".mood li").click(function () {
      $(this).addClass("on").siblings().removeClass("on");
      $("#popularity .content").eq($(this).index()).css("display", "block").
        siblings(".content").css("display", "none")
    })
  }

}
