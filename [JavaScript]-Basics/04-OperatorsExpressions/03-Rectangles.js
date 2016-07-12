//jshint esversion: 6
function solve(args) {
  var width = Number(+args[0]);
  var heigth = Number(+args[1]);

  var area = width * heigth;
  var perimeter = 2 * width + 2 * heigth;

  console.log(area.toFixed(2) + ' ' + perimeter.toFixed(2));
}

solve(["2.5", "3"]);