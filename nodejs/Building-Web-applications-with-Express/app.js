const app = require('./config/express-config')();

const config = require('./config/constants');
const models = require('./models')();
const data = require('./data')(config, models);

require('./config/passport-config')(app, data.userData);
require('./routes')(app, data);

app.listen(config.port, () => {
  console.log(`App running on port: ${config.port}`);
});