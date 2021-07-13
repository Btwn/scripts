window.onload = function () {
	loadScript("https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js?ver=1.7.2", scrollTagCourse); 
}

function scrollTagCourse()
{
	jQuery(document).ready(function () {
		
		loadDesktopTag();

	});
}

function loadDesktopTag(){
	jQuery(".page").prepend('<div id="curso-tag" style="width: 87px; height: 151px; position:absolute; left:-86px;"><a href="http://woodward.lingualia.com"><img src="images/tag.png"/></a></div>');
			
	jQuery(function () {
		var offset = jQuery("#curso-tag").offset();
		var topPadding = 15;
		jQuery(window).scroll(function () {
			if (jQuery(window).scrollTop() > offset.top) {
				jQuery("#curso-tag").stop().animate({
					marginTop: jQuery(window).scrollTop() - offset.top + topPadding + 25
				});
			} else {
				jQuery("#curso-tag").stop().animate({
					marginTop: 0 + 75
				});
			};
		});
	});
}



function loadScript(url, callback)
{
    // Adding the script tag to the head as suggested before
    var head = document.getElementsByTagName('head')[0];
    var script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = url;

    // Then bind the event to the callback function.
    // There are several events for cross browser compatibility.
    script.onreadystatechange = callback;
    script.onload = callback;

    // Fire the loading
    head.appendChild(script);
}

/*jQuery( window ).resize(function() {
  jQuery( "#log" ).append( "<div>Handler for .resize() called.</div>" );
});*/