
app.controller('getSmartEntities',
function ($scope, http) {

    $http.get("http://localhost:10397/api/BadDateReports")
		.success(function (response) {
		    console.log(response);
		});
});
