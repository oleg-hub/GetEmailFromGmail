$(document).ready(function () {
	$("#grid").kendoGrid({
		dataSource: {
			transport: {
				read: {
					type: "GET",
					url: "/Home/LettersList",
					contentType: "application/json; charset=utf-8",
				},
			},
			serverSorting: false,
			pageSize: 20,
			serverFiltering: false,
			serverPaging: false
		},
		autoBind: true,
		scrollable: true,
		sortable: true,
		groupable: false,
		pageable: true,
		mobile: true,
		height: 600,
		filterable: {
			mode: "row"
		},
		columns: [
		{
			field: "From",
			title: "From",
			width: "200px"
		},
		{
			field: "Title",
			title: "Title",
			width: "160px",
		},
		{
			field: "Summary",
			title: "Summary",
			width: "160px"
		}
		]
	});
});