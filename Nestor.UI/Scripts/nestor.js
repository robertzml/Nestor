/* nestor scripts */
var nestor = function () {

	return {
		showMessage: function(text) {
			var n = noty({
				text: text,
				type: 'information',
				timeout: 1000
			});
		},
		
		leftNavActive: function($dom) {
			var parent = $dom.parent();
			parent.addClass('active active-parent');
			
			var li = $dom.closest('li.dropdown');
			li.find("ul.dropdown-menu").css('display', 'block');
			li.find('a.dropdown-toggle').addClass('active active-parent');
		}
	};

}();