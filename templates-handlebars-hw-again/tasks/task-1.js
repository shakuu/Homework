/* globals $ */

function solve() {

    return function (selector) {
        // var element = document.querySelector('#test-template'),
        //     output = document.querySelector('#output');

        var template = '<table class="items-table">' +
            '<thead>' +
                '<tr>' +
                    '<th>#</th>' +
                    '{{#headers}}' +
                        '<th>{{this}}</th>' +
                    '{{/headers}}' +
                '</tr>' +
            '</thead>' +
            '<tbody>' +
                '{{#items}}' +
                '<tr>' +
                    '<td>{{@index}}</td>'+
                    '<td>{{col1}}</td>' +
                    '<td>{{col2}}</td>' +
                    '<td>{{col3}}</td>' +
   	            '</tr>' +
                '{{/items}}' +
            '</tbody>' +
        '</table>'; 
        /* insert the template here as a string
        example:
        var template =
          '<ul>' +
            '{{#students}}' +
            '<li>' +
              '{{name}}' +
            '</li>' +
            '{{/students}}' +
          '</ul>';
    */

        // data = {
        //     headers: ['Vendor', 'Model', 'OS'],
        //     items: [
        //         {
        //             col1: 'Nokia',
        //             col2: 'Lumia 920',
        //             col3: 'Windows Phone'
        //         }, {
        //             col1: 'LG',
        //             col2: 'Nexus 5',
        //             col3: 'Android'
        //         }, {
        //             col1: 'Apple',
        //             col2: 'iPhone 6',
        //             col3: 'iOS'
        //         }]
        // };

        // var source = element.innerHTML;
        // var template = Handlebars.compile(source);

        // output.innerHTML = template(data);

        $(selector).html(template);
    };
}

module.exports = solve;