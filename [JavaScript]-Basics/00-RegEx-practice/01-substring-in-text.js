function solve(parse, find){
  var tofind = new RegExp(String(find), '\g\i');
  var result = String(parse).match(tofind);
  console.log(result.length);
}

solve('AsdaAAaaasadsadasdasdasdsads', 'a');