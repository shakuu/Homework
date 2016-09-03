const result = require('./tasks/task-1')();

var gotten,
    name = 'Rock and roll',
    plName = 'Banana Rock',
    plAuthor = 'Wombles',
    playlist = result.getPlaylist(name),
    playable = { id: 1, name: plName, author: plAuthor };

playlist.addPlayable(playable);
playlist.removePlayable(playable);
