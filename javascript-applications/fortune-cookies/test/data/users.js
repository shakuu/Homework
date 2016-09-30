describe('usersService', () => {
    describe('allUsers', () => {
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

    describe('login', () => {
        it('Should invoke requester.putJSON method.', () => {
            const mockRequester = sinon.mock(requester);
            mockRequester.expects('putJSON').once();

            try {
                usersService.login();
            } catch (err) {

            }

            mockRequester.verify();
        });

        it('Should invoke requester.putJSON method with correct url.', () => {
            const mockRequester = sinon.mock(requester);
            mockRequester
                .expects('putJSON')
                .withArgs('api/auth')
                .once();

            try {
                usersService.login();
            } catch (err) {

            }

            mockRequester.verify();
        });

        it('Should invoke window.localStorage.setItem 2 times.', (done) => {
            const requesterPutJSON = sinon.stub(requester, 'putJSON');
            requesterPutJSON.returns(new Promise((resolve, reject) => {
                const fakeResponse = {};
                fakeResponse.result = {
                    username: 'me',
                    authKey: 'key'
                };

                resolve(fakeResponse);
            }));

            const mockStorage = sinon.mock(window.localStorage);
            mockStorage.expects('setItem').twice();

            usersService.login()
                .then(() => {
                    mockStorage.verify();
                })
                .then(done, done);
        });
    });

    describe('register', () => {
        it('Should invoke requester.postJSON method', () => {
            const mockRequester = sinon.mock(requester);
            mockRequester.expects('postJSON').once();

            usersService.register();

            mockRequester.verify();
        });

        it('Should invoke requester.postJSON method with correct url.', () => {
            const mockRequester = sinon.mock(requester);
            mockRequester.expects('postJSON').withArgs('api/users').once();

            usersService.register();

            mockRequester.verify();
        });
    });
});