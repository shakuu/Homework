/* globals  module*/
function getEmployeeModel(mongoose) {
  const contactDetailsSchema = mongoose.Schema({
    phoneNumber: {
      type: String,
      match: /([0-9]{3}\s{1})+/
    },
    emailAddress: {
      required: true,
      type: String
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
    contactDetails: {
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

  employeeSchema.methods.sellItemToAFriend = function (friend, itemForSaleId) {
    for (let i = 0; i < this.itemsForSale.length; i += 1) {
      const isMatch = this.itemsForSale[i]._id === itemForSaleId;
      if (isMatch) {
        const matchingItem = this.itemsForSale.splice(i, 1);
        friend.itemsReceived.push({
          name: matchingItem.name
        });

        break;
      }
    }
  };

  employeeSchema.virtual('fullName').get(function () {
    return `${this.firstName} ${this.middleName} ${this.lastName}`;
  });

  employeeSchema.virtual('fullName').set(function (fullName) {
    const names = fullName.split(' ');
    this.set('firstName', names[0]);
    this.set('middleName', names[1]);
    this.set('lastName', names[2]);
  });

  const Employee = mongoose.model("Employee", employeeSchema);

  return Employee;
}

module.exports = getEmployeeModel;