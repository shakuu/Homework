'use strict';
function solve() {
	const validator = (() => {
		const NAME_LENGTH = {
			MIN: 3,
			MAX: 25
		};

		return {
			validateInstanceOf(obj, type) {
				const result = obj instanceof type;
				return result;
			},
			validateName(name) {
				if (name === undefined) {
					throw new Error('name is undefined');
				}

				if (typeof name !== 'string') {
					throw new Error('name is not a string');
				}

				if (!(NAME_LENGTH.MIN <= name.length && name.length <= NAME_LENGTH.MAX)) {
					throw new Error('incorrect name length');
				}
			}
		};
	})();

	function* IdProvider() {
		let lastId = 0;
		while (true) {
			yield lastId += 1;
		}
	}

	const playerIdPrivider = IdProvider();
	class Player {
		constructor(name) {
			this.id = playerIdPrivider.next().value;
			this.name = name;

			this._playlists = [];
			return this;
		}

		get name() {
			return this._name;
		}

		set name(value) {
			validator.validateName(value);
			this._name = value;
		}

		addPlaylist(playlistToAdd) {
			const inputIsPlayList = validator.validateInstanceOf(playlistToAdd, PlayList);
			if (!inputIsPlayList) {
				throw new Error('Input must be of type PlayList');
			}

			this._playlists.push(playlistToAdd);
			return this;
		}

		getPlaylistById(id) {
			const matches = this._playlists.filter((item) => {
				const isMatch = item.id === id;
				return isMatch;
			});

			let matchingPlaylist = null;
			if (matches.length > 0) {
				matchingPlaylist = matches[0];
			}

			return matchingPlaylist;
		}

		removePlaylist(playlist) {
			let id = playlist.id || playlist;
			let isRemoved = false;
			this._playlists = this._playlists.filter((item) => {
				const isMatch = item.id === id;
				if (isMatch) {
					isRemoved = true;
				}
				
				return !isMatch;
			});

			if (!isRemoved) {
				throw new Error('Playlist with id not found');
			}

			return this;
		}

		listPlaylists(page, size) {

		}

		contains(playable, playlist) {

		}

		search(pattern) {

		}
	}

	const playlistIdProvider = IdProvider();
	class PlayList {
		constructor(name) {
			this.id = playlistIdProvider.next().value;
			this.name = name;

			this._playables = [];
		}
	}

	const playableIdProivider = IdProvider();
	class Playable {
		constructor(title, author) {
			this.id = playableIdProivider.next().value();

			this.title = title;
			this.author = author;
		}

		play() {
			const message = `${this.id}. ${this.title} - ${this.author}`;
			return message;
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
			const length = Number(value);
			if (isNaN(length)) {
				throw new Error();
			}

			if (length <= 0) {
				throw new Error();
			}

			this._length = value;
		}

		play() {
			const message = `${super.play()} - ${this.length}`;
			return message;
		}
	}

	class Video extends Playable {
		constructor(title, author, imdbRating) {
			super(title, author);

			this.imdbRating = imdbRating;
		}

		get imdbRating() {
			return this._rating;
		}

		set imdbRating(value) {
			const rating = Number(value);
			if (isNaN(rating)) {
				throw new Error();
			}

			if (!(1 <= rating && rating <= 5)) {
				throw new Error();
			}

			this._rating = value;
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