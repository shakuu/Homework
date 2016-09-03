const result = require('./tasks/task-1')();

var i, name, playlist;
name = 'Hard Rock';
playlist = result.getPlaylist(name);

for (i = 0; i < 35; i += 1) {
    playlist.addPlayable({ id: (i + 1), title: 'Rock' + (9 - (i % 10)) });
}

var len =playlist.listPlayables(2, 10).length;
console.log(len);
// expect(playlist.listPlayables(2, 10).length).to.equal(10);
// expect(playlist.listPlayables(3, 10).length).to.equal(5);

// expect(function () { playlist.listPlayables(-1, 10) }).to.throw();
// expect(function () { playlist.listPlayables(5, 10) }).to.throw();
// expect(function () { playlist.listPlayables(1, -1) }).to.throw();
