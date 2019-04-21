function number(){

    $(".selnum .add").each(function(index){
      $(this).on("click",function(){
        var n= $(this).prev().val();
        n++;
        $(this).prev().val(n);
      });
    });

  $(".selnum .remove").each(function(index){
    $(this).on("click",function(){
      var n= $(this).next().val();
      n--;
      if (n<0) {
        n=0;
      };
      $(this).next().val(n);
    });
  });

}
number();