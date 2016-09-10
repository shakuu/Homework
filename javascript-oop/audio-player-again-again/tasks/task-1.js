'use strict';
function solve() {
	const validator = (() => {
		const NAME_LENGTH = {
			MIN: 3,
			MAX: 25
		};

		return {
			validateName(value) {
				if (value === undefined) {
					throw new Error();
				}

				if (typeof value !== 'string') {
					throw new Error();
				}

				if (!(NAME_LENGTH.MIN <= value.length && value.length <= NAME_LENGTH.MAX)) {
					throw new Error();
				}
			}
		};
	})();

	const idProvider = (() => {
		function* Generator() {
			let lastId = 0;
			while (true) {
				yield lastId += 1;
			}
		}

		const generators = {};
		return {
			getNext(identifier) {
				if (!generators[identifier]) {
					generators[identifier] = Generator();
				}

				const next = generators[identifier].next().value;
				return next;
			}
		};
	})();

	const NameableMixin = (() => {
		return Base => class extends Base {
			constructor(name, args) {
				super(args);

				this.name = name;
			}

			get name() {
				return this._name;
			}

			set name(value) {
				validator.validateName(value);
				this._name = value;
			}
		};
	})();

	class Container extends NameableMixin(Object) {
		constructor(name) {
			super(name);

			this.items = [];
		}

		addItem(itemToAdd) {
			this.items.push(itemToAdd);
			return this;
		}

		getItemById(id) {
			id = Number(id);
			if (isNaN(id)) {
				throw new Error('id must be a number.');
			}

			const item = this.items.find(item => item.id === id) || null;
			return item;
		}

		removeItem(item) {
			if (item === undefined) {
				throw new Error();
			}

			let id;
			if (typeof item === 'object') {
				id = item.id;
			} else {
				id = item;
			}

			id = Number(id);
			if (isNaN(id)) {
				throw new Error();
			}

			const indexToRemove = this.items.findIndex(item => item.id === id);
			if (indexToRemove < 0) {
				throw new Error();
			}

			this.items.splice(indexToRemove, 1);
			return this;
		}

		list(page, size) {
			page = Number(page);
			size = Number(size);
			if (isNaN(page) || isNaN(size)) {
				throw new Error();
			}

			if (page * size > this.items.length) {
				throw new Error();
			}

			if (page < 0) {
				throw new Error();
			}

			if (size <= 0) {
				throw new Error();
			}

			this.items.sort((a, b) => {
				const compareTitle = a.title > b.title ? 1 : a === b ? 0 : -1;
				if (compareTitle !== 0) {
					return compareTitle;
				} else {
					return a.id - b.id;
				}
			});

			const output = [];
			for (let i = 0; i < size; i += 1) {
				const index = page * size + i;

				if (this.items[index]) {
					output.push(this.items[index]);
				} else {
					break;
				}
			}

			return output;
		}
	}

    class Player extends Container {
        constructor(name) {
			super(name);
			this.id = idProvider.getNext(this.constructor.name);
        }

		addPlaylist(playlistToAdd) {
			if (playlistToAdd === undefined) {
				throw new Error();
			}

			if (!(playlistToAdd instanceof PlayList)) {
				throw new Error('must be instance of PlayList');
			}

			super.addItem(playlistToAdd);
			return this;
		}

		getPlaylistById(id) {
			const item = super.getItemById(id);
			return item;
		}

		removePlaylist(playlist) {
			super.removeItem(playlist);
			return this;
		}

		listPlaylists(page, size) {
			const list = super.list(page, size);
			return list;
		}

		contains(playable, playlist) {

		}

		search(pattern) {

		}
	}

	class PlayList extends Container {
		constructor(name) {
			super(name);
			this.id = idProvider.getNext(this.constructor.name);
		}

		addPlayable(playable) {
			if (playable === undefined) {
				throw new Error();
			}

			super.addItem(playable);
			return this;
		}

		getPlayableById(id) {
			const item = super.getItemById(id);
			return item;
		}

		removePlayable(playable) {
			super.removeItem(playable);
			return this;
		}

		listPlayables(page, size) {
			const list = super.list(page, size);
			return list;
		}
	}

	class Playable {
		constructor(title, author) {
			this.id = idProvider.getNext(this.constructor.name);	

			this.title = title;
			this.author = author;
		}

		get title() {
			return this._title;
		}

		set title(value) {
			validator.validateName(value);
			this._title = value;
		}

		get author() {
			return this._author;
		}

		set author(value) {
			validator.validateName(value);
			this._author = value;
		}

		play() {
			const result = `${this.id}. ${this.title} - ${this.author}`;
			return result;
		}
	}

	class Audio extends Playable {
		constructor(title, author, length) {
			super(title, author);

			this.length = length;
		}

		get length() {
			return this._length;
		}

		set length(value) {
			value = Number(value);
			if (isNaN(value)) {
				throw new Error();
			}

			if (value <= 0) {
				throw new Error();
			}

			this._length = value;
		}

		play() {
			const result = `${super.play()} - ${this.length}`;
			return result;
		}
	}

	class Video extends Playable {
		constructor(title, author, imdbRating) {
			super(title, author);

			this.imdbRating = imdbRating;
		}

		get imdbRating() {
			return this._imdbRating;
		}

		set imdbRating(value) {
			value = Number(value);
			if (isNaN(value)) {
				throw new Error();
			}

			if (!(1 <= value && value <= 5)) {
				throw new Error();
			}

			this._imdbRating = value;
		}
	}

    const module = {
		getPlayer: function (name) {
			return new Player(name);
		},
		getPlaylist: function (name) {
			return new PlayList(name);
		},
		getAudio: function (title, author, length) {
			return new Audio(title, author, length);
		},
		getVideo: function (title, author, imdbRating) {
			return new Video(title, author, imdbRating);
		}
	};

    return module;
}

module.exports = solve;