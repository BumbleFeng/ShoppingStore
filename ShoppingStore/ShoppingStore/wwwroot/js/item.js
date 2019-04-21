// pic part
$(".slide .s-list li").hover(function(){
	$(this).addClass("active").siblings().removeClass("active");
	$(".slide .view img").eq($(this).index()).fadeIn().siblings().fadeOut();
})


function name(){
    var c=true;
    $(".param .tab").click(function(){
	    if (c) {
		   $(this).addClass("on")
		   c=false;
	   }else{
		   $(this).removeClass("on")
		   c=true;
	  }
	
    })
}

 name();

function number(){
	var n=1;
	$(".selnum .add").click(function(){
        n++;
        $(".selnum input").val(n)
  })

	$(".selnum .remove").click(function(){
        n--;
        if (n<1) {
        	n=1;
        };
        $(".selnum input").val(n)
  })

}
 number();

 function getleft(){
     $(".m-slick .next").click(function(){
     	$(".slickcontent ul").stop().animate({"left":"-960px"},800)
     })

     $(".m-slick .prev").click(function(){
     	$(".slickcontent ul").stop().animate({"left":"0px"},800)
     })
 }

 getleft();

 function change(a,b,c){
 	$(a).click(function(){
 		$(this).addClass("on").siblings().removeClass("on");
 		$(b).eq($(this).index()).show().siblings(c).hide();
 	})
 }

 change(".nav-tab li",".evaluate .details",".details");
 change(".comment-nav .w-radio",".comment-empty .wrap",".wrap")

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