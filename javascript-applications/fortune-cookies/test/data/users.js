describe('usersDataService', () => {
    describe('allUsers', (done) => {
        it('test', () => {

            var mockRequester = sinon.mock(requester);
            mockRequester.expects('get').once();

            usersService.allUsers();
            mockRequester.verify();
        });
    });
});