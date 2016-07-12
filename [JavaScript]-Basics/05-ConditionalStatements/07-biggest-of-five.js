function solve(args){
  var numA = +args[0];
  var numB = +args[1];
  var numC = +args[2];
  var numD = +args[3];
  var numE = +args[4];
  
  var max  = numA;
  
  if (numB > max) {
    max = numB;
  }
  
  if (numC > max) {
    max = numC;
  }
  
  if (numD > max) {
    max = numD;
  }
  
  if (numE > max) {
    max = numE;
  }
  
  console.log(max);
}

solve(['5', '6', '2', '124', '123123123123']);
