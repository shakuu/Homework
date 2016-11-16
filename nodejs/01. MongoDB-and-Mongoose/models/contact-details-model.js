/* globals require module*/

const mongoose = require('mongoose');

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

const ContactDetails = mongoose.model("contactDetails", contactDetailsSchema);

module.exports = ContactDetails;