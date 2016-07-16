describe('Event model homework', function () {

    it('should throw if input is not a string or jQuery object', function () {
        chai.expect(function () {
            eventModel(5);
        }).to.throw(/^Input parameter must be a string or a jQuery object.$/);
    });

    // it('should throw if the id is either not a string or does not select any DOM element', function () {
    //     chai.expect(function () {
    //         eventModel($('#some-random-identifier'));
    //     }).to.throw(/^Provided element must already exist.$/);
    // });

    it('should work', function () {
        let element = $('#test-div');

        eventModel(element);
    });
});