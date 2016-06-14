function solve(args) {
  var x = Number(args[0]);
  var y = Number(args[1]);
  var distance = Math.sqrt((x * x) + (y * y));

  if (distance <= 2) {
    console.log('yes ' + distance.toFixed(2));
  }
  else {
    console.log('no ' + distance.toFixed(2));
  }
}

solve(["-1", "2"]);