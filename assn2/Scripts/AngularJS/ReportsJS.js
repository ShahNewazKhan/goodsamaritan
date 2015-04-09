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

app.controller('generateReport',
function ($scope, $http) {
    console.log("GetCities");

    $scope.genReport = function () {

        console.log("Gettng Reports");

        $http.get("http://localhost:10397/api/ClientAPI/getClients/" + $scope.month + "/" + $scope.day)
		.success(function (response) {
		    console.log(response);
		}).error(function (response) {
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
		    console.log(response[1]["Id"]);
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

        $http.get("http://localhost:10397/api/AssignedWorkers")
		.success(function (response) {

		    $scope.assignedWorkers = response;
		    $scope.defaultAssignedWorker = response[1]["Value"];

		});

        $http.get("http://localhost:10397/api/ReferralSources")
		.success(function (response) {

		    $scope.referralSources = response;
		    $scope.defaultReferralSource = response[1]["Value"];

		});

        $http.get("http://localhost:10397/api/ReferralContacts")
		.success(function (response) {

		    $scope.referralContacts = response;
		    $scope.defaultReferralContact = response[1]["Value"];

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
           $scope.defaultVictimOfIncident = response[1]["Value"];

       });

        $http.get("http://localhost:10397/api/FamilyViolenceFiles")
       .success(function (response) {

           $scope.familyViolenceFiles = response;
           $scope.defaultfamilyViolenceFile = response[1]["Value"];

       });

        $http.get("http://localhost:10397/api/Ethnicities")
       .success(function (response) {

           $scope.ethnicities = response;
           $scope.defaultEthnicity = response[1]["Value"];

       });

        $http.get("http://localhost:10397/api/Ages")
       .success(function (response) {

           $scope.ages = response;
           $scope.defaultAge = response[1]["Value"];

       });

        $http.get("http://localhost:10397/api/RepeatClients")
       .success(function (response) {

           $scope.repeatClients = response;
           $scope.defaultRepeatClient = response[1]["Value"];

       });

        $http.get("http://localhost:10397/api/StatusofFiles")
       .success(function (response) {

           $scope.statusOfFiles = response;
           $scope.defaultStatusOfFile = response[1]["Value"];

       });

        $http.get("http://localhost:10397/api/DuplicateFiles")
       .success(function (response) {

           $scope.duplicateFiles = response;
           $scope.defaultDuplicateFiles = response[1]["Value"];

       });

        $http.get("http://localhost:10397/api/cityofassaultapi")
       .success(function (response) {

           $scope.Cities = response;
           $scope.defaultCity = response[1]["Value"];

       });

    };

    $scope.getsmart();

    $scope.addBtn = function () {

        console.log("ADDING CLIENT");

        $http.post("http://localhost:10397/api/ClientAPI",
            {
                'fiscalYear': $scope.defaultYear,
                'month': $scope.month,
                'day': $scope.day,
                'surname': $scope.surname,
                'firstname': $scope.firstname,
                'policeFileNum': $scope.policeFile,
                'courtFileNum': $scope.courtFile,
                'SWCFileNum': $scope.swcFile,
                'RiskLevel': $scope.defaultRiskLevels,
                'Crisis': $scope.defaultCrises,
                'Service': $scope.defaultService,
                'Program': $scope.defaultProgram,
                'RiskAssesmentAssignee': $scope.riskAssesmentAssignedTo,
                'RiskStatus': $scope.defaultRiskStatus,
                "AssignedWorker": $scope.defaultAssignedWorker,
                "ReferralSource": $scope.defaultReferralSource,
                "ReferralContact": $scope.defaultReferralContact,
                "incident": $scope.defaultIncident,
                "AbuserName": $scope.abuserName,
                "AbuserRelationship": $scope.defaultAbuserRelationship,
                "VictimofIncident": $scope.defaultVictimOfIncident,
                "FamilyViolenceFile": $scope.defaultfamilyViolenceFile,
                "gender": $scope.gender,
                "Ethnicity": $scope.defaultEthnicity,
                "Age": $scope.defaultAge,
                "RepeatClient": $scope.defaultRepeatClient,
                "DuplicateFile": $scope.defaultDuplicateFiles,
                "numToddler": $scope.numChild6,
                "numChildren": $scope.numChild7,
                "numYouth": $scope.numChild13,
                "StatusofFile": $scope.defaultStatusOfFile,
                "dateLastTransferred": "2015-04-08T20:01:20.8030914-07:00",
                "dateClosed": "2015-04-08T20:01:20.8030914-07:00",
                "dateReOpened": "2015-04-08T20:01:20.8030914-07:00"
            }
            )
		.success(function (response) {
		    console.log(response);
		}).error(function (response) {
		    console.log(response);
		});
    };
});