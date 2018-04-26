$(document).ready(function(){
	$.ajax({
		url: "menu.html",
		success: function( data ) {
			$('#menu').append(data);
		}
	})
})