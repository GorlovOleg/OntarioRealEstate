/** Angular app module
 
 Author : Programmer Analyst, Oleg Gorlov
 Company: Sutton Group-Admiral Realty Inc. http://www.ontario-real-estate.com, Toronto 
 Email : oleg_gorlov@yahoo.com

 */
(function () {
    angular.module('inspinia', [
                                        //--- Services ---
        'ui.router',                    // Routing
        'oc.lazyLoad',                  // ocLazyLoad
        'ui.bootstrap',                 // Ui Bootstrap
        'pascalprecht.translate',       // Angular Translate
        'ngIdle',                       // Idle timer
        'ngSanitize',                   // ngSanitize
        'pBrokersWebAPIService',
        'pListinersWebAPIService',
        'pCitiesWebAPIService',
        'ui.utils.masks'
    ])
	.run(function () {
	   
	})

	.directive('psCurrentTime', function () {
	    return {
	        template: '<h2 class="text-center">{{vm.currentTime}}</div>',
	        controllerAs: 'vm',
	        controller: function () {
	            var vm = this;
	            vm.currentTime = new Date().toLocaleTimeString();
	        }
	    }
	});

    //--- pBrokersWebAPIController.cs
    var pBrokersWebAPIService = angular.module('pBrokersWebAPIService', ['ngResource']);

    pBrokersWebAPIService.factory('Broker', ['$resource',

    function ($resource) {

        //alert("wwwroot/js/app.js-pBrokersWebAPIService.factory('Broker'");

        return $resource('/api/pBrokersWebAPI/', {}, {
               APIData: { method: 'GET', params: {}, isArray: true }
           });
    }]);

    //--- pListinersWebAPIController.cs
    var pListinersWebAPIService = angular.module('pListinersWebAPIService', ['ngResource']);

    pListinersWebAPIService.factory('Listiner', ['$resource',

        function ($resource) {

                        return $resource('/api/pListinersWebAPI/', {}, {
                APIData: { method: 'GET', params: {}, isArray: true }
            });
    }]);

    //---
    var pCitiesWebAPIService = angular.module('pCitiesWebAPIService', ['ngResource']);

    //--- pCitiesWebAPIController.cs
    pCitiesWebAPIService.factory('City', ['$resource',

    function ($resource) {

             return $resource('/api/pCitiesWebAPI/', {},
            {

                APIData: { method: 'GET', params: {}, isArray: true }

            });

    }]);


}
)();
