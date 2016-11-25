/* globals Promise */

module.exports = function (User) {
  function create(inputUser) {
    const user = User.getUser(inputUser);

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
      User.find({
        username
      }, (err, user) => {
        if (err) {
          return reject(err);
        }

        return resolve(user);
      });
    });
  }

  function findById(id) {
    return new Promise((resolve, reject) => {
      User.find({
        _id: id
      }, (err, user) => {
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
    findById,
    all
  };
};