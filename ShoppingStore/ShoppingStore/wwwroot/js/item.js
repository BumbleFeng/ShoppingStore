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
