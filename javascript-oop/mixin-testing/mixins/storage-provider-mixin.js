const MyStorage = (() => {
    const IdProvider = require('../utils/id-provider'),
        storage = {};

    const mixin = Base => class extends Base {
        constructor(args) {
            super(args);
        }

        get id() {
            return this._id;
        }

        set id(id) {
            this._id = id;
        }

        addItem(item) {
            const className = item.constructor.name || 'anonymous';
            if (!storage[className]) {
                storage[className] = {
                    items: [],
                    idProvider: IdProvider()
                };
            }

            item.id = storage[className].idProvider.next().value;
            storage[className].items.push(item);
            return item.id;
        }

        getItemById(id, type) {
            const itemToReturn = storage[type].items.filter(item => item.id === id);
            return itemToReturn;
        }

        setItemById(id, type, value) {
            var item = storage[type].items.filter(item => item.id === id);
            item = value;
        }

        getAllItems(type) {
            return storage[type].items.slice();
        }

        testPrint(type) {
            console.log(storage[type].items);
        }
    };

    return mixin;
})();

module.exports = MyStorage;