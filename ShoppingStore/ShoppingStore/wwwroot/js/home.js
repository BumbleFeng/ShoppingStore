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

// comment

function talk(){
	
	var con=$(".show-box ul li:lt(3)").clone();
	var $ul=$(".show-box ul");
	$ul.append(con);
	var $li=$(".show-box ul li");
	var length=$li.length;
    $ul.css("width",367*length+"px");
    var n=0;
    $(".show .next").click(function(){
    	n++;
        if (n>length-3) {
        	n=1;
        	$ul.css("left",0)
        };
    	$ul.stop().animate({"left":-n*367+"px"},600)
    })
    $(".show .prev").click(function(){
    	n--;
        if (n<0) {
        	n=length-4;
        	$ul.css("left",-(length-3)*367+"px")
        };
    	$ul.stop().animate({"left":-n*367+"px"},600)
    })

    var timer;
    function play(){
    	timer=setTimeout(function(){
    		play();
    		$(".show .next").click();
    	},2000)
    }

    play();

    $(".show").hover(function(){
    	clearInterval(timer);
    },function(){
    	play();
    })

}

talk();

(function(){
   AOS.init({
       duration:1000
   });
})()