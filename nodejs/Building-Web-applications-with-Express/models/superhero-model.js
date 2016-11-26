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

const fractionSchema = new mongoose.Schema({
  planets: [planetSchema],
  superheroes: [String],
  alignment: {
    type: String,
    enum: ['good', 'evil', 'neutral']
  }
});

const superheroSchema = new mongoose.Schema({
  name: {
    type: String
  },
  secretIdentity: {
    type: String,
    unique: true
  },
  city: String,
  alignment: {
    type: String,
    enum: ['good', 'evil', 'neutral']
  },
  story: {
    type: String
  },
  image: String,
  fractions: [String],
  powers: [String]
});

let Superhero;
superheroSchema.static('getSuperhero', (superhero) => {
  return new Superhero({
    name: superhero.name,
    secretIdentity: superhero.secretIdentity,
    city: superhero.city,
    image: superhero.image,
    alignment: superhero.alignment,
    story: superhero.story,
    fractions: superhero.fractions,
    powers: superhero.powers
  });
});

mongoose.model('Superhero', superheroSchema);

Superhero = mongoose.model('Superhero');
module.exports = mongoose.model('Superhero');