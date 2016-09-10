'use strict';
function solve() {
	function* IdGenerator() {
		let lastId = 0;
		while (true) {
			yield lastId += 1;
		}
	}

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

			this.playlists.splice(indexToRemove, 1);
			return this;
		}
	}

	const playerIdGenerator = IdGenerator();
    class Player extends Container {
        constructor(name) {
			super(name);
			this.id = playerIdGenerator.next().value;
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

		}

		contains(playable, playlist) {

		}

		search(pattern) {

		}
	}

	const playlistIdGenerator = IdGenerator();
	class PlayList extends Container {
		constructor(name) {
			super(name);
			this.id = playerIdGenerator.next().value;
		}

		addPlayable(playable) {
			if (playable === undefined) {
				throw new Error();
			}

			if (!(playable instanceof Playable)) {
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

		}
	}

	const playableIdGenerator = IdGenerator();
	class Playable {
		constructor(title, author) {
			this.id = playableIdGenerator.next().value;

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
			//returns a new audio instance with the provided title, author and length
		},
		getVideo: function (title, author, imdbRating) {
			//returns a new video instance with the provided title, author and imdbRating
		}
	};

    return module;
}

module.exports = solve;