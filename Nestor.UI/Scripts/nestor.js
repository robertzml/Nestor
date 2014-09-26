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
	
	
	var handleInitDatatable = function($dom) {

		var oTable = $dom.dataTable({
			
			"lengthMenu": [
				[5, 10, 20, -1],
				[5, 10, 20, "All"] // change per page values here
			],
			// set the initial value
			"pageLength": 10,

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
		
		initDatatable: function($dom) {
			return handleInitDatatable($dom);
		},
		
		initFrontTable: function($dom) {
			handleFrontTable($dom);
		}
	};

}();