/* globals require */

const mongoose = require('mongoose');

const protocol = 'mongodb:/';
const location = 'localhost:27017';
const database = 'computers';
const connectionString = `${protocol}/${location}/${database}`;

mongoose.connect(connectionString);