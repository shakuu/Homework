'use strict';
function solve() {

    class Player {
        constructor(name) {
			this.name = name;

			this.playlists = [];
        }

		addPlaylist(playlistToAdd) {
			if (!(playlistToAdd instanceof PlayList)) {
				throw new Error('must be instance of PlayList');
			}

			this.playlists.push(playlistToAdd);
			return this;
		}

		getPlaylistById(id) {
			id = Number(id);
			if (isNaN(id)) {
				throw new Error('id must be a number.');
			}

			const item = this.playlists.find(item => item.id === id) || null;
			return item;
		}

		removePlaylist(playlist) {
			if (playlist === undefined) {
				throw new Error();
			}

			let id;
			if (typeof playlist === 'object') {
				id = playlist.id;
			} else {
				id = playlist;
			}

			id = Number(id);
			if (isNaN(id)) {
				throw new Error();
			}

			const indexToRemove = this.playlists.findIndex(item => item.id === id);
			if (indexToRemove < 0) {
				throw new Error();
			}

			this.playlists.splice(indexToRemove, 1);
			return this;
		}
    }

	class PlayList {
		constructor() {

		}
	}

    const module = {
		getPlayer: function (name) {
			// returns a new player instance with the provided name
		},
		getPlaylist: function (name) {
			//returns a new playlist instance with the provided name
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