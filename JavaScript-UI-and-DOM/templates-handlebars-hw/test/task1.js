describe('Task 1: Mobile phones - create a table out of a template', function () {

    var data = {
        headers: ['Vendor', 'Model', 'OS'],
        items: [{
            col1: 'Nokia',
            col2: 'Lumia 920',
            col3: 'Windows Phone'
        }, {
                col1: 'LG',
                col2: 'Nexus 5',
                col3: 'Android'
            }, {
                col1: 'Apple',
                col2: 'iPhone 6',
                col3: 'iOS'
            }]
    };

    it('should work', function () {
        createTable(data);
    });
});