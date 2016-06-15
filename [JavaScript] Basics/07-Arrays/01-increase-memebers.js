function solve(args) {

  var arr = new Array(20);

  for (var index = 0; index < 20; index += 1) {

    arr[index] = parseInt(index * 5);
    console.log(arr[index]);
  }
}