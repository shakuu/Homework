describe('usersDataService', () => {
    describe('allUsers', (done) => {
        it('Should invoke requester.get method once.', () => {
            const mockRequester = sinon.mock(requester);
            mockRequester.expects('get').once();

            usersService.allUsers();

            mockRequester.verify();
        });

        it('Should invoke requester.get method with correct url.', () => {
            const mockRequester = sinon.mock(requester);
            mockRequester.expects('get').withArgs('api/users').once();

            usersService.allUsers();

            mockRequester.verify();
        });

        it('Should invoke requester.get method with correct header.', () => {
            const stubLocalStorage = sinon.stub(localStorage, 'getItem');
            stubLocalStorage.returns('auth-key');

            const stubIsLoggedIn = sinon.stub(usersService, 'isLoggedIn');
            stubIsLoggedIn.returns(true);

            const mockRequester = sinon.mock(requester);
            mockRequester.expects('get').withArgs('api/users', { 'x-auth-key': 'auth-key' }).once();

            usersService.allUsers();

            mockRequester.verify();
        });
    });
});