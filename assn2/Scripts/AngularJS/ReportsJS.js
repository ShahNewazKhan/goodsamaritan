var app;

(function () {
    app = angular.module("reportsAPI", []);
})();

app.config(['$httpProvider', function ($httpProvider) {
    // Intercept POST requests, convert to standard form encoding
    $httpProvider.defaults.headers.post["Content-Type"] = "application/x-www-form-urlencoded";
    $httpProvider.defaults.headers.put["Content-Type"] = "application/x-www-form-urlencoded";
    $httpProvider.defaults.transformRequest.unshift(function (data, headersGetter) {
        var key, result = [];
        for (key in data) {
            if (data.hasOwnProperty(key)) {
                result.push(encodeURIComponent(key) + "=" + encodeURIComponent(data[key]));
            }
        }
        return result.join("&");
    });
}]);

app.controller('getCities',
function ($scope, $http) {
    console.log("GetCities");
    $scope.addBtn = function () {
        $http.get("http://localhost:10397/api/CityofAssaultAPI")
		.success(function (response) {
		    console.log(response);
		});
    };
    
});

app.controller('getSmartEntities',
function ($scope, $http) {

    console.log("GetSmart");

    $scope.getsmart = function () {
        $http.get("http://localhost:10397/api/cityofassaultapi")
		.success(function (response) {

		    console.log(response);
		    $scope.Cities = response;
		    $scope.defaultCity = response[1]["Value"];

		}).error(function (data, status, headers, config) {
		    console.log(data);
		});
    };

    $scope.getsmart();
});


