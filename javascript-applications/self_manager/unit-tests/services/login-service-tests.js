describe('loginService', () => {
    describe('login', () => {
        it('Should invoke ajaxRequester.putJSON method.', () => {
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

            loginService.login();

            mockRequester.verify();

            credentialManager.save.restore();
        });

        it('Should invoke ajaxRequester.putJSON method with correct url.', () => {
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

            loginService.login();

            mockRequester.verify();

            credentialManager.save.restore();
        });

        it('Should invoke ajaxRequester.putJSON method with correct user.', () => {
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

            loginService.login(fakeUserParameter);

            mockRequester.verify();

            credentialManager.save.restore();
        });
    });
});