/*globals require console */

const MongoClient = require('mongodb').MongoClient;

const protocol = 'mongodb:/';
const location = 'localhost:27017';
const database = 'computers';
const connectionString = `${protocol}/${location}/${database}`;

MongoClient.connect(connectionString, (err, result) => {
    if (err) {
        throw err;
    }

    result.collection('laptops').insert({
      "name": "asus",
      "model" : "x453ma"
    });
});