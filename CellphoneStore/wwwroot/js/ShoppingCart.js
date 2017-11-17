var cart = {};

cart.data = [];
cart.keyID = "cart";
cart.badgeSelector = ".badge";

cart.loadFromLocalStorage = function () {
    if (JSON.parse(localStorage.getItem(cart.keyID)))
        cart.data = JSON.parse(localStorage.getItem(cart.keyID));
};

cart.increaseItemByQuantity = function (itemID, itemName, itemPrice, itemQuantity) {
    var found = false;
    for (var i = 0; i < cart.data.length; i++) {
        if (cart.data[i].id === itemID) {
            cart.data[i].quantity += itemQuantity;
            found = true;
            break;
        }
    }
    if (found === false)
        cart.data.push({ id: itemID, name: itemName, price: itemPrice, quantity: itemQuantity });

    localStorage.setItem(cart.keyID, JSON.stringify(cart.data));
    cart.updateBadge();
};
cart.deleteItemByOne = function (itemID, invoke) {
    var deleteIndex = -1;
    for (var i = 0; i < cart.data.length; i++) {
        if (cart.data[i].id === itemID) {
            cart.data[i].quantity -= 1;
            cart.data[i].quantity === 0 ? deleteIndex = i : deleteIndex = -1;
            break;
        }
    }
    if (deleteIndex !== -1)
        cart.data.splice(deleteIndex, 1);

    localStorage.setItem(cart.keyID, JSON.stringify(cart.data));
    cart.updateBadge();
    invoke();
};

cart.totalItemInCart = function () {
    var total = 0;
    for (var i = 0; i < cart.data.length; i++) {
        total += cart.data[i].quantity;
    }
    return total;
};

cart.updateBadge = function () {
    $(cart.badgeSelector).empty();
    if (cart.totalItemInCart() > 0)
        $(cart.badgeSelector).append(cart.totalItemInCart());
};

cart.loadFromLocalStorage();
cart.updateBadge();