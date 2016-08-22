/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	'use strict';
	var library = (function () {
		var books = [],
			categories = [];

		function listBooks(args) {
			if (args && args.category) {
				return books.filter(function (el) {
					return el.category === args.category;
				});
			}

			if (args && args.author) {
				return books.filter(function (el) {
					return el.author === args.author;
				});
			}

			return books;
		}

		function addBook(book) {
			book.ID = books.length + 1;

			if (!book.title || book.title.length < 2 || book.title.length > 100) {
				throw new Error();
			}

			if (book.isbn.length !== 10 && book.isbn.length !== 13) {
				throw new Error();
			}

			if (!book.author) {
				throw new Error();
			}

			if (validateUniqueISBN(book)) {
				throw new Error();
			}

			if (validateUniqueTitle(book)) {
				throw new Error();
			}

			if (!categories.some(function (el) { return book.category === el; })) {
				categories.push(book.category);
			}

			books.push(book);
			return book;
		}

		function validateUniqueISBN(book) {
			var books = listBooks();

			return books.some(function (el) {
				return el.isbn === book.isbn;
			});
		}

		function validateUniqueTitle(book) {
			var books = listBooks();

			return books.some(function (el) {
				return el.title === book.title;
			});
		}

		function listCategories() {
			return categories;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}
module.exports = solve;
