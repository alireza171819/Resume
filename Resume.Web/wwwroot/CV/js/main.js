(function ($) {
	"use strict";

	// Mobile Header Control Function

	function mobileHeaderControl() {

		var $window_Width = $(window).width();
		var $site_header = $("#site_header");

		if($window_Width >= 1024){
			$site_header.addClass("mobile-menu-hide");
			$(".menu-toggle").removeClass("open");
		}
	}

	// Forms

	$(function () {

		// Validator
		$("#contact_form").validator();

		// Contact Form
		$("#contact_form").on("submit", function (e) {

			if (!e.isDefaultPrevented()) {

				var url = "php/contact_form.php";

				$.ajax({
					type: "POST",
					url: url,
					data: $(this).serialize(),
					success: function (data) {

						var $message_alert = 'alert-' + data.type;
						var $message_text = data.message;

						var $alert_box = '<div class="alert ' + $message_alert + ' alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' + $message_text + '</div>';

						if ($message_alert && $message_text) {

							$('#contact_form').find('.messages').html($alert_box);

							if(data.type == 'success'){
								$('#contact_form')[0].reset();
								$('#contact_form .form-group').not(':focus').removeClass("form-group-focus");
							}
						}
					}
				});

				return false;
			}
		});

		// Close message box button
		$(".messages").on("click", ".close", function () {
			$(this).parent().remove();
		});
		
		// Form fields focus control
		$(".form-control").val("").on("focusin", function () {
			$(this).parent(".form-group").addClass("form-group-focus");
		});
		$(".form-control").on("focusout", function () {
			if( $(this).val().length === 0 ){
				$(this).parent(".form-group").removeClass("form-group-focus");
			}
		});

	});

	// Window Load Actions

	$(window).on("load", function () {

		// Preloader
		$(".preloader").fadeOut(800, "linear");

		// Animated Sections
		var $animated_sections = $(".animated-sections");
		if( $animated_sections.length ){
			PageTransitions.init({
				menu: "ul.main-menu"
			});
		}
		
	});
	
	// Window Resize Actions

	$(window).on("resize", function () {
		mobileHeaderControl();
	});

	// Document Ready
	
	$(function () {

		// Background Animation
		var o = 20;
		var i = o / $(document).height();
		var n = o / $(document).width();
		$("body").on("mousemove", function (e) {
			var t = e.pageX - $(document).width() / 2,
				o = e.pageY - $(document).height() / 2,
				s = n * t * -1,
				m = i * o * -1,
				c = $(".lm-animated-bg");
			c.addClass("transition");
			c.css({
				"background-position": "calc( 50% + " + s + "px ) calc( 50% + " + m + "px )"
			});
			setTimeout(function () {
				c.removeClass("transition");
			}, 300);
		});

		// Mobile menu actions
		$(".menu-toggle").on("click", function () {
			$("#site_header").toggleClass("mobile-menu-hide");
			$(".menu-toggle").toggleClass("open");
		});
		
		// Mobile menu control on item click
		$(".main-menu").on("click", "a", function () {
			mobileHeaderControl();
			$(".menu-toggle.open").click();
		});
		
		// Portfolio
		var $portfolio_grid = $(".portfolio-grid");

		if ($portfolio_grid.length) {

			$portfolio_grid.imagesLoaded(function () {

				$portfolio_grid.isotope({
					layoutMode: "masonry",
					itemSelector: "figure",
					originLeft: false
				});

				var $filters = $(".portfolio-filters a.filter");

				$filters.click(function () {

					if ($(this).parent().hasClass("active")){
						return false;
					}

					$filters.parent().removeClass("active");
					$(this).parent().addClass("active");

					var $filter_value = $(this).attr("data-filter");

					$portfolio_grid.isotope({
						filter: $filter_value
					});

					return false;
				});
			});
		}

		// Blog
		var $blog_masonry = $(".blog-masonry");

		if ($blog_masonry.length) {

			$blog_masonry.imagesLoaded(function () {

				$blog_masonry.isotope({
					layoutMode: "masonry",
					itemSelector: ".item",
					originLeft: false
				});
	
				var $filters = $(".blog-filters a.filter");
	
				$filters.click(function () {
					
					if ($(this).parent().hasClass("active")){
						return false;
					}
	
					$filters.parent().removeClass("active");
					$(this).parent().addClass("active");
	
					var $filter_value = $(this).attr("data-filter");

					$blog_masonry.isotope({
						filter: $filter_value
					});
	
					return false;
				});
			});
		}

		// Text Rotation Carousel
		$(".text-rotation").owlCarousel({
			rtl: true,
			loop: true,
			dots: false,
			nav: false,
			margin: 0,
			items: 1,
			autoplay: true,
			autoplayHoverPause: false,
			autoplayTimeout: 3800,
			animateOut: "animated-section-scaleDown",
			animateIn: "animated-section-scaleUp"
		});
		
		// Testimonials Carousel
		$(".testimonials.owl-carousel").owlCarousel({
			rtl: true,
			nav: true,
			loop: false,
			navText: false,
			autoHeight: true,
			margin: 25,
			responsive: {
				0: {
					items: 1
				},
				768: {
					items: 2
				},
				992: {
					items: 1
				},
				1200: {
					items: 2
				}
			}
		});
		
		// Clients Carousel
		var $clients_carousel = $(".clients.owl-carousel");

		$clients_carousel.imagesLoaded(function(){

			$clients_carousel.owlCarousel({
				rtl: true,
				nav: true,
				loop: false,
				navText: false,
				margin: 10,
				autoHeight: true,
				responsive: {
					0: {
						items: 2
					},
					480: {
						items: 3
					},
					768: {
						items: 4
					},
					992: {
						items: 3
					},
					1200: {
						items: 4
					},
					1400: {
						items: 5
					}
				}
			});
		});
		
		// Portfolio Gallery Lightbox
		$.extend(true, $.magnificPopup.defaults, {
			tClose: "بستن",
			tLoading: "در حال بارگذاری ...",
			gallery: {
				tPrev: 'قبلی',
				tNext: 'بعدی',
				tCounter: '%curr% از %total%'
			},
			image: {
				tError: '<a href="%url%">تصویر</a> بارگذاری نشد.'
			},
			ajax: {
				tError: '<a href="%url%">درخواست</a> ناموفق بود.'
			}
		});
		
		$("body").magnificPopup({
			delegate: "a.lightbox",
			type: "image",
			removalDelay: 300,
			mainClass: "mfp-fade",
			gallery: {
				enabled: true
			},
			image: {
				titleSrc: "title"
			},
			iframe: {
				markup: '<div class="mfp-iframe-scaler"><div class="mfp-close"></div><iframe class="mfp-iframe" frameborder="0" allowfullscreen></iframe><div class="mfp-bottom-bar mfp-iframe-bottom-bar"><div class="mfp-title"></div><div class="mfp-counter"></div></div></div>',
				patterns: {
					youtube: {
						index: "youtube.com/",
						id: null,
						src: "%id%?autoplay=1"
					},
					vimeo: {
						index: "vimeo.com/",
						id: "/",
						src: "//player.vimeo.com/video/%id%?autoplay=1"
					},
					gmaps: {
						index: "//maps.google.",
						src: "%id%&output=embed"
					}
				},
				srcAction: "iframe_src"
			},
			callbacks: {
				markupParse: function (template, values, item) {
					values.title = item.el.attr("title");
				}
			}
		});

	});

})(jQuery);