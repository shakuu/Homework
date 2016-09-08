'use strict';
function solve() {
    function* IdGenerator() {
        let lastId = 0;
        while (true) {
            yield lastId += 1;
        }
    }

    const validator = (() => {
        const ISBN_PATTERN = /^[0-9]+$/;

        return {
            validateIsStringWithLength(value, min = 1, max = Number.MAX_VALUE) {
                if (value === undefined) {
                    throw new Error();
                }

                if (typeof value !== 'string') {
                    throw new Error();
                }

                if (!(min <= value.length && value.length <= max)) {
                    throw new Error();
                }
            },
            validateIsNumberInRange(value, min = 0, max = Number.MAX_VALUE) {
                value = Number(value);
                if (isNaN(value)) {
                    throw new Error();
                }

                if (!(min <= value && value <= max)) {
                    throw new Error();
                }
            },
            validateIsbn(value) {
                validator.validateIsStringWithLength(value);
                if (!(value.length === 10 || value.length === 13)) {
                    throw new Error();
                }

                if (!ISBN_PATTERN.test(value)) {
                    throw new Error();
                }
            },
            validateIsItem(item) {
                const hasId = item.id || false;
                const hasName = item.name || false;
                const hasDescription = item.description || false;

                const isValid = hasId && hasName && hasDescription;
                return isValid;
            }
        };
    })();

    const itemIdGenerator = IdGenerator();
    class Item {
        constructor(name, description) {
            this.id = itemIdGenerator.next().value;
            this.name = name;
            this.description = description;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            validator.validateIsStringWithLength(value, 2, 40);
            this._name = value;
        }

        get description() {
            return this._description;
        }

        set description(value) {
            validator.validateIsStringWithLength(value);
            this._description = value;
        }
    }

    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(name, description);

            this.genre = genre;
            this.isbn = isbn;
        }

        get genre() {
            return this._genre;
        }

        set genre(value) {
            validator.validateIsStringWithLength(value, 2, 20);
            this._genre = value;
        }

        get isbn() {
            return this._isbn;
        }

        set isbn(value) {
            validator.validateIsbn(value);
            this._isbn = value;
        }
    }

    class Media extends Item {
        constructor(name, rating, duration, description) {
            super(name, description);

            this.rating = rating;
            this.duration = duration;
        }

        get duration() {
            return this._duration;
        }

        set duration(value) {
            validator.validateIsNumberInRange(value, 1);
            this._duration = value;
        }

        get rating() {
            return this._rating;
        }

        set rating(value) {
            validator.validateIsNumberInRange(value, 1, 5);
            this._rating = value;
        }
    }

    const catalogIdGenerator = IdGenerator();
    class Catalog {
        constructor(name, items) {
            this.id = catalogIdGenerator.next().value;

            this.name = name;
            this.items = items || [];
        }

        get name() {
            return this._name;
        }

        set name(value) {
            validator.validateIsStringWithLength(value, 2, 40);
            this._name = value;
        }

        add(...items) {
            if (items.length === 0) {
                throw new Error();
            }

            if (items.length === 1) {
                items = items[0];
            }

            items.forEach(item => {
                if (!validator.validateIsItem(item)) {
                    throw new Error();
                }
            });

            this.items.push(...items);
            return this;
        }

        find(options) {
            if (options === undefined) {
                throw new Error();
            }

            let result;
            if (typeof options === 'object') {
                const matches = this.items.filter(item => {
                    let isMatch = true;
                    if (options.id && options.id !== item.id) {
                        return false;
                    }

                    if (options.name && options.name !== item.name) {
                        return false;
                    }

                    return isMatch;
                });

                result = matches;
            } else {
                const id = Number(options);
                if (isNaN(id)) {
                    throw new Error();
                }

                const matches = this.items.filter(item => {
                    const isMatch = item.id === id;
                    return isMatch;
                });

                result = matches[0] || null;
            }

            return result;
        }

        search(pattern) {
            validator.validateIsStringWithLength(pattern, 1);
            pattern = pattern.toLowerCase();

            const matches = this.items.filter(item => {
                const isMatchingName = item.name.toLowerCase().indexOf(pattern) >= 0;
                const isMatchingDescription = item.description.toLowerCase().indexOf(pattern) >= 0;

                return isMatchingName || isMatchingDescription;
            });

            return matches;
        }
    }

    class BookCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...books) {
            if (books.length === 0) {
                throw new Error();
            }

            if (books.length === 1 && Array.isArray(books[0])) {
                books = books[0];
            }

            books.forEach(book => {
                if (!book.isbn) {
                    throw new Error();
                }

                if (!book.genre) {
                    throw new Error();
                }
            });

            super.add(books);
            return this;
        }

        getGenres() {
            const genres = [];
            this.items.forEach(book => {
                const genre = book.genre.toLowerCase();
                if (genres.indexOf(genre) < 0) {
                    genres.push(genre);
                }
            });

            return genres;
        }

        find(options) {
            let filtered = super.find(options);

            if (options.genre) {
                filtered = filtered.filter(item => {
                    const isMatch = item.genre.toLowerCase() === options.genre.toLowerCase();
                    return isMatch;
                });
            }

            return filtered;
        }
    }

    class MediaCatalog extends Catalog {
        constructor(name) {
            super(name);
        }
    }

    const module = {
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

    return module;
}

module.exports = solve;