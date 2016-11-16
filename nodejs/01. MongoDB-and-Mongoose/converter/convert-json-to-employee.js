/* globals require module*/
function convertJsonToEmployee(json, mongoose) {
  const Employee = mongoose.model('Employee');

  const newEmployee = new Employee({
    firstName: json.firstName,
    middleName: json.middleName,
    lastName: json.lastName,
    insuranceNumber: json.insuranceNumber,
    age: json.age,
    contactDetails: json.contactDetails,
    itemsForSale: json.itemsForSale,
    itemsReceived: json.itemsReceived
  });
  
  return newEmployee;
}

module.exports = convertJsonToEmployee;