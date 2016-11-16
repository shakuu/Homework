/* globals require module*/
const fs = require('fs');

function readJsonFromFile(fileName) {
  const content = fs.readFileSync(fileName, 'utf8');
  const object = JSON.parse(content);
  return object;
}

module.exports = readJsonFromFile;