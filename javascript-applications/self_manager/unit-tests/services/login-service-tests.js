describe('loginService', () => {
    describe('login', () => {
        it('Should invoke ajaxRequester.putJSON method.', (done) => {
            const fakeUser = {
                username: 'fake',
                authKey: 'fake'
            };

            const fakeResponse = {
                result: fakeUser
            };

            const stubCredentialManagerSave = sinon.stub(credentialManager, 'save');
            const mockRequester = sinon.mock(ajaxRequester);
            mockRequester
                .expects('putJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(fakeResponse);
                }))
                .once();

            loginService.login()
                .then(() => {
                    mockRequester.verify();
                })
                .then(() => {
                    credentialManager.save.restore();
                })
                .then(done, done);
        });

        it('Should invoke ajaxRequester.putJSON method with correct url.', (done) => {
            const fakeUser = {
                username: 'fake',
                authKey: 'fake'
            };

            const fakeResponse = {
                result: fakeUser
            };

            const stubCredentialManagerSave = sinon.stub(credentialManager, 'save');
            const mockRequester = sinon.mock(ajaxRequester);
            mockRequester
                .expects('putJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(fakeResponse);
                }))
                .withArgs('api/users/auth')
                .once();

            loginService.login()
                .then(() => {
                    mockRequester.verify();
                })
                .then(() => {
                    credentialManager.save.restore();
                })
                .then(done, done);
        });

        it('Should invoke ajaxRequester.putJSON method with correct user.', (done) => {
            const fakeUser = {
                username: 'fake',
                authKey: 'fake'
            };

            const fakeResponse = {
                result: fakeUser
            };

            const fakeUserParameter = {
                username: 'parameter',
                passHash: 'password'
            };

            const stubCredentialManagerSave = sinon.stub(credentialManager, 'save');
            const mockRequester = sinon.mock(ajaxRequester);
            mockRequester
                .expects('putJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(fakeResponse);
                }))
                .withArgs('api/users/auth', fakeUserParameter)
                .once();

            loginService.login(fakeUserParameter)
                .then(() => {
                    mockRequester.verify();
                })
                .then(() => {
                    credentialManager.save.restore();
                })
                .then(done, done);
        });

        it('Should invoke credentialManager.save method with correct user.', (done) => {
            const fakeUser = {
                username: 'fake',
                authKey: 'fake'
            };

            const fakeResponse = {
                result: fakeUser
            };

            const fakeUserParameter = {
                username: 'parameter',
                passHash: 'password'
            };

            const stubAjaxRequesterPutJSON = sinon.stub(ajaxRequester, 'putJSON');
            stubAjaxRequesterPutJSON
                .returns(new Promise((resolve, reject) => {
                    resolve(fakeResponse);
                }));

            const mockCredentialManager = sinon.mock(credentialManager);
            mockCredentialManager
                .expects('save')
                .withArgs(fakeUser)
                .once();

            loginService.login(fakeUserParameter)
                .then(() => {
                    mockCredentialManager.verify();
                })
                .then(() => {
                    ajaxRequester.putJSON.restore();
                })
                .then(done, done);
        });
    });
});