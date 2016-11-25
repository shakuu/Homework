'use strict';

const mongoose = require('mongoose');

// Each user has username, display name and image (or just a link to such)
const userSchema = new mongoose.Schema({
  username: {
    type: String,
    minlength: 3,
    maxlength: 15,
    required: true
  },
  password: {
    type: String,
    minlength: 3,
    maxlength: 15
  },
  displayName: {
    type: String,
    minlength: 3,
    maxlength: 15,
    required: true
  },
  image: {
    type: String
  }
});

userSchema.method('verifyPassword', (password) => {
  return password === this.password;
});

let User;
userSchema.static('getUser', (user) => {
  return new User({
    username: user.username,
    password: user.password,
    image: user.image,
    displayName: user.displayName
  });
});

mongoose.model('User', userSchema);
User = mongoose.model('User');
module.exports = mongoose.model('User');