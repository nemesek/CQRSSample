function ProductViewModel($) {
    var self = this;
    self.products = ko.observableArray([]);

    // Get Product from ProductId
    self.getProduct = function (id) {
        for (var p in self.products()) {
            if (self.products()[p].id() == id) {
                return self.products()[p];
            }
        }
    };

    // Get which Products have changed
    self.getChangedProducts = function () {
        var isChanged = [];
        for (var p in self.products()) {
            if (self.products()[p].isChanged()) {
                isChanged.push(self.products()[p].id());
            }
        }

        return isChanged;
    };

    // Set all Products' IsChanged value
    self.setIsChangedForAllProducts = function (value) {
        for (var p in self.products()) {
            self.products()[p].isChanged(value);
        }
    };

    // populate self.products() with data from server
    self.getProducts = function () {
        // get products that were just changed
        var changedProducts = self.getChangedProducts();

        // clear products
        self.products([]);
        
        $.ajax({
            type: 'POST',
            url: '../Home/GetProducts',
            contentType: "application/json",
            success: function (data) {
                for (var product in data) {
                    // if product has been changed, set product's isChanged property to be true
                    if ($.inArray(data[product]["ProductId"], changedProducts) > -1) {
                        self.products.push(
                            new Product(data[product]["ProductId"], data[product]["Name"], data[product]["QueryCategory"]["CategoryName"], true)
                        );
                    } else {
                        self.products.push(
                            new Product(data[product]["ProductId"], data[product]["Name"], data[product]["QueryCategory"]["CategoryName"], false)
                        );
                    }
                }
            },
            async: false
        });
    };

    self.editProduct = function (product) {
        // create QueryProduct object to pass to HomeController
        var queryCategory = new Object();
        queryCategory.CategoryName = product["category"]();

        var queryProduct = new Object();
        queryProduct.ProductId = product["id"]();
        queryProduct.Name = product["name"]();
        queryProduct.QueryCategory = queryCategory;

        $.ajax({
            type: 'POST',
            url: '../Home/UpdateProduct',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON({ queryProduct: queryProduct }),
            success: function () {
                // update successful
            },
            error: function (request, status, error) {
                alert(error);
            },
            async: false
        });
    };

    // bind knockout
    ko.applyBindings(self);
}

// Product to display in table
function Product(id, name, category, isChanged) {
    var self = this;
    self.isReadOnly = ko.observable(true);
    self.isChanged = ko.observable(isChanged);
    self.id = ko.observable(id);
    self.name = ko.observable(name);
    self.category = ko.observable(category);

    self.toggleReadOnly = function () {
        self.isReadOnly(!self.isReadOnly());
    };

}

