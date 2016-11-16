/* globals require module*/
// const mongoose = require('mongoose');

function getEmployeeModel(mongoose) {
  const contactDetailsSchema = mongoose.Schema({
    phoneNumber: {
      type: String,
      match: /([0-9]{3}\s{1})+/
    },
    emailAddress: {
      required: true,
      type: String,
      match: /^[-a-z0-9~!$%^&*_=+}{\'?]+(\.[-a-z0-9~!$%^&*_=+}{\'?]+)*@([a-z0-9_][-a-z0-9_]*(\.[-a-z0-9_]+[a-z][a-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?$/i
    },
    roomNumber: {
      required: true,
      type: Number,
      min: 100,
      max: 999
    }
  });

  const itemForSaleSchema = mongoose.Schema({
    itemName: {
      type: String,
      required: true,
      match: /[a-zA-z]+/
    },
    itemPrice: {
      type: Number
    },
    giveAwayStatus: {
      type: String,
      required: true,
      enum: ['Give away', 'For Sale']
    },
    startDate: {
      type: Date,
      default: Date.now
    },
    endDate: {
      type: Date,
      default: dateNowPlusOneMonth
    }
  });

  const itemReceivedSchema = mongoose.Schema({
    name: String
  });

  const employeeSchema = mongoose.Schema({
    firstName: {
      required: true,
      type: String,
      match: /[A-Z][a-z]*/
    },
    middleName: {
      required: true,
      type: String,
      match: /[A-Z][a-z]*/
    },
    lastName: {
      required: true,
      type: String,
      match: /[A-Z][a-z]*/
    },
    insuranceNumber: {
      type: String,
      required: true,
      match: /[A-Za-z0-9-]*/
    },
    age: {
      type: Number,
      min: 0,
      max: 120
    },
    contactDetais: {
      type: contactDetailsSchema
    },
    itemsForSale: [itemForSaleSchema],
    itemsReceived: [itemReceivedSchema]
  });

  function dateNowPlusOneMonth() {
    const dateNow = new Date();
    const dateNowWithOneMonthAdded = dateNow.setMonth(dateNow.getMonth() + 1);
    return dateNowWithOneMonthAdded;
  }

  const Employee = mongoose.model("Employee", employeeSchema);

  return Employee;
}

module.exports = getEmployeeModel;