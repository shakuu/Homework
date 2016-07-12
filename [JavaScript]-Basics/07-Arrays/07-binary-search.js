function solve(args) {
  var input = (args + '').split('\n').map(Number),
    find, len, i, j, left, right, found;

  input.splice(0, 1);
  len = input.length;
  find = input.splice(len - 1, 1);
  len -= 1;

  input.sort(function (a, b) {
    if (+a < +b) {
      return -1;
    } else if (+a > +b) {
      return 1;
    } else {
      return 0;
    }
  });

  left = 0;
  right = len - 1;

  function BinarySearch(leftarg, rightarg) {
    var leftIndex = +leftarg;
    var rightIndex = +rightarg;

    var mid = ((rightIndex - leftIndex) / 2 + leftIndex) | 0;

    if (leftIndex === rightIndex) {
      found = -1;
      return;
    }

    if (+find === input[mid]) {
      found = mid;
      return;
    } else if (+find < input[mid]) {
      BinarySearch(leftIndex, mid);
    } else {
      BinarySearch(mid + 1, rightIndex);
    }
  }

  BinarySearch(left, right);

  console.log(found);
}

// solve(['10\n1\n2\n4\n8\n16\n31\n32\n64\n77\n99\n32']);