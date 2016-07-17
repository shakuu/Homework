describe('Task 3: ', function () {
    var books = [
        {
            id: 1,
            title: 'JavaScript: The Good Parts'
        },
        {
            id: 2,
            title: 'Secrets of the JavaScript Ninja'
        },
        {
            id: 3,
            title: 'Core HTML5 Canvas'
        },
        {
            id: 4,
            title: 'JavaScript Patterns'
        }
    ];

    it('should work', function () {
        $('#books-list').listview(books);
    });
});