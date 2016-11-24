// Each superhero has name, secret identity, city that protects, alignment , story, image, a list of fractions and a list of powers
const mongoose = require('mongoose');

const powerSchema = new mongoose.Schema({
  name: {
    type: String,
    match: /[.]{3,35}/,
    unique: true
  }
});

const planetSchema = new mongoose.Schema({
  name: {
    type: String,
    match: /[.]{3,20}/,
    required: true,
    unique: true
  }
});

const countrySchema = new mongoose.Schema({
  name: {
    type: String,
    match: /[.]{3,20}/,
    required: true,
    unique: true
  },
  planet: planetSchema
});

const citySchema = new mongoose.Schema({
  name: {
    type: String,
    match: /[.]{3,20}/,
    required: true,
    unique: true
  },
  country: countrySchema
});

let superheroSchema;

const fractionSchema = new mongoose.Schema({
  planets: [planetSchema],
  superheroes: [superheroSchema],
  alignment: {
    type: String,
    enum: ['good', 'evil', 'neutral']
  }
});

superheroSchema = new mongoose.Schema({
  name: {
    type: String,
    match: /[.]{3,60}/
  },
  secretIdentity: {
    type: String,
    match: /[.]{3,20}/,
    unique: true
  },
  city: {
    type: citySchema
  },
  alignment: {
    type: String,
    enum: ['good', 'evil', 'neutral']
  },
  story: {
    type: String,
    match: /.+/
  },
  image: {
    type: String,
  },
  fractions: [fractionSchema],
  powers: [powerSchema]
});

mongoose.model('Superhero', superheroSchema);

module.exports = mongoose.model('Superhero');