function solve() {
    function* IdGenerator() {
        let lastId = 0;
        while (true) {
            yield lastId += 1;
        }
    }

    function isValidString(name) {
        if (typeof name !== 'string') {
            throw new Error();
        }

        const nameLength = name.length;
        if (!(3 <= nameLength && nameLength <= 25)) {
            throw new Error();
        }
    }

    const playerIdGenerator = IdGenerator();
    class Player {
        constructor(name) {
            isValidString(name);
            this.name = name;
            this.id = playerIdGenerator.next().value;

            this.playlists = [];
        }

        addPlaylist(playlistToAdd) {
            if (!(playlistToAdd instanceof Playlist)) {
                throw new Error();
            }

            this.playlists.push(playlistToAdd);
            return this;
        }

        getPlaylistById(id) {
            const matchingId = this.playlists.filter(playlist => {
                return playlist.id === id;
            });

            let result;
            if (matchingId.length === 0) {
                result = null;
            } else {
                result = matchingId[0];
            }

            return result;
        }

        removePlaylist(playlist) {
            let id;
            if (playlist.id) {
                id = playlist.id;
            } else {
                id = playlist;
            }

            let isRemoved = false;
            this.playlists = this.playlists.filter(playlist => {
                if (playlist.id === id) {
                    isRemoved = true;
                    return false;
                }
            });

            if (!isRemoved) {
                throw new Error();
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

    const playlistIdGenerator = IdGenerator();
    class Playlist {
        constructor(name) {
            isValidString(name);
            this.name = name;
            this.id = playlistIdGenerator.next().value;

            this.playables = [];
        }

        addPlayable(playable) {
            this.playables.push(playable);
            return this;
        }

        getPlayableById(id) {
            const matches = this.playables.filter(playable => {
                return playable.id === id;
            });

            let result;
            if (matches.length === 0) {
                result = null;
            } else {
                result = matches[0];
            }

            return result;
        }

        removePlayable(playable) {
            let id;
            if (playable.id) {
                id = playable.id;
            } else {
                id = playable;
            }

            let isRemoved = false;
            this.playables = this.playables.filter(playable => {
                if (playable.id === id) {
                    isRemoved = true;
                    return false;
                }
            });

            if (!isRemoved) {
                throw new Error();
            }

            return this;
        }
    }

    const playableIdGenerator = IdGenerator();
    class Playable {
        constructor(title, author) {
            isValidString(title);
            isValidString(author);

            this.title = title;
            this.author = author;
            this.id = playableIdGenerator.next().value;
        }

        play() {
            if (!this._superPlay) {
                this._superPlay = `${this.id}. ${this.title} - ${this.author}`;
            }

            return this._superPlay;
        }
    }

    class Audio extends Playable {
        constructor(title, author, length) {
            super(title, author);

            length = Number(length);
            if (isNaN(length)) {
                throw new Error();
            }

            if (length <= 0) {
                throw new Error();
            }

            this.length = length;
        }

        play() {
            if (!this._audioPlay) {
                this._audioPlay = `${super.play()} - ${this.length}`;
            }

            return this._audioPlay;
        }
    }

    class Video extends Playable {
        constructor(title, author, imdbRating) {
            super(title, author);

            imdbRating = Number(imdbRating);
            if (isNaN(imdbRating)) {
                throw new Error();
            }

            if (!(1 <= imdbRating && imdbRating <= 5)) {
                throw new Error();
            }

            this.imdbRating = imdbRating;
        }

        play() {
            if (!this._videoPlay) {
                this._videoPlay = `${super.play()} - ${this.imdbRating}`;
            }

            return this._videoPlay;
        }
    }

    return {
        getPlayer: function (name) {
            return new Player(name);
        },
        getPlaylist: function (name) {
            return new Playlist(name);
        },
        getAudio: function (title, author, length) {
            return new Audio(title, author, length);
        },
        getVideo: function (title, author, imdbRating) {
            return new Video(title, author, imdbRating);
        }
    };
}

module.exports = solve;