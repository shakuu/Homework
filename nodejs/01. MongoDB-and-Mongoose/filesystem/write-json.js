/* globals require module console*/
const fs = require('fs');

function writeJsonToFile(fileName, object) {
  const directoryExists = fs.existsSync('json');
  if (!directoryExists) {
    fs.mkdirSync('json', (err) => {
      if (err) {
        console.log(err.message);
      }
    });
  }

  if (object) {
    fs.writeFileSync(`json/${fileName}.json`, JSON.stringify(object, null, 2));
  }
}

module.exports = writeJsonToFile;
