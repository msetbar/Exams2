(function () {
    var app = angular.module('Products', []);

    app.directive("nzProducts", function () {

        var render = function (products, rate, currency) {
            var nzd =
           '<table class="table table-striped">'
           + '	<thead>'
           + '		<tr><td colspan="3">Products (' + currency + ')</td></tr>'
           + '		<tr>'
           + '			<td>Name</td>'
           + '			<td>Price</td>'
           + '			<td>Type</td>'
           + '		</tr>'
           + '	</thead>'
           + '	<tbody>';

            var n = products;

            for (var i = 0; i < n.length; i++) {
                nzd +=
                    '<tr>'
                + '<td>' + n[i].name + '</td>'
                + '<td>' + (n[i].price * rate).toFixed(2) + '</td>'
                + '<td>' + n[i].type + '</td>'
                + '</tr>';
            }
            nzd += '</tbody></table>';

            return nzd;
        }


        return {
            restrict: "E",
            link: function (scope, element, attrs) {
                var rate = attrs.rate;
                var currency = attrs.currency;

                element.html(render(scope.products, rate, currency));
            },
            template: "<div/>"
        };
    });

    var service = app.service("productDataService", ["$rootScope", function ($rootScope) {
        var service = {
            products: [],

            consolidate: function (prods, productType) {
                for (var i = 0; i < prods.length; i++) {
                    service.products.push({
                        id: prods[i].id,
                        name: prods[i].name,
                        price: prods[i].price,
                        type: productType
                    });
                }
            }

        };

        return service
    }]);

    app.controller('ProductsCtrl', ["$scope", "productDataService", function (scope, productDataService) {
        var l = new LawnmowerRepository().getAll();
        var p = new PhoneCaseRepository().getAll();
        var t = new TShirtRepository().getAll();

        productDataService.consolidate(l, "lawnmower");
        productDataService.consolidate(p, "Phone Case");
        productDataService.consolidate(t, "T-Shirt");

        scope.products = productDataService.products;
    }]);
})();
