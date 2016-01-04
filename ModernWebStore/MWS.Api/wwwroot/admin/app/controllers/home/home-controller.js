(function ()
{
    'use strict';
    angular.module('mwa').controller('HomeCtrl', HomeCtrl);

    HomeCtrl.$inject = ['$scope'];

    function HomeCtrl($scope)
    {
        var vm = this;
        
        activate();

        //Como se fosse o construtor do Controller
        function activate() {

        };
    };
})();