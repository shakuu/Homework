module.exports = function () {
  function index(req, res) {
    res
      .status(200)
      .render('./home/index', {
        result: {
          isAuthenticated: req.isAuthenticated()
        }
      });
  }

  return {
    index
  };
};