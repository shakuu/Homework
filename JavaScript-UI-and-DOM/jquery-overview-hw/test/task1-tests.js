describe('Pupulate selector with COUNT list items', function () {
    it('should throw if COUNT is less than 1', function () {
        chai.expect(function () {
            taskPopulateList('asd', 0);
        }).to.throw(/^Count must be more than or equal to one.$/);
    });

    it('should throw if COUNT is missing, or not convertible to Number', function () {
        chai.expect(function () {
            taskPopulateList();
        }).to.throw(/^Count must be a number.$/);
    });

    it('should work', function () {
        let selector = $('#task1-div'),
            count = 5;

        chai.expect(function () {
            taskPopulateList(selector, count);
        }).to.not.throw();
    });
});