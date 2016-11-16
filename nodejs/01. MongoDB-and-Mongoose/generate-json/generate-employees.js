/* globals module */
function generateEmployees(count) {
    const employees = [];
    for (let i = 0; i < count; i += 1) {
        const generatedItemsForSale = generateItemsForSale(2);
        const generatedItemsReceived = generateItemsReceived(2);

        const newEmployee = {
            firstName: 'FirstName',
            middleName: 'LastName',
            lastName: 'MiddleName',
            insuranceNumber: '09123123123',
            age: 15,
            contactDetails: {
                phoneNumber: '333 333 333 ',
                emailAddress: 'some@email.address',
                roomNumber: 101
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
            itemName: 'ItemName',
            itemPrice: 100,
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
            name: 'Received'
        };

        generatedItems.push(newItem);
    }

    return generatedItems;
}

module.exports = generateEmployees;