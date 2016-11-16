/* globals require console*/

// const mongoose = require('mongoose');

// const protocol = 'mongodb:/';
// const location = 'localhost:27017';
// const database = 'computers';
// const connectionString = `${protocol}/${location}/${database}`;

// mongoose.connect(connectionString);

// const getEomployeeModel = require('./models/employee-model');
// const Employee = getEomployeeModel(mongoose);

// const employee = new Employee();
// employee.save((err, res)=>{
//   if(err){
//     console.log(err.message);
//   }
// });

const generateEmployees = require('./generate-json/generate-employees');
const writeJsonToFile = require('./filesystem/write-json');

const employees = generateEmployees(3);
for (const emp of employees) {
  writeJsonToFile(emp.firstName + emp.lastName, emp);
}

console.log(employees);