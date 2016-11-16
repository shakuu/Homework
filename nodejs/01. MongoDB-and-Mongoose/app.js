/* globals require console*/
const mongoose = require('mongoose');

const convertJsonToEmployee = require('./converter/convert-json-to-employee');
const generateEmployees = require('./generate-json/generate-employees');
const readJsonFromFile = require('./filesystem/read-json');
const writeJsonToFile = require('./filesystem/write-json');
const saveEmployeesToMongo = require('./mongoose/save-employees-to-mongo');

const employees = generateEmployees(3);
for (const emp of employees) {
  writeJsonToFile(emp.firstName + emp.lastName, emp);
}

const json = readJsonFromFile('FirstName.json');
const emp = convertJsonToEmployee(json, mongoose);

saveEmployeesToMongo(mongoose, [emp]);