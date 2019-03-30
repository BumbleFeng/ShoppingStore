function billingAsShipping() {
    $("#billingCheck").click(function(){
        $("#billing").toggle();
        var checkBox = document.getElementById("billingCheck");
        if(checkBox.checked == true){
            $(".billingInput").removeAttr('required');
        }
        else{
            $(".billingInput").attr('required', '');
        }
	});
}
billingAsShipping();