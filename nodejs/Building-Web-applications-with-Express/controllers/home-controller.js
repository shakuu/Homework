module.exports = function () {
  function index(req, res) {
    res
      .status(200)
      .render('./home/index');
  }

  return {
    index
  };
};