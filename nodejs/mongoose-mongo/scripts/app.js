/*globals require console */

const MongoClient = require('mongodb').MongoClient;

const protocol = 'mongodb:/';
const location = 'localhost:27017';
const database = 'computers';
const connectionString = `${protocol}/${location}/${database}`;

MongoClient.connect(connectionString, (err, db) => {
  if (err) {
    throw err;
  }

  db.collection('laptops').insert({
    "name": "asus",
    "model": "x453ma"
  });
});

const mongoose = require('mongoose');
mongoose.connect(connectionString);

const computerSchema = mongoose.Schema({
  "model": String,
  "vendor": {
    type: String,
    trim: true,
    required: true
  }
});

const Computer = mongoose.model("Computer", computerSchema);

var pc = new Computer({
  model: 123,
  vendor: 'one'
});

pc.save((err, createdComputer) => {
  if (err) {
    console.log(err.message);
  }

  console.log(createdComputer);
});

pc.validate((err) => {
  if (err) {
    console.log(err);
  }
});