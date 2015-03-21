function createDivs()
{
	var width = window.innerWidth;
	var height = window.innerHeight;
	
	for(var i=0; i < 20; i++ )
	{
		var divTag = document.createElement("div"); 
 
		divTag.id = "div" + i; 
		
		divTag.style.height = Math.floor(Math.random() * height/5) + 'px';
		divTag.style.width = Math.floor(Math.random() * width/5) + 'px';
		
		divTag.style.marginTop = Math.floor(Math.random() * height) + 'px';
		divTag.style.marginLeft = Math.floor(Math.random() * width) + 'px';
		
		divTag.style.zIndex = i;

		divTag.style.backgroundColor =  "#" +Math.floor(Math.random() * 0xFFFFFF).toString(16);

		document.body.appendChild(divTag); 
	}
}