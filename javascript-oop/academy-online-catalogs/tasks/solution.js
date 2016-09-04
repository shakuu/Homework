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
            //return a book catalog instance
        },
        getMediaCatalog: function (name) {
            //return a media catalog instance
        }
    };
}

module.exports = solve;