describe('Event model homework', function () {

    it('should throw if the provided DOM element is non-existant', function () {
        chai.expect(function () {
            eventModel(5);
        }).to.throw(/^Input parameter must be a string or a DOM element.$/);
    });

    it('should throw if the id is either not a string or does not select any DOM element', function () {
        chai.expect(function () {
            eventModel('some-random-identifier')
        }).to.throw(/^Provided element must already exist.$/);
    });

    it('should work', function () {
        let element = document.getElementById('test-div');

        eventModel(element);
    });
});