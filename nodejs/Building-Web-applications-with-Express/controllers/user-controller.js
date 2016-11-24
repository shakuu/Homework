module.exports = function (userData) {
  function index(req, res) {
    userData.all()
      .then((users) => {
        res
          .status(200)
          .render('./user/index', {
            result: users
          });
      })
      .catch((err) => {
        res
          .status(404)
          .render('./user/index', {
            result: []
          });
      });
  }

  return {
    index
  };
};