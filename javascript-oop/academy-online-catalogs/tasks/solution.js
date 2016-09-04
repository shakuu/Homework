function solve() {
    function* IDGenerator() {
        let lastId = 0;
        while (true) {
            yield lastId += 1;
        }
    }

    const idGenerator = IDGenerator();

    function checkNumberInRange(value, min, max) {
        if (min <= value && value <= max) {
            return true;
        }
    }

    function checkIfValueIsString(value) {
        if (typeof value === 'string') {
            return true;
        }
    }

    class Item {
        constructor(name, description) {
            this.id = idGenerator.next().value;

            this.name = name;
            this.description = description;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            if (!checkIfValueIsString(value)) {
                throw new Error();
            }

            let len = value.length;
            if (!checkNumberInRange(len, 2, 40)) {
                throw new Error();
            }

            this._name = value;
        }

        get description() {
            return this._description;
        }

        set description(value) {
            if (!checkIfValueIsString(value)) {
                throw new Error();
            }

            if (value === '') {
                throw new Error();
            }

            this._description = value;
        }
    }

    const ISBN_REGEX = /^[0-9]+$/;
    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(name, description);

            this.isbn = isbn;
            this.genre = genre;
        }

        get isbn() {
            return this._isbn;
        }

        set isbn(value) {
            if (!checkIfValueIsString(value)) {
                throw new Error();
            }

            let len = value.length;
            if (len !== 10 && len !== 13) {
                throw new Error();
            }

            if (!ISBN_REGEX.test(value)) {
                throw new Error();
            }

            this._isbn = value;
        }

        get genre() {
            return this._genre;
        }

        set genre(value) {
            if (!checkIfValueIsString(value)) {
                throw new Error();
            }

            let len = value.length;
            if (!checkNumberInRange(len, 2, 20)) {
                throw new Error();
            }

            this._genre = value;
        }
    }

    class Media extends Item {
        constructor(name, rating, duration, description) {
            super(name, description);

            this.duration = duration;
            this.rating = rating;
        }

        get duration() {
            return this._duration;
        }

        set duration(value) {
            let num = Number(value);
            if (isNaN(num)) {
                throw new Error();
            }

            if (num <= 0) {
                throw new Error();
            }

            this._duration = value;
        }

        get rating() {
            return this._rating;
        }

        set rating(value) {
            let num = Number(value);
            if (isNaN(num)) {
                throw new Error();
            }

            if (num < 1 || 5 < num) {
                throw new Error();
            }

            this._rating = value;
        }
    }

    const catalogIdGenerator = IDGenerator();
    class Catalog {
        constructor(name) {
            this.id = catalogIdGenerator.next().value;

            this.name = name;
            this.items = [];
        }

        get name() {
            return this._name;
        }

        set name(value) {
            if (!checkIfValueIsString(value)) {
                throw new Error();
            }

            let len = value.length;
            if (!checkNumberInRange(len, 2, 40)) {
                throw new Error();
            }

            this._name = value;
        }

        add(...newItems) {
            if (newItems.length === 1 && Array.isArray(newItems[0])) {
                newItems = newItems[0];
            }

            if (newItems.length === 0) {
                throw new Error();
            }

            newItems.forEach(item => {
                if (!item.id || !item.name || !item.description) {
                    throw new Error();
                }
            });

            this.items.push(...newItems);
        }

        find(options) {
            if (!options) {
                throw new Error();
            }

            let result;
            if (options.id || options.name) {
                result = findByOptions(options, this.items);
            } else if (!isNaN(options)) {
                result = findById(options, this.items);
            } else {
                throw new Error();
            }

            return result;
        }

        search(pattern) {
            if (typeof pattern !== 'string') {
                throw new Error();
            }

            if (pattern.length < 1) {
                throw new Error();
            }

            let matches = this.items.filter(item => {
                let nameIsMatch = false;
                if (item.name.toLowerCase().indexOf(pattern.toLowerCase) >= 0) {
                    nameIsMatch = true;
                }

                let descriptionIsMatch = false;
                if (item.description.toLowerCase().indexOf(pattern.toLowerCase) >= 0) {
                    descriptionIsMatch = true;
                }

                return nameIsMatch || descriptionIsMatch;
            });

            return matches;
        }
    }

    function findByOptions(options, arr) {
        let matches = arr.filter(item => {
            let isMatch = false;
            if (options.id) {
                if (item.id === options.id) {
                    isMatch = true;
                } else {
                    return false;
                }
            }

            if (options.name) {
                if (options.name.toLowerCase() === item.name.toLowerCase()) {
                    isMatch = true;
                } else {
                    return false;
                }
            }

            return isMatch;
        });

        return matches;
    }

    function findById(id, arr) {
        id = Number(id);
        if (isNaN(id)) {
            throw new Error();
        }

        let matches = arr.filter(item => item.id === id);
        if (matches.length === 0) {
            return null;
        } else {
            return matches[0];
        }
    }

    class BookCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...newItems) {
            if (newItems.length === 1 && Array.isArray(newItems[0])) {
                newItems = newItems[0];
            }

            if (newItems.length === 0) {
                throw new Error();
            }

            newItems.forEach(item => {
                if (!item.isbn || !item.genre) {
                    throw new Error();
                }
            });

            super.add(newItems);
        }

        find(options) {
            let matches = super.find(options);

            if (options.genre) {
                matches = matches.filter(item => {
                    return item.genre.toLowerCase() === options.genre.toLowerCase();
                });
            }

            return matches;
        }
    }

    return {
        getBook: function (name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function (name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function (name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function (name) {
            //return a media catalog instance
        }
    };
}

module.exports = solve;