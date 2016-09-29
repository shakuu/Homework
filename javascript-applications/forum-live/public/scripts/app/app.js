const Router = require('../router/router');

const RequestProvider = require('../requests/request-provider');
const DataServise = require('../services/data');
const TemplateLoaderService = require('../services/template-loader');

// controllers
const LoginController = require('../controllers/login');
const HomeController = require('../controllers/home');

(() => {
    const URLS = {
        USERS: 'api/users'
    };

    const requests = new RequestProvider();

    const data = new DataServise(URLS, requests);
    const templates = new TemplateLoaderService(requests);

    const home = new HomeController();
    const login = new LoginController(templates, data);

    const my = new Router('#content', home, login);
    my.start();

})();