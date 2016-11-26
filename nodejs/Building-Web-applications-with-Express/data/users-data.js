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
      User.findOne({
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
      User.findOne({
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

  function updateImage(user, imageUrl) {
    return new Promise((resolve, reject) => {
      User.update({
        _id: user._id
      }, {
        $set: {
          image: imageUrl
        }
      }, (err, updatedUser) => {
        if (err) {
          return reject(err);
        }

        return resolve(updatedUser);
      });
    });
  }

  function updateDisplayName(user, displayName) {
    return new Promise((resolve, reject) => {
      User.update({
        _id: user._id
      }, {
        $set: {
          displayName: displayName
        }
      }, (err, updatedUser) => {
        if (err) {
          return reject(err);
        }

        return resolve(updatedUser);
      });
    });
  }

  function updateUser(user) {
    return new Promise((resolve, reject) => {
      user.save((err) => {
        if (err) {
          return reject(err);
        }

        return resolve(user);
      });
    });
  }

  return {
    create,
    findByUsername,
    findById,
    all,
    updateUser,
    updateImage,
    updateDisplayName
  };
};