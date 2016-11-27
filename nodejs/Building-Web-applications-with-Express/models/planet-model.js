'use strict';

const mongoose = require('mongoose');

const planetSchema = new mongoose.Schema({
  name: String,
  countries: [{
    name: String,
    cities: [String]
  }]
});

let Planet;
planetSchema.static('getPlanet', (planet) => {
  return new Planet({
    name: planet.name,
    countries: planet.countries
  });
});

mongoose.model('Planet', planetSchema);
Planet = mongoose.model('Planet');

module.exports = Planet;