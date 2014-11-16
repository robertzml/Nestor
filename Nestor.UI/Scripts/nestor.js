/* nestor scripts */
var nestor = function () {

	var handleLeftNavActive = function($dom) {
		$('ul#left-nav').children().removeClass('active open');	

		var parent = $dom.parent();
		parent.addClass('active');		

		var li = $dom.closest('li.left-nav-first');
		li.addClass('active open');
		li.find('a').append('<span class="selected"></span>');
		li.find('.arrow').addClass('open');
	}
	
	
	var handleInitDatatable = function($dom, filter) {

		var oTable = $dom.dataTable({
			
			"lengthMenu": [
				[5, 10, 20, -1],
				[5, 10, 20, "All"] // change per page values here
			],
			// set the initial value
			"pageLength": 10,

			"order": [],

			"pagingType": "bootstrap_full_number",

			"language": {
					"lengthMenu": "  _MENU_ 记录",
					"sLengthMenu": "每页 _MENU_ 条记录",
					"sInfo": "显示 _START_ 至 _END_ 共有 _TOTAL_ 条记录",
					"sInfoEmpty": "记录为空",
					"sInfoFiltered": " - 从 _MAX_ 条记录中",
					"sZeroRecords": "结果为空",
					"sSearch": "搜索:",
					"paginate": {
						"previous":"Prev",
						"next": "Next",
						"last": "Last",
						"first": "First"
					}
				},

			"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r><'table-scrollable't><'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12' p>>", // horizobtal scrollable datatable
		});
		
		if (filter) {
			$dom.find("tfoot th").each(function (i) {
			if ($(this).attr('data-filter') == 'true') {
				var select = $('<select class="form-control"><option value=""></option></select>')
					.appendTo($(this).empty())
					.on('change', function () {
						var val = $(this).val();
						oTable.api().column(i)
							.search(val ? '^' + $(this).val() + '$' : val, true, false)
							.draw();
					});
					
					oTable.api().column(i).data().unique().sort().each(function (d, j) {
						if ($(d).html()) {
							select.append('<option value="' + $(d).html() + '">' + $(d).html() + '</option>')
						} else {
							select.append('<option value="' + d + '">' + d + '</option>')
						}
					});
				}
			});
		}
		return oTable;
	}	
	
	var handleFrontTable = function($dom) {
		var oTable = $dom.dataTable({
			
			"lengthMenu": [
				[5, 10, 20, -1],
				[5, 10, 20, "All"] // change per page values here
			],
			// set the initial value
			"pageLength": 10,
			
			"ordering": false,
			
			"pagingType": "bootstrap_full_number",

			"language": {
					"lengthMenu": "  _MENU_ 记录",
					"sLengthMenu": "每页 _MENU_ 条记录",
					"sInfo": "显示 _START_ 至 _END_ 共有 _TOTAL_ 条记录",
					"sInfoEmpty": "记录为空",
					"sInfoFiltered": " - 从 _MAX_ 条记录中",
					"sZeroRecords": "结果为空",
					"sSearch": "搜索:",
					"paginate": {
						"previous":"Prev",
						"next": "Next",
						"last": "Last",
						"first": "First"
					}
				},

			"dom": "<'table-scrollable't><'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12' p>>"
		});	
		return oTable;
	}
		
	return {
		showMessage: function(text) {
			var n = noty({
				text: text,
				type: 'information',
				timeout: 1000
			});
		},
		
		leftNavActive: function($dom) {
			handleLeftNavActive($dom);
		},
		
		topNavActive: function(id) {
			$('ul#top-menu').find('li[data-id=' + id +']').addClass('active');
		},
		
		initDatepicker: function($dom) {
			$dom.datepicker({
                format: "yyyy-mm-dd",
                weekStart: 7,
                language: "zh-CN",
				todayHighlight: true,
                autoclose: true
            });
		},
		
		initDatatable: function($dom, filter) {
			return handleInitDatatable($dom, filter);
		},
		
		initFrontTable: function($dom) {
			handleFrontTable($dom);
		},
		
		initBackstretch: function() {
			$.backstretch([                
                "../images/slides/slider1.jpg",
                "../images/slides/slider2.jpg",
                "../images/slides/slider3.jpg",
				"../images/slides/slider4.jpg",
				"../images/slides/slider5.jpg"
            ], {
                fade: 1000,
                duration: 5000
            });
		}
	};

}();