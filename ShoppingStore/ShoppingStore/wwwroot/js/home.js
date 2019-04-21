function downup(a,b){
	$(a).hover(function(){
	   $(this).addClass("on");
	   $(this).find(b).stop().slideDown();
    },function(){
       $(this).removeClass("on");
	   $(this).find(b).stop().slideUp();
    })
}

downup("header ul .app",".ma");
downup(".tab-nav>li");

// search
function getfocus(){
  var $ul=$(".search-right form ul")
  $(".search-right form .in1").bind({
	   focus:function(){$ul.stop().slideDown();$(this).attr("placeholder","");},
       focusout:function(){$ul.stop().slideUp();$(this).attr("placeholder","What are you looking for?");}
  })

  var $li=$(".search-right form ul li:not(.one)");
  $li.hover(function(){
	 $(this).addClass("on").siblings().removeClass("on")
  })
}

getfocus();
 
 // carousel
function srcoll(){
 	var arr1=[1,2,3,4,5];
    $("#ad .list li a").each(function(i){
   	    $(this).css("background","url(img/"+arr1[i]+".jpg) no-repeat top center");
    })
    var timer;
    var n=0;
    var len=$("#ad .list li").length;
    $("#next").click(function(){  
        n++;  	
    	if (n>len-1) {
    		n=0;
    	}
    	move();
    	
    })
    $("#prev").click(function(){  
        n--;  	
    	if (n<0) {
    		n=len-1;
    	}
    	move();  	
    })

    function move(){
    	$("#ad .list li").eq(n).fadeIn("slow").siblings().fadeOut("slow");
    	$("#ad .icos li").eq(n).addClass("on").siblings().removeClass("on");
    }

    $("#ad .icos li").click(function(){
    	var $index=$(this).index();
    	$(this).addClass("on").siblings().removeClass("on");
    	$("#ad .list li").eq($index).fadeIn("slow").siblings().fadeOut("slow");
    	n=$index;
    })

    function play(){
    	timer=setTimeout(function(){
    		play();
    		$("#next").click();
    	},2500)
    }

    play();

    $('#ad').hover(function(){
    	clearInterval(timer);
    },function(){
    	play();
    })
}

srcoll();


// recommend
$(".mood li").click(function(){
	$(this).addClass("on").siblings().removeClass("on");
	$("#popularity .content").eq($(this).index()).css("display","block").
	siblings(".content").css("display","none")
})


//count down
function lasttime(){
	var  $date=new Date();
	var  $year=$date.getFullYear();
	var  $date2=new Date($year,21,23,59,59,59);
    var  $time1=($date2-$date)/1000;
     $(".hour").html(Math.floor($time1%(24*60*60)/(60*60)));
     $(".minute").html(Math.floor($time1%(24*60*60)%(60*60)/60));
     $(".seconds").html(Math.floor($time1%(24*60*60)%(60*60)%60));
}

lasttime();
setInterval(lasttime,1000);

// shutter
function kaleidoscope() {
    var num = 0;
    $("#j_silder_outer .img-item").each(function (index, el) {
      $(this).css({
        "left": $(this).width() * index + "px",
        /*让每个img-item延时一定时间执行动画*/
        "transitionDelay": index * 0.3 + "s"
      });
      $(this).find(".img").css({
        "backgroundPosition": -$(this).width() * index + "px"
      });;
    });

    $(".btns .prev1").on("click", function () {
      $("#j_silder_outer .img-item").css("transform", "rotateX(" + (++num * 90) + "deg)");
    });

    $(".btns .next1").on("click", function () {
      $("#j_silder_outer .img-item").css("transform", "rotateX(" + (--num * 90) + "deg)");
    });

    var timejg = 4000;//轮播间隔时间
    var time = setInterval(move, timejg);
    function move() {
      $("#j_silder_outer .img-item").css("transform", "rotateX(" + (--num * 90) + "deg)");
    }
    $('.slider-outer').hover(function () {
      clearInterval(time);
    }, function () {
      time = setInterval(move, timejg);
    });
}

kaleidoscope();

(function(){
   AOS.init({
       duration:1000
   });
})()