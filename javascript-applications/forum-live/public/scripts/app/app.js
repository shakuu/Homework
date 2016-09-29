const Router = require('../router/router');

const RequestProvider = require('../requests/request-provider');
const DataServise = require('../services/data');
const TemplateLoaderService = require('../services/template-loader');
const LoginController = require('../controllers/login');
(() => {

    const requests = new RequestProvider();

    const data = new DataServise(requests);
    const templates = new TemplateLoaderService(requests);

    const login = new LoginController(templates, data);

    const my = new Router(login);
    my.start();
    
})();