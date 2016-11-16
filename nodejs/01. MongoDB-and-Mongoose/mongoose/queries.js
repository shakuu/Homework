/* globals module console*/
const protocol = 'mongodb:/';
const location = 'localhost:27017';
const database = 'employees';
const connectionString = `${protocol}/${location}/${database}`;

function executeQueryTask(mongoose) {
  mongoose.connect(connectionString);
  mongoose.model('Employee')
    .find({ firstName: /[ABPG]+/ })
    .where('age').gt(18).lt(28)
    .where('contactDetails.emailAddress').equals(/@progress.com/)
    .where('contactDetails.phoneNumber').equals(/359/)
    // .where('itemsForSale').count(1).gt(0)
    .exec((err, savedEmployees) => {
      if (err) {
        console.log(err.message);
      }

      mongoose.disconnect();
      savedEmployees
        .filter(e => e.itemsForSale.length >= 1)
        .sort(e => e.itemsForSale.length)
        .slice(0, 2)
        .forEach(e => {
          console.log(e.fullName);
        });
    });
}

module.exports = executeQueryTask;