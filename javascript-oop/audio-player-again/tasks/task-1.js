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
			},
			validatePagingInput(dataLength, page, size) {
				if (isNaN(page) || isNaN(size)) {
					throw new Error();
				}

				if (dataLength < page * size) {
					throw new Error();
				}

				if (page < 0) {
					throw new Error();
				}

				if (size <= 0) {
					throw new Error();
				}
			}
		};
	})();

	const utils = (() => {
		return {
			extractPage(data, page, size) {
				let list = [];
				for (let i = 0; i < size; i += 1) {
					const nextIndex = (page * size) + i;
					if (data[nextIndex]) {
						list.push(data[nextIndex]);
					} else {
						break;
					}
				}

				return list;
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
			page = Number(page);
			size = Number(size);
			validator.validatePagingInput(this._playlists.length, page, size);

			const list = utils.extractPage(this._playlists, page, size);
			return list;
		}

		contains(playable, playlist) {
			const playableFromPlaylist = playlist.getPlayableById(playable.id);
			const result = playableFromPlaylist ? true : false;
			return result;
		}

		search(pattern) {
			pattern = pattern.toLowerCase();

			const list = [];
			this._playlists.forEach((item) => {
				const isMatch = item.some((playable) => {
					const title = playable.title.toLowerCase();
					const isTitleMatch = title.indexOf(pattern) >= 0;
					return isTitleMatch;
				});

				if (isMatch) {
					list.push(item);
				}
			});

			return list;
		}
	}

	const playlistIdProvider = IdProvider();
	class PlayList {
		constructor(name) {
			this.id = playlistIdProvider.next().value;
			this.name = name;

			this._playables = [];
		}

		get name() {
			return this._name;
		}

		set name(value) {
			validator.validateName(value);
			this._name = value;
		}

		addPlayable(playable) {
			this._playables.push(playable);
			return this;
		}

		getPlayableById(id) {
			const matches = this._playables.filter((item) => {
				const isMatch = item.id === id;
				return isMatch;
			});

			let matchingPlayable = null;
			if (matches.length > 0) {
				matchingPlayable = matches[0];
			}

			return matchingPlayable;
		}

		removePlayable(playable) {
			let id = playable.id || playable;
			let isRemoved = false;
			this._playables = this._playables.filter((item) => {
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

		listPlayables(page, size) {
			page = Number(page);
			size = Number(size);
			validator.validatePagingInput(this._playables.length, page, size);

			const list = utils.extractPage(this._playables, page, size);
			return list;
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