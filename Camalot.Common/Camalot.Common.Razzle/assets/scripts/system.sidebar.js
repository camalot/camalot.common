(function ($, mouseTrap) {
	"use strict";
	$(function () {

		$(".root.container").each(function (idx, item) {
			var self = $(item);
			var nav = $(".razzle-nav");
			if (!nav.hasClass("left") && !nav.hasClass("right")) {
				throw new Error("Navigation is not setup correctly. Missing direction");
			}
			var isLeft = nav.hasClass("left");

			// init the root container
			self.addClass(isLeft ? "left" : "right");
		});

		// wire up the popovers
		$("[data-toggle='popover']").each(function () {
			var self = $(this);
			if (self.data("popover-setup")) {
				return;
			}
			self.data("popover-setup", true);
			self.popover();
		});

		// toggle the open/close
		$(".razzle-nav-toggle").on("click", function () {
			var self = $(this);
			var target = $(self.data("razzle-target"));
			var toggle = self.data("razzle-toggle");
			var collapsed = "collapsed";
			if (target.hasClass(toggle)) {
				target.removeClass(toggle).addClass(collapsed);
				self.parent().removeClass(toggle).addClass(collapsed);
				self.attr("title", "Open");

				// find root container
				$(".root.container").removeClass("razzle-nav-expanded");
			} else {
				target.removeClass(collapsed).addClass(toggle);
				self.parent().removeClass(collapsed).addClass(toggle);
				// find root container
				$(".root.container").addClass("razzle-nav-expanded");
				self.attr("title", "Close");
			}
			self.trigger("click.razzle-mousetrap");
		});

		// filter the navigation with what is typed in the search field
		$(".razzle-nav .nav-search input.search-field").on("keyup reset.razzle-search", function (event) {
			var self = $(this);
			var $list = $(self).closest("ul.nav");
			var items = $("li", $list).not(".no-filter");
			var value = $(this).val();
			var $clear = $(".razzle-nav .nav-search button.clear");
			$clear.trigger(value && value.length > 0 ? "show-clear.razzle-search" : "hide-clear.razzle-search");
			items.each(function () {
				var s = $(this);
				if (s.text().toLowerCase().search(value.toLowerCase()) > -1 || (!value || value.length == 0)) {
					s.removeClass("hidden");
				} else {
					s.addClass("hidden");
				}
			});
		});

		// this clears the search box and resets the navigation
		$(".razzle-nav .nav-search button.clear").on("click", function (event) {
			$(".razzle-nav .nav-search input.search-field").val("").trigger("reset.razzle-search");
		}).on("show-clear.razzle-search", function (event) {
			var $t = $(this);
			var clearTitle = $t.data("clear-title") || "Clear";
			var clearIcon = $t.data("clear-icon") || "fa-close";
			var searchIcon = $t.data("search-icon") || "fa-search";
			$t.removeClass(searchIcon).addClass(clearIcon).attr("title", clearTitle);
		}).on("hide-clear.razzle-search", function (event) {
			var $t = $(this);
			var searchTitle = $t.data("search-title") || "Search";
			var clearIcon = $t.data("clear-icon") || "fa-close";
			var searchIcon = $t.data("search-icon") || "fa-search";
			$t.removeClass(clearIcon).addClass(searchIcon).attr("title", searchTitle);
		});

		// set up scrollspy on the body
		$("body").scrollspy({ target: ".razzle-nav .nav", offset: 100 });

		// smooth scrolling if the jquery scrollTo plugin exists.
		$(".razzle-nav .nav li a[data-scroll]").each(function () {
			var self = $(this);
			if (self.data("scroll-setup")) { return; }
			self.data("scroll-setup", true);
			var trigger = self.data("scroll") || "click";
			self.on(trigger, function (event) {
				if ($.scrollTo) {
					var $s = $(this);
					var topOffset = parseInt($s.data("scroll-offset"), 0);
					var target = $(this.hash);
					$.scrollTo(target, { duration: 1000, offset: topOffset });
					event.preventDefault();
				}
			});
		});



		// if you have mousetrap (http://craig.is/killing/mice) loaded, endpointMVC will bind some events
		if (mouseTrap) {
			// change the input to have the mouse bindings:
			var field = $(".razzle-nav.expanded .nav-search input.search-field");
			var currentPH = field.attr("placeholder");
			field.attr("placeholder", currentPH + " (Ctrl+Q)");

			// change the title of open/close with ctrl+left/ctrl+right on the click trigger
			$(".razzle-nav-toggle").on("click.razzle-mousetrap", function () {
				$(".expanded.left .razzle-nav-toggle").attr("title", "Close (Ctrl+Left)");
				$(".collapsed.right .razzle-nav-toggle").attr("title", "Open (Ctrl+Left)");
				$(".collapsed.left .razzle-nav-toggle").attr("title", "Open (Ctrl+Right)");
				$(".expanded.right .razzle-nav-toggle").attr("title", "Close (Ctrl+Right)");
			}).trigger("click.razzle-mousetrap");

			mouseTrap.bind("ctrl+q", function (e) {
				// bind ctrl+q to focus the search box
				$(".razzle-nav.expanded .nav-search input.search-field").focus();
			}).bind("ctrl+left", function (e) {
				// bind ctrl+left and either open or close the navigation (depending on the location)
				$(".expanded.left .razzle-nav-toggle").trigger("click").attr("title", "Open (Ctrl+Right)");
				$(".collapsed.right .razzle-nav-toggle").trigger("click").attr("title", "Close (Ctrl+Right)");
			}).bind("ctrl+right", function (e) {
				// bind ctrl+right and either open or close the navigation (depending on the location)
				$(".expanded.right .razzle-nav-toggle").trigger("click").attr("title", "Open (Ctrl+Left)");
				$(".collapsed.left .razzle-nav-toggle").trigger("click").attr("title", "Close (Ctrl+Left)");
			});
		}
	});
})(window.jQuery, window.Mousetrap);