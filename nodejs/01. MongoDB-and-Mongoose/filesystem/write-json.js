/* globals require module*/
const fs = require('fs');

function writeJsonToFile(fileName, object) {
  fs.writeFile(`${fileName}.json`, JSON.stringify(object, null, 2));
}

module.exports = writeJsonToFile;
