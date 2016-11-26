'use strict';

const mongoose = require('mongoose');

const fractionSchema = new mongoose.Schema({
  name: String,
  alignment: {
    type: String,
    enum: ['good', 'evil', 'neutral']
  },
  planets: [String]
});

let Fraction;
fractionSchema.static('getFraction', (fraction) => {
   return new Fraction({
    name: fraction.name,
    alignment: fraction.alignment,
    planets: fraction.planets
  });
});

mongoose.model('Fraction', fractionSchema);
Fraction = mongoose.model('Fraction');

module.exports = Fraction;