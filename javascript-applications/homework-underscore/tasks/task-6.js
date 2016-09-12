/* 
Create a function that:
*   **Takes** a collection of books
    *   Each book has propeties `title` and `author`
        **  `author` is an object that has properties `firstName` and `lastName`
*   **finds** the most popular author (the author with biggest number of books)
*   **prints** the author to the console
	*	if there is more than one author print them all sorted in ascending order by fullname
		*   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/
const _ = require('underscore');
function solve() {
    'use strict()';
    return function (books) {
        const result = _.chain(books)
            .map(item => item.author)
            .map(author => author.firstName + ' ' + author.lastName)
            .groupBy(author => author)
            .value();

        const maxLength = _.max(result, author => author.length).length;
        let allAuthorsWithMostBooks = _.chain(result)
            .filter(author => author.length === maxLength)
            .map(author => author[0])
            .sortBy(author => author)
            .each(author => console.log(author));
    };
}

module.exports = solve;
