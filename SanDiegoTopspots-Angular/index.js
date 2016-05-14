var app = angular.module('myApp', []);

app.controller('MainController', ['$scope', '$http', '$log', function($scope, $http, $log) { //([{
    $http.get('http://localhost:56362/api/Bears').success(function(data) { // ({
        $scope.topSpots = data;

    });
    /* $http.post('http://localhost:56362/api/Bears').success(function(data) { // ({
        $scope.topSpots = data;*/

    $scope.addNew = function(newBear) {
        newBear.location = [Number(newBear.latitude), Number(newBear.longitude)];
        $http({
            method: 'POST',
            url: 'http://localhost:56362/api/Bears',
            data: $scope.newBear
        }).then(function() {
                $scope.topSpots.push(newBear);
                $scope.newBear = {};
            },
            //failure
            function(error) {

                $log.error(error);
            });
    };



}]);

/* app.controller('MapCtrl', function ($scope) {
      $http.get('topspots.json').success(function(data) { // ({
         $scope.topSpots = data;*/
/*  var map = new google.maps.Map(document.getElementById('map'), {
                    zoom: 10,
                    center: new google.maps.LatLng(32.692083, -117.181392),
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                    });

                    var infowindow = new google.maps.InfoWindow();

                    var marker, i;

                    for (i = 0; i < $scope.topSpots.length; i++) {
                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng($scope.topSites[i].location[0], $scope.topSites[i].location[1]),
                        map: map
                    });

                    google.maps.event.addListener(marker, 'click', (function(marker, i) {
                        return function() {
                            infowindow.setContent($scope.topSites[i].name);
                            infowindow.open(map, marker);
                        }
                    })

                    (marker, i));
                }
*/



//}]);


/*   var mapOptions = {
        zoom: 4,
        center: new google.maps.LatLng(40.0000, -98.0000),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }

    $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

    $scope.markers = [];
    
    var infoWindow = new google.maps.InfoWindow();
    
    var createMarker = function (info){
        
        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(info.lat, info.long),
            title: info.city
        });
        marker.content = '<div class="infoWindowContent">' + info.desc + '</div>';
        
        google.maps.event.addListener(marker, 'click', function(){
            infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            infoWindow.open($scope.map, marker);
        });
        
        $scope.markers.push(marker);
        
    }  
    
    for (i = 0; i < cities.length; i++){
        createMarker(cities[i]);
    }

    $scope.openInfoWindow = function(e, selectedMarker){
        e.preventDefault();
        google.maps.event.trigger(selectedMarker, 'click');
    }
});
});*/
