// Throws if:
// The provided first parameter is neither string or existing DOM element
// The provided id does not select anything (there is no element that has such an id)
// Any of the function params is missing
// Any of the function params is not as described
// Any of the contents is neither string nor number
// In that case, the content of the element must not be changed

describe('testing DOM element', function () {

    it('should find my test div', function () {
        var testInput = $('#test-div').text();

        chai.assert.equal(testInput, 'test');
    });

    it('should throw if the provided parameter is not string', function () {
        chai.expect(function(){
            populateElelemnt(5);
        }).to.throw(/^bad string$/);
    });

    it('should throw if the provided parameter is not an existing DOM element', function () {

    });

    it('should throw if the provided id does not select a DOM element', function () {

    });

    it('should throw if any of the function params is missing', function () {

    });

    it('should throw if any of the function params is not as described', function () {

    });

    it('should throw if the content is not string or number', function () {

    });

}); 