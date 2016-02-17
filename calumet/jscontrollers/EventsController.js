'user strict';

angular.module('calumet', ['ngMaterial']).controller('EventsController', ['$scope','$http', 
       function($scope, $http)
       {
           

   

    function GetEvents() {
        $http.get("http://localhost:10002/api/v1/event").then(function (response) {
            self.events = response.data;
            console.log(self.events);
        });
    }

    var self = this;
    self.events = [];//[{ EventName: "Test" }, { EventName: "Party!" }];
    console.log(self.events);
    self.GetEvents = GetEvents;
    self.GetEvents();
}]);
