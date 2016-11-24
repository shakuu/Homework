const app = require('./config/express-config')();

require('./routes')(app);

app.listen(3001, () => {
  console.log(`App running on port: ${3001}`);
});