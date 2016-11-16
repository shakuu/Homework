/* globals require module*/
const fs = require('fs');

function readJsonFromFile(fileName) {
  const content = fs.readFileSync(`json/${fileName}`, 'utf8');
  const object = JSON.parse(content);
  return object;
}

module.exports = readJsonFromFile;