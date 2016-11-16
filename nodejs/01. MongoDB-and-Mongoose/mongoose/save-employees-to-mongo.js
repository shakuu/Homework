/* globals module console*/
const protocol = 'mongodb:/';
const location = 'localhost:27017';
const database = 'computers';
const connectionString = `${protocol}/${location}/${database}`;

function saveEmployeesToMongo(mongoose, employees) {
  mongoose.connect(connectionString);
  mongoose.model('Employee').insertMany(employees, (err, res) => {
    if (err) {
      console.log(err.message);
    }

    mongoose.disconnect();
  });
}

module.exports = saveEmployeesToMongo;