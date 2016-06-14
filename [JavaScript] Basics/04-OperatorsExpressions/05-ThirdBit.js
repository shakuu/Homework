function solve (args) {
  var input = Math.floor( Number(+args));

  var mask = 1 << 3;

  if ( (input & mask) === 0) {
    console.log('0');
  }
  else {
    console.log('1');
  }
}

solve("1024");