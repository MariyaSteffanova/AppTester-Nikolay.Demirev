var currentElementToScroll;
var currentScrollWidth;

function startScroll()
{
	currentElementToScroll = document.getElementById('main');
	currentScrollWidth = currentElementToScroll.scrollWidth;
	setInterval('scroll()',500);
}


function scroll()
{	
	currentElementToScroll.scrollLeft += 10;
	if(currentElementToScroll.scrollLeft >= (currentScrollWidth/2))
	{
		currentElementToScroll.scrollLeft = 0;
	}
}