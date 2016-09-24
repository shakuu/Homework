var data = (function () {
    const USERNAME_STORAGE_KEY = 'username-key';

    // start users
    function userLogin(user) {
        localStorage.setItem(USERNAME_STORAGE_KEY, user);
        return Promise.resolve(user);
    }

    function userLogout() {
        localStorage.removeItem(USERNAME_STORAGE_KEY)
        return Promise.resolve();
    }

    function userGetCurrent() {
        return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
    }
    // end users

    // start threads
    function threadsGet() {
        return new Promise((resolve, reject) => {
            $.getJSON('api/threads')
                .done(resolve)
                .fail(reject);
        });
    }

    function threadsAdd(title) {
        const apiUrl = 'api/threads';
        const requestBody = {
            title: title,
            username: 'anonymous'
        };

        const myPromise = new Promise((resolve, reject) => {
            $.ajax({
                type: 'POST',
                url: apiUrl,
                contentType: 'application/json',
                data: JSON.stringify(requestBody)
            })
                .done(resolve)
                .fail(reject);
        });

        return myPromise;
    }

    function threadById(id) {
        const baseApiUrl = 'api/threads/';
        const urlToAccess = baseApiUrl + id;
        return new Promise((resolve, reject) => {
            $.getJSON(urlToAccess)
                .done(resolve)
                .fail(reject);
        });
    }

    function threadsAddMessage(threadId, content) {
        const apiUrl = `api/threads/${threadId}/messages`;
        const requestBody = {
            username: 'anonymous',
            content: content
        };

        const myPromise = new Promise((resolve, reject) => {
            $.ajax({
                type: 'POST',
                url: apiUrl,
                data: JSON.stringify(requestBody),
                contentType: 'application/json'
            })
                .done(resolve)
                .fail(reject);
        });

        return myPromise;
    }
    // end threads

    // start gallery
    function galleryGet() {
        const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;

        const myPromise = new Promise((resolve, reject) => {
            $.getJSON(REDDIT_URL)
                .done(resolve)
                .fail(reject);
        });

        return myPromise;
    }
    // end gallery

    function getTemplate(template) {
        const promise = new Promise((resolve, reject) => {
            $.ajax({
                url: `templates/${template}.handlebars`,
                method: 'GET'
            })
                .done(resolve)
                .fail(reject);
        })
            .then((template) => {
                const compiled = Handlebars.compile(template);
                return compiled;
            });

        return promise;
    }

    return {
        users: {
            login: userLogin,
            logout: userLogout,
            current: userGetCurrent
        },
        threads: {
            get: threadsGet,
            add: threadsAdd,
            getById: threadById,
            addMessage: threadsAddMessage
        },
        gallery: {
            get: galleryGet,
        },
        templates: {
            get: getTemplate
        }
    };
})();