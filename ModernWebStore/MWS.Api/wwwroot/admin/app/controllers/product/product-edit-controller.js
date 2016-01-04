(function () {
    'use strict';
    angular.module('mwa').controller('ProductEditCtrl', ProductEditCtrl);

    ProductEditCtrl.$inject = ['$routeParams', 'ProductFactory'];

    function ProductEditCtrl($routeParams, ProductFactory) {
        var vm = this;
        var id = $routeParams.id;

        vm.product = {};
        activate();

        //Como se fosse o construtor do Controller
        function activate() {
            getProduct();
        };

        function getProduct() {
            ProductFactory.getById(id) //Criar serviço para este método
                .success(success)
                .catch(fail);

            function success(response) {
                vm.product = response;
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
        }
    };
})();