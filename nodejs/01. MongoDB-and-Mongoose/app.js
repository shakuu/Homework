/* globals require */
const fs = require('fs');
const mongoose = require('mongoose');

const convertJsonToEmployee = require('./converter/convert-json-to-employee');
const executeQueryTask = require('./mongoose/queries');
const generateEmployees = require('./generate-json/generate-employees');
const getEmployeeModel = require('./models/employee-model');
const readJsonFromFile = require('./filesystem/read-json');
const saveEmployeesToMongo = require('./mongoose/save-employees-to-mongo');
const writeJsonToFile = require('./filesystem/write-json');

const employees = generateEmployees(999);
for (let i = 0; i < employees.length; i += 1) {
  writeJsonToFile(i + 1, employees[i]);
}

// Attach model to Mongoose object.
getEmployeeModel(mongoose);
const employeesFromJson = [];
const directories = fs.readdirSync('json');
for (const dir of directories) {
  const json = readJsonFromFile(dir);
  const employee = convertJsonToEmployee(json, mongoose);
  employeesFromJson.push(employee);
}

saveEmployeesToMongo(mongoose, employeesFromJson);

executeQueryTask(mongoose);