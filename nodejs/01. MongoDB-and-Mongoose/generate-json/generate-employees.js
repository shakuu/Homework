/* globals module require */
const randomGenerator = require('./random-generator');

function generateEmployees(count) {
    const employees = [];
    for (let i = 0; i < count; i += 1) {
        const generatedItemsForSale = generateItemsForSale(randomGenerator.getRandomInteger(1, 10));
        const generatedItemsReceived = generateItemsReceived(randomGenerator.getRandomInteger(1, 10));

        const newEmployee = {
            firstName: randomGenerator.getRandomName(),
            middleName: randomGenerator.getRandomName(),
            lastName: randomGenerator.getRandomName(),
            insuranceNumber: randomGenerator.getRandomInsuranceNumber(),
            age: randomGenerator.getRandomInteger(0, 120),
            contactDetails: {
                phoneNumber: randomGenerator.getRandomPhoneNumber(),
                emailAddress: randomGenerator.getRandomEmailAddress(),
                roomNumber: randomGenerator.getRandomInteger(100, 999)
            },
            itemsForSale: generatedItemsForSale,
            itemsReceived: generatedItemsReceived
        };

        employees.push(newEmployee);
    }

    return employees;
}

function generateItemsForSale(count) {
    const generatedItems = [];
    const giveAwayOptions = ['Give away', 'For Sale'];

    for (let i = 0; i < count; i += 1) {
        const newItemForSale = {
            itemName: randomGenerator.getRandomName(),
            itemPrice: randomGenerator.getRandomInteger(10, 1000),
            giveAwayStatus: giveAwayOptions[1]
        };

        generatedItems.push(newItemForSale);
    }

    return generatedItems;
}

function generateItemsReceived(count) {
    const generatedItems = [];

    for (let i = 0; i < count; i += 1) {
        const newItem = {
            name: randomGenerator.getRandomName()
        };

        generatedItems.push(newItem);
    }

    return generatedItems;
}

module.exports = generateEmployees;