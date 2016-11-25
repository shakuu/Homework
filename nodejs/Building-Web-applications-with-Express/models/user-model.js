const mongoose = require('mongoose');

// Each user has username, display name and image (or just a link to such)
const userSchema = new mongoose.Schema({
  username: {
    type: String,
    required: true
  },
  displayName: {
    type: String,
    required: true
  },
  image: {
    type: String
  }
});

userSchema.method('verifyPassword', (password) => {
  return true;
});

mongoose.model('User', userSchema);

module.exports = mongoose.model('User');