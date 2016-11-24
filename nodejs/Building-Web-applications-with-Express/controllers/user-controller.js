module.exports = function (userData) {
  function index(req, res) {
    userData.all()
      .then((users) => {
        res
          .status(200)
          .render('./user/index');
      })
      .catch((err) => {
        console.log(err);
      });
  }

  return {
    index
  };
};