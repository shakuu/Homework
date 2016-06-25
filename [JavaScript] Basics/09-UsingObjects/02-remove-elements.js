function solve(args) {
  var arr = args,
    remove = arr[0];

  Array.prototype.removeel = function (rem) {
    var result = [];

    for(var i in this){
      if (this[i] !== rem && typeof this[i] !== 'function') {
        result.push(this[i]);
      }
    }
   return result;
  };

  console.log(arr.removeel(remove).join('\n'));
}

solve(['_h/_',
  '^54F#',
  'V',
  '^54F#',
  'Z285',
  'kv?tc`',
  '^54F#',
  '_h/_',
  'Z285',
  '_h/_',
  'kv?tc`',
  'Z285',
  '^54F#',
  'Z285',
  'Z285',
  '_h/_',
  '^54F#',
  'kv?tc`',
  'kv?tc`',
  'Z285']);
