var productDataService;
var $injector;

/*
This test only validating consolidate function in productDataService and not covering all possible scenario
*/

module("Service: productDataService", {
    beforeEach: function () {
        $injector = angular.injector(['ng', 'Products']);
        productDataService = $injector.get('productDataService');
    }
});

var productsOk = function (product1, product2, productType, message ) {
    ok( product1.id === product2.id &&
        product1.name == product2.name &&
        product1.type === productType &&
        product1.price === product2.price, message );
}


test('productDataService.consolidate', function (assert) {
    var l = new LawnmowerRepository().getAll();
    var p = new PhoneCaseRepository().getAll();
    var t = new TShirtRepository().getAll();

    productDataService.consolidate(l, "lawnmower");
    ok(productDataService.products.length === l.length, "the number of items are ok");

    for( var i = 0 ; i < l.length; i++ ){
        productsOk(productDataService.products[i], l[i], "lawnmower", "product " + i + " is ok");
    }


    productDataService.consolidate(p, "Phone Case");
    ok(productDataService.products.length === l.length + p.length, "the number of items are ok");

    for (var j = 0 ; j < p.length; j++) {
        productsOk(productDataService.products[i + j], p[j], "Phone Case", "product " + (i + j ) + " is ok");
    }

    productDataService.consolidate(t, "T-Shirt");
    ok(productDataService.products.length === l.length + p.length + t.length , "the number of items are ok");

    for (var k = 0 ; k < t.length; k++) {
        productsOk(productDataService.products[i+j+k], t[k], "T-Shirt", "product " + (i+j+k) + " is ok");
    }
});