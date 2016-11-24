/* globals Promise */

module.exports = function (User) {
  function create(username, displayName, image) {
    const user = new User({
      username: username,
      displayName: displayName,
      image: image
    });

    return new Promise((resolve, reject) => {
      user.save((err) => {
        if (err) {
          return reject(err);
        }

        return resolve(user);
      });
    });
  }

  function findByUsername(username) {
    return new Promise((resolve, reject) => {
      User.find({ username }, (err, user) => {
        if (err) {
          return reject(err);
        }

        return resolve(user);
      });
    });
  }

  function all() {
    return new Promise((resolve, reject) => {
      User.find((err, users) => {
        if (err) {
          return reject(err);
        }

        return resolve(users);
      });
    });
  }

  return {
    create,
    findByUsername,
    all
  };
};