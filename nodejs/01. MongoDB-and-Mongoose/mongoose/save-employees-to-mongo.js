/* globals module Promise*/
const protocol = 'mongodb:/';
const location = 'localhost:27017';
const database = 'employees';
const connectionString = `${protocol}/${location}/${database}`;

function saveEmployeesToMongo(mongoose, employees) {
  mongoose.connect(connectionString);
  return new Promise((resolve, reject) => {
    mongoose.model('Employee').insertMany(employees, (err, res) => {
      if (err) {
        reject(err);
      }

      mongoose.disconnect();
      resolve();
    });
  });
}

module.exports = saveEmployeesToMongo;