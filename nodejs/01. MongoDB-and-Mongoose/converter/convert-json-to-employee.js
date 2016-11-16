/* globals require module*/
const getEmployeeModel = require('../models/employee-model');

function convertJsonToEmployee(json, mongoose) {
  const Employee = getEmployeeModel(mongoose);

  const newEmployee = new Employee({
    firstName: json.firstName,
    middleName: json.middleName,
    lastName: json.lastName,
    insuranceNumber: json.insuranceNumber,
    age: json.age,
    contactDetais: json.contactDetais,
    itemsForSale: json.itemsForSale,
    itemsReceived: json.itemsReceived
  });

  return newEmployee;
}

module.exports = convertJsonToEmployee;