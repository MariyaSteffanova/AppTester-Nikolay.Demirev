var name;

function AskForUserName()
{
	name = prompt("What is your name");
	
	var is_chrome = navigator.userAgent.toLowerCase().indexOf('chrome') > -1;
	
	if( is_chrome === true)
	{
		window.onbeforeunload = function () 
		{ 
			return "Goodbye " + name + "!"; 
		};
	}
	else
	{
		window.onbeforeunload = SayGoodbye;
	}	
}

function SayGoodbye()
{	
	msg = "Goodbye " + name + "!";
	alert(msg);
}
