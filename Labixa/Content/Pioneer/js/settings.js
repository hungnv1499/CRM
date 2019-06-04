jQuery(function($){

var LOVETRAVEL = window.LOVETRAVEL || {};

//Scroll navigation
LOVETRAVEL.scrolltop = function(){
	
	$(".backtotop a").click(function(event){

		event.preventDefault();
		var full_url = this.href;
		var parts = full_url.split("#");
		var trgt = parts[1];
		var target_offset = $("#"+trgt).offset();
		var target_top = target_offset.top;
	
		$('html,body').animate({scrollTop:target_top -13}, 900);
	
	});
}
//End Scroll navigation

//start left menu
LOVETRAVEL.leftmenu = function(){
	
	$(document).ready(function(){
						
		$('.leftmenuclose').click(function(event){
			$('.leftmenuopen').css({
				'left': '0px',
			});
		});
		
		$('.titlecloseleftmenu').click(function(event){
			$('.leftmenuopen').css({
				'left': '-305px'
			});
		});
		
		$(".leftmenuopen").niceScroll({
			touchbehavior:false,
			cursoropacitymax:1,
			cursorwidth:0,
			autohidemode:false,
			cursorborder:0
		});
		
	});
	
}
//end left menu

//start right search
LOVETRAVEL.rightsearch = function(){
	
	$(document).ready(function(){
						
		$('.rightsearchclose').click(function(event){
			$('.rightsearchopen').css({
				'right': '0px',
			});
		});
		
		$('.rightsearchopenclose').click(function(event){
			$('.rightsearchopen').css({
				'right': '-305px'
			});
		});
		
	});
	
}
//end right search

//start inview
LOVETRAVEL.homeinview = function(){
	
	$(document).ready(function(){
		
		
		//disable on mobile
		var windowWidth = $(window).width(); 
		
		if (windowWidth < 400){
			
			$('.fade-left, .fade-up, .fade-down, .fade-right, .bounce-in, .rotate-In-Down-Left, .rotate-In-Down-Right').css('opacity','1');
				
		}else{
			
			$('.fade-up').bind('inview', function(event, visible) {
				if (visible == true) {
					$(this).addClass('animated fadeInUp');
				} 
			});
			
			
			$('.fade-down').bind('inview', function(event, visible) {
				if (visible == true) {
					$(this).addClass('animated fadeInDown');
				}
			});
			
	
			$('.fade-left').bind('inview', function(event, visible) {
				if (visible == true) {
					$(this).addClass('animated fadeInLeft');
				}
			});
			
			
			$('.fade-right').bind('inview', function(event, visible) {
				if (visible == true) {
					$(this).addClass('animated fadeInRight');
				}
			});
			
			
			$('.bounce-in').bind('inview', function(event, visible) {
				if (visible == true) {
					$(this).addClass('animated bounceIn');
				}
			});
			
			
			$('.rotate-In-Down-Left').bind('inview', function(event, visible) {
				if (visible == true) {
					$(this).addClass('animated rotateInDownLeft');
				}
			});
			
			$('.rotate-In-Down-Right').bind('inview', function(event, visible) {
				if (visible == true) {
					$(this).addClass('animated rotateInDownRight');
				}
			});	
		
		}

	});
	
}
//end inview

//start menu superfish
LOVETRAVEL.menusuperfish = function(){
	
	$(document).ready(function(){				
		var example = $('#nav').superfish({
			//add options here if required
		});
	});
	
}
//end menu superfish

//start  responsive navigation
LOVETRAVEL.responsivenavigation = function(){

	jQuery(document).ready(function() {

		$(function () {
		  $('#nav').tinyNav({
			active: 'selected',
			header: 'Menu'
		  });
		});	   

	});
	
}
//end responsive navigation

//start tweets
LOVETRAVEL.latesttweets = function(){

	jQuery(document).ready(function() {
    
		$(function() {

			$('#tweets').twitterFeed({
				url: 'http://www.nicdarkthemes.com/themes/love-travel/html/demo/js/twitter/twitterfeed.php' //insert here your twitterfeed.php url, see the documentation
			});

		});
	  
    });
	
}
//end tweets

//init
LOVETRAVEL.scrolltop();
LOVETRAVEL.leftmenu();
LOVETRAVEL.rightsearch();
LOVETRAVEL.homeinview();
LOVETRAVEL.menusuperfish();
LOVETRAVEL.responsivenavigation();
LOVETRAVEL.latesttweets();
//end init

});