function solve(args) {
  var find = (args[0] + '').toLowerCase(),
    parse = (args[1] + '').toLowerCase(),
    counter = 0;

  var index = parse.indexOf(find);
  while (index >= 0) {
    counter += 1;
    index = parse.indexOf(find, index + 1);
  }

  console.log(counter);
}

var test1 = ['in',
  'We are living in an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.'
];

solve(test1);