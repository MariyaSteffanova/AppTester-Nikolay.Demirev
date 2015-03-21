var currentElementToScroll;
var currentScrollWidth;

function Scroll()
{
	currentElementToScroll = document.getElementById('main');
	currentScrollWidth = currentElementToScroll.scrollWidth;
	setInterval('scrolling()',500);
}


function scrolling()
{	
	currentElementToScroll.scrollLeft += 10;
	if(currentElementToScroll.scrollLeft >= (currentScrollWidth/2))
	{
		currentElementToScroll.scrollLeft = 0;
	}
}