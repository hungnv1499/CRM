(function ($) {
	"use strict";

		var $window = $(window);
		$window.on('scroll', function() {    
			var scroll = $window.scrollTop();
			if (scroll < 300) {
				$(".sticker").removeClass("sticky");
			}else{
				$(".sticker").addClass("sticky");
			}
		});

		jQuery('#mobile-menu').meanmenu({
			meanMenuContainer: '.mobile-menu',
			meanScreenWidth: "991"
		}); 

		// nice select active js
		$('select').niceSelect();

		// initial tooltip js
		tippy('.toooltip',{
			arrow: true,
		});

		// Initial wow js
		new WOW().init();


		// home slider
		var heroSlider = $('.home-slider');
		heroSlider.slick({
		    arrows: false,
		    autoplay: false,
		    autoplaySpeed: 5000,
		    dots: true,
		    pauseOnFocus: false,
		    pauseOnHover: false,
		    fade: true,
		    infinite: true,
		    slidesToShow: 1,
		    responsive: [
		        {
		          breakpoint: 767,
		          settings: {
		            dots: true,
		          }
		        }
		    ]
		});

		// prodct details slider active
		$('.shop-large-slider').slick({
			slidesToShow: 1,
			slidesToScroll: 1,
			prevArrow: '<button type="button" class="arrow-prev"><i class="fa fa-long-arrow-left"></i></button>',
			nextArrow: '<button type="button" class="arrow-next"><i class="fa fa-long-arrow-right"></i></button>',
			fade: true,
			arrows: false,
			asNavFor: '.shop-nav'
		});

		$('.shop-nav').slick({
			slidesToShow: 4,
			slidesToScroll: 1,
			prevArrow: '<button type="button" class="arrow-prev"><i class="fa fa-long-arrow-left"></i></button>',
			nextArrow: '<button type="button" class="arrow-next"><i class="fa fa-long-arrow-right"></i></button>',
			asNavFor: '.shop-large-slider',
			centerMode: false,
			focusOnSelect: true
		});


		// product slider active
		var product = $('.product-slider');
		    product.owlCarousel({
	        items: 3,
	        loop: true,
	        margin: 30,
	        nav:true,
	        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
	        autoplay: false,
	        stagePadding: 0,
	        smartSpeed: 700,
	        responsive:{
				 0:{
		            items:1
		        },

		        480:{
		            items:2
		        },
		 
		        768:{
		            items:2
		        },

		        992:{
		            items:3
		        },

		       1100:{
		            items:3
		        }
		    }
		});

		var product2 = $('.product-slider-2');
		    product2.owlCarousel({
	        items: 4,
	        loop: true,
	        margin: 30,
	        nav:true,
	        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
	        autoplay: false,
	        stagePadding: 0,
	        smartSpeed: 700,
	        responsive:{
				 0:{
		            items:1
		        },

		        480:{
		            items:2
		        },
		 
		        768:{
		            items:3
		        },

		        992:{
		            items:4
		        },

		       1100:{
		            items:4
		        }
		    }
		});

		var feature = $('.product-feature');
		    feature.owlCarousel({
	        items: 5,
	        loop: true,
	        margin: 30,
	        nav:true,
	        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
	        autoplay: true,
	        stagePadding: 0,
	        smartSpeed: 700,
	        responsive:{
				 0:{
		            items:1
		        },

		        480:{
		            items:2
		        },
		 
		        768:{
		            items:3
		        },

		        992:{
		            items:4
		        },

		       1100:{
		            items:5
		        }
		    }
		});

		var producttab = $('.category-tab-active');
		    producttab.owlCarousel({
	        items: 4,
	        loop: true,
	        margin: 30,
	        nav:true,
	        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
	        autoplay: false,
	        stagePadding: 0,
	        smartSpeed: 700,
	        responsive:{
				 0:{
		            items:1
		        },

		        480:{
		            items:2
		        },
		 
		        768:{
		            items:3
		        },

		        992:{
		            items:4
		        },

		       1100:{
		            items:4
		        }
		    }
		});


		// blog carousel
		var blog = $('.blog-slider');
		    blog.owlCarousel({
	        items: 3,
	        loop: true,
	        margin: 30,
	        dots:true,
	        nav:true,
	        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
	        autoplay: true,
	        stagePadding: 0,
	        smartSpeed: 1200,
	        responsive:{
				 0:{
		            items:1
		        },

		        480:{
		            items:1
		        },
		 
		        768:{
		            items:2
		        },

		        992:{
		            items:3
		        },

		       1100:{
		            items:3
		        }
		    }
		});

		$('.blog-thumb-active').owlCarousel({
	        autoplay: true,
			loop: true,
	        nav: true,
	        autoplay: false,
	        autoplayTimeout: 8000,
	        items: 1,
	        navText: ['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
	        dots:true,
	    });

		// brand slider active
		var brand = $('.brand-logo-slider');
		    brand.owlCarousel({
	        items: 5,
	        dots: true,
	        margin: 0,
	        loop: true,
	        nav:true,
	        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
	        autoplay: true,
	        stagePadding: 0,
	        smartSpeed: 700,
	        responsive:{
				 0:{
		            items:1
		        },

		        480:{
		            items:3
		        },
		 
		        768:{
		            items:4
		        },

		        992:{
		            items:5
		        }
		    }
		});


		// testimonial carousel
		var testimonial = $('.testimonial-carousel');
		    testimonial.owlCarousel({
	        items: 1,
	        loop: true,
	        margin: 30,
	        dots:true,
	        autoplay: true,
	        stagePadding: 0,
	        autoHeight: true,
	        smartSpeed: 1200
		});

		var testimonial2 = $('.testimonial-carousel-2');
		    testimonial2.owlCarousel({
	        items: 1,
	        loop: true,
	        margin: 30,
	        dots:true,
	        autoplay: true,
	        stagePadding: 0,
	        autoHeight: true,
	        smartSpeed: 1200
		});

		// portfolio slider active
		var portfolio = $('.portfolio-project-active');
		    portfolio.owlCarousel({
	        items: 4,
	        loop: true,
	        margin: 30,
	        nav:true,
	        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
	        autoplay: false,
	        stagePadding: 0,
	        smartSpeed: 700,
	        responsive:{
				 0:{
		            items:1
		        },

		        480:{
		            items:2
		        },
		 
		        768:{
		            items:3
		        },

		        992:{
		            items:4
		        },

		       1100:{
		            items:4
		        }
		    }
		});


		// pricing filter
		$( "#price-slider" ).slider({
	   	range: true,
	  	 min: 0,
	   	max: 120,
	   	values: [ 20, 115 ],
	   	slide: function( event, ui ) {
	        $( "#min-price" ).val('$' + ui.values[ 0 ] );
	        $( "#max-price" ).val('$' + ui.values[ 1 ] );
	     	}
	  	});
	  	$( "#min-price" ).val('$' + $( "#price-slider" ).slider( "values", 0 ));   
	  	$( "#max-price" ).val('$' + $( "#price-slider" ).slider( "values", 1 )); 


	  	//Product Quantity 
		$('.product-quantity').append('<span class="dec qtybtn"><i class="fa fa-minus"></i></span><span class="inc qtybtn"><i class="fa fa-plus"></i></span>');
		$('.qtybtn').on('click', function() {
		    var $button = $(this);
		    var oldValue = $button.parent().find('input').val();
		    if ($button.hasClass('inc')) {
		        var newVal = parseFloat(oldValue) + 1;
		    } else {
		        // Don't allow decrementing below zero
		        if (oldValue > 0) {
		            var newVal = parseFloat(oldValue) - 1;
		        } else {
		            newVal = 0;
		        }
		    }
		    $button.parent().find('input').val(newVal);
		});


		// counter up
		$('.counter').counterUp({
		    delay: 10,
		    time: 2000
		});


		// google map
		function gmap() {
	        var mapOptions = {
	            // How zoomed in you want the map to start at (always required)
	            zoom: 11,
	            scrollwheel: false,
	            // The latitude and longitude to center the map (always required)
                center: new google.maps.LatLng(10.898270, 106.572343), // New York
	            // This is where you would paste any style found on Snazzy Maps.
	            styles: [{ "featureType": "water", "elementType": "geometry", "stylers": [{ "color": "#e9e9e9" }, { "lightness": 17 }] }, { "featureType": "landscape", "elementType": "geometry", "stylers": [{ "color": "#f5f5f5" }, { "lightness": 20 }] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "color": "#ffffff" }, { "lightness": 17 }] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "color": "#ffffff" }, { "lightness": 29 }, { "weight": .2 }] }, { "featureType": "road.arterial", "elementType": "geometry", "stylers": [{ "color": "#ffffff" }, { "lightness": 18 }] }, { "featureType": "road.local", "elementType": "geometry", "stylers": [{ "color": "#ffffff" }, { "lightness": 16 }] }, { "featureType": "poi", "elementType": "geometry", "stylers": [{ "color": "#f5f5f5" }, { "lightness": 21 }] }, { "featureType": "poi.park", "elementType": "geometry", "stylers": [{ "color": "#dedede" }, { "lightness": 21 }] }, { "elementType": "labels.text.stroke", "stylers": [{ "visibility": "on" }, { "color": "#ffffff" }, { "lightness": 16 }] }, { "elementType": "labels.text.fill", "stylers": [{ "saturation": 36 }, { "color": "#333333" }, { "lightness": 40 }] }, { "elementType": "labels.icon", "stylers": [{ "visibility": "off" }] }, { "featureType": "transit", "elementType": "geometry", "stylers": [{ "color": "#f2f2f2" }, { "lightness": 19 }] }, { "featureType": "administrative", "elementType": "geometry.fill", "stylers": [{ "color": "#fefefe" }, { "lightness": 20 }] }, { "featureType": "administrative", "elementType": "geometry.stroke", "stylers": [{ "color": "#fefefe" }, { "lightness": 17 }, { "weight": 1.2 }] }]
	        };
	        // We are using a div with id="map" seen below in the <body>
	        var mapElement = document.getElementById('contact-map');

	        // Create the Google Map using our element and options defined above
	        var map = new google.maps.Map(mapElement, mapOptions);

	        // Let's also add a marker while we're at it
	        var marker = new google.maps.Marker({
                position: new google.maps.LatLng(10.898270, 106.572343),
	            map: map,
	            animation: google.maps.Animation.BOUNCE
	        });
	    }
	    if ($('#contact-map').length != 0) {
	        google.maps.event.addDomListener(window, 'load', gmap);
	    }

	    // magnificPopup img view 
		$('.port-popup,.port-popupp').magnificPopup({
			type: 'image',
			gallery: {
			  enabled: true
			}
		});

		// magnificPopup video view
		$('.play-btn').magnificPopup({
            type: 'iframe'
        });

		// isotop filtering
        $('.portfolio-gallery').imagesLoaded( function() {
        // init Isotope
        var $grid = $('.portfolio-gallery').isotope({
           itemSelector: '.gird-item',
            percentPosition: true,
            masonry: {
                columnWidth: '.gird-item'
            }
        });
            
        // filter items on button click
        $('.portfolio-tab-button').on( 'click', 'button', function() {
	         var filterValue = $(this).attr('data-filter');
	          	$grid.isotope({ filter: filterValue });
	            
	           	$(this).siblings('.active').removeClass('active');
	          	 $(this).addClass('active');
	        });
	    });


        // modal prefix js
        $('.modal').on('shown.bs.modal', function (e) {
			$('.shop-large-slider').resize();
		})

        // menu toggler
		function menuToggler() {
        var trigger = $('.menu-active-btn'),
            container = $('.menu-active');


        trigger.on('click', function (e) {
            e.preventDefault();
            container.toggleClass('is-visible');
        });

        $('.close-wrap').on('click', function () {
            container.removeClass('is-visible');
        });
	    }
	    menuToggler();


	    $('#mc-form').ajaxChimp({
			language: 'en',
			callback: mailChimpResponse,
			// ADD YOUR MAILCHIMP URL BELOW HERE!
			url: 'http://devitems.us11.list-manage.com/subscribe/post?u=6bbb9b6f5827bd842d9640c82&amp;id=05d85f18ef'

		});


	    // mailchimp active js
		function mailChimpResponse(resp) {
			if (resp.result === 'success') {
				$('.mailchimp-success').html('' + resp.msg).fadeIn(900);
				$('.mailchimp-error').fadeOut(400);

			} else if (resp.result === 'error') {
				$('.mailchimp-error').html('' + resp.msg).fadeIn(900);
			}
		}


	    // scroll to top
	    $(window).on('scroll',function(){
		    if($(this).scrollTop() > 600){
		        $('.scroll-top').removeClass('not-visible');
		    }
		    else{
		        $('.scroll-top').addClass('not-visible');
		    }
		});
	    $('.scroll-top').on('click',function (event){
	        $('html,body').animate({
	            scrollTop:0
	        },1000);
	    });


})(jQuery);	