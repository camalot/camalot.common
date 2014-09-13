(function ($) {
	"use strict";
	$(function () {
		$.ajax({
			url: "https://api.github.com/repos/camalot/camalot.common",
			success: function (data) {
				$("[data-github]").each(function () {
					var s = $(this);
					if (s.data("github-setup")) { return; }
					s.data("github-setup", true);
					s.html(data[s.data("github")]);
				})
			}
		})
	})
})(window.jQuery);