function solve(args) {
  var n = +args,
    theSieve = [];

  if (n === 2) {
    console.log('2');
    return;
  }

  function sieve(args) {
    var start = +args, i, next;

    if (start * start > n) {
      return;
    }

    for (i = start * start; i <= n; i += start) {
      theSieve[i] = true;
    }

    next = getNext(start);
    sieve(next);
  }

  function getNext(args) {
    var cur = +args, i;

    for (i = cur + 1; i <= n; i += 1) {
      if (i % 2 !== 0) {
        if (!theSieve[i]) {
          return i;
        }
      }
    }
  }

  //  var next = 3;
  //   while (true) {

  //     if (next * next > n) {
  //       break;
  //     } else {
  //       sieve(next);
  //     }

  //     next = getNext(next);
  //   }

  function getOutput() {
    var i, len;

    for (i = n; i >= 2; i -= 1) {
      if (!theSieve[i] && i % 2 !== 0) {
        return i;
      }
    }
  }

  sieve(3);
  console.log(getOutput());
}

solve('26');