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

    $scope.getsmart = function () {

        $http.get("http://localhost:10397/api/FiscalYears")
		.success(function (response) {

		    $scope.years = response;
		    $scope.defaultYear = response[1]["Value"];

		});

        $http.get("http://localhost:10397/api/RiskLevels")
		.success(function (response) {

		    $scope.riskLevels = response;
		    $scope.defaultRiskLevels = response[1]["Value"];

		});

        $http.get("http://localhost:10397/api/Crises")
		.success(function (response) {

		    $scope.crises = response;
		    $scope.defaultCrises = response[1]["Value"];

		});

        $http.get("http://localhost:10397/api/Services")
		.success(function (response) {

		    $scope.services = response;
		    $scope.defaultService = response[1]["Value"];

		});

        $http.get("http://localhost:10397/api/Programs")
		.success(function (response) {

		    $scope.programs = response;
		    $scope.defaultProgram = response[1]["Value"];

		});

        $http.get("http://localhost:10397/api/RiskStatuses")
		.success(function (response) {

		    $scope.riskStatuses = response;
		    $scope.defaultRiskStatus = response[1]["Value"];

		});

        $http.get("http://localhost:10397/api/ReferralSources")
		.success(function (response) {

		    $scope.referralSources = response;
		    $scope.defaultReferralSource = response[1]["Value"];

		});

        $http.get("http://localhost:10397/api/Incidents")
       .success(function (response) {

           $scope.incidents = response;
           $scope.defaultIncident = response[1]["Value"];

       });

        $http.get("http://localhost:10397/api/AbuserRelationships")
       .success(function (response) {

           $scope.abuserRelationships = response;
           $scope.defaultAbuser = response[1]["Value"];

       });

        $http.get("http://localhost:10397/api/VictimofIncidents")
       .success(function (response) {

           $scope.victimOfIncidents = response;
           $scope.defaultVictimeOfIncident = response[1]["Value"];

       });

        $http.get("http://localhost:10397/api/FamilyViolenceFiles")
       .success(function (response) {

           $scope.family = response;
           $scope.defaultVictimeOfIncident = response[1]["Value"];

       });

        $http.get("http://localhost:10397/api/cityofassaultapi")
       .success(function (response) {

           $scope.Cities = response;
           $scope.defaultCity = response[1]["Value"];

       });
        
    };

    $scope.getsmart();
});


