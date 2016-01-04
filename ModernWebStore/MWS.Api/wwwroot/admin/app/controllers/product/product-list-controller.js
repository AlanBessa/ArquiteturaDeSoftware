(function () {
    'use strict';
    angular.module('mwa').controller('ProductListCtrl', ProductListCtrl);

    ProductListCtrl.$inject = ['ProductFactory'];

    function ProductListCtrl(ProductFactory) {
        var vm = this;
        vm.products = [];
        activate();

        //Como se fosse o construtor do Controller
        function activate() {
            getProducts();
        };

        function getProducts() {
            ProductFactory.get()
                .success(success)
                .catch(fail);

            function success(response) {
                vm.products = response;
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
        }
    };
})();