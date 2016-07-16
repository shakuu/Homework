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
        chai.expect(function () {
            populateElelemnt(5, []);
        }).to.throw(/^element must be a string or DOM element$/);
    });

    it('should point to an existing DOM element', function () {
        var testElement = document
            .createElement('p');

        testElement.setAttribute('id', 'super-duper-random-non-existing-testing-identifier');

        chai.expect(function () {
            populateElelemnt(testElement, []);
        }).to.throw(/^element must already exist$/);
    });

    it('should throw if the provided id does not select a DOM element', function () {
        chai.expect(function () {
            populateElelemnt('super-duper-random', []);
        }).to.throw(/^element id must be of an existing DOM element$/);
    });

    it('should throw if any of the function params is missing', function () {
        chai.expect(function () {
            populateElelemnt();
        }).to.throw(/^parameter \[\w+\] must be present$/);

        chai.expect(function () {
            populateElelemnt('a');
        }).to.throw(/^parameter \[\w+\] must be present$/);
    });

    it('should throw if any of the function params is not as described', function () {
        chai.expect(function () {
            populateElelemnt('5', 5);
        }).to.throw(/^contentArray must be an array$/);
    });

    it('should throw if the content is not string or number', function () {
        chai.expect(function () {
            populateElelemnt('test-div', [{ x: 5 }]);
        }).to.throw(/^content must be of type string or number$/);
    });

    it('should work', function () {
        let element = populateElelemnt('test-div', [1, 'a', 123]);

        chai.assert.equal(element.innerHTML, '<div>1</div><div>a</div>');
    });

}); 